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
    public class StorageConditionRepository : BaseRepository<StorageCondition>, IStorageConditionRepository
    {
        public StorageConditionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }

        public override async Task<StorageCondition> GetByIdAsync(int id)
        {
            return await _table
                .Include(sc => sc.Properties)
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }
    }
}
