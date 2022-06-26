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
    public class SpecimenRepository : BaseRepository<Specimen>, ISpecimenRepository
    {
        public SpecimenRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public override async Task<Specimen> GetByIdAsync(int id)
        {
            return await _table
                .Include(s => s.Properties)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
