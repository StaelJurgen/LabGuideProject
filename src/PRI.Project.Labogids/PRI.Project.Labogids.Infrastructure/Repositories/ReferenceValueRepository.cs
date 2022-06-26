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
    public class ReferenceValueRepository : BaseRepository<ReferenceValue>, IReferenceValueRepository
    {
        public ReferenceValueRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
