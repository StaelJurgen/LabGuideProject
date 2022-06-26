using PRI.Project.Labogids.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Repositories
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<IEnumerable<Property>> GetByLaboratoryIdAsync(int id);
        Task<IEnumerable<Property>> GetBySpecimenIdAsync(int id);
        Task<IEnumerable<Property>> SearchAsync(string needle);
    }
}
