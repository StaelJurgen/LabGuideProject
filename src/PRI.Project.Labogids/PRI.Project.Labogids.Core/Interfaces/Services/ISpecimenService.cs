using Microsoft.AspNetCore.Http;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface ISpecimenService
    {
        Task<ItemResultModel<Specimen>> GetAllAsync();
        Task<ItemResultModel<Specimen>> GetByIdAsync(int id);
        Task<ItemResultModel<Specimen>> AddAsync(string name, IFormFile image/*, IEnumerable<int> properties*/);
        Task<ItemResultModel<Specimen>> UpdateAsync(int id, string name, IFormFile image/*, IEnumerable<int> properties*/);
        Task DeleteAsync(int id);
    }
}
