using Microsoft.EntityFrameworkCore;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Interfaces.Repositories;
using PRI.Project.Labogids.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Infrastructure.Repositories
{
    public class LaboratoryRepository : BaseRepository<Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public override async Task<IEnumerable<Laboratory>> GetAllAsync()
        {
            return await _table
                .Include(l => l.Properties)
                .ToListAsync();
        }

        public override async Task<Laboratory> GetByIdAsync(int id)
        {
            return await _table
                .Include(l => l.Properties)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
