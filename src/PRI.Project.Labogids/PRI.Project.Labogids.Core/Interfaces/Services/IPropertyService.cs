using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Enumerations;
using PRI.Project.Labogids.Core.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface IPropertyService
    {
        Task<ItemResultModel<Property>> GetAllAsync();
        Task<ItemResultModel<Property>> GetByIdAsync(int id);
        Task<ItemResultModel<Property>> GetByLaboratoryIdAsync(int laboratoryId);
        Task<ItemResultModel<Property>> GetBySpecimenIdAsync(int specimenId);
        Task<ItemResultModel<Property>> SearchAsync(string needle);
        Task<ItemResultModel<Property>> AddAsync(string name, string synonym, int specimenId, /*IEnumerable<int> storageConditions, */int laboratoryId, string requestCode, int reqDefId, int turnAroundTime, TimeReference period/*, IEnumerable<int> referenceValues*/);
        Task<ItemResultModel<Property>> UpdateAsync(int id, string name, string synonym, int specimenId, IEnumerable<int> storageConditions, int laboratoryId, string requestCode, int reqDefId, int turnAroundTime, TimeReference period, IEnumerable<int> referenceValues);
        Task DeleteAsync(int id);
    }
}
