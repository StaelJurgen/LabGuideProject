using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface ILaboratoryService
    {
        Task<ItemResultModel<Laboratory>> GetAllAsync();
        Task<ItemResultModel<Laboratory>> GetByIdAsync(int id);
        Task<ItemResultModel<Laboratory>> AddAsync(string name, string address, int postalCode, string city, string country/*, IEnumerable<int> properties*/);
        Task<ItemResultModel<Laboratory>> UpdateAsync(int id, string name, string address, int postalCode, string city, string country/*, IEnumerable<int> properties*/);
        Task DeleteAsync(int id);
    }
}
