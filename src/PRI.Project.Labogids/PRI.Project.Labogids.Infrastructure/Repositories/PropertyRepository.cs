using Microsoft.EntityFrameworkCore;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Interfaces.Repositories;
using PRI.Project.Labogids.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Infrastructure.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Property>> GetByLaboratoryIdAsync(int id)
        {
            return await _table
                .Include(p => p.Laboratory)
                .Where(p => p.LaboratoryId == id).ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetBySpecimenIdAsync(int id)
        {
            return await _table
                .Include(p => p.Specimen)
                .Where(p => p.SpecimenId == id).ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchAsync(string needle)
        {
            return await _table
                .Where(p => p.Synonym.ToUpper().Contains(needle) || 
                                            p.Name.ToUpper().Contains(needle)).ToListAsync();            
        }

        public override async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _table
                .Include(p => p.Laboratory)
                .Include(p => p.Specimen)
                .Include(p => p.RequestDefinition)
                .Include(p => p.ReferenceValues)
                .Include(p => p.StorageConditions)
                .ToListAsync();
        }

        public override async Task<Property> GetByIdAsync(int id)
        {
            return await _table
                .Include(p => p.StorageConditions)
                .Include(p => p.ReferenceValues)
                .Include(p => p.Specimen)
                .Include(p => p.RequestDefinition)
                .Include(p => p.Laboratory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
