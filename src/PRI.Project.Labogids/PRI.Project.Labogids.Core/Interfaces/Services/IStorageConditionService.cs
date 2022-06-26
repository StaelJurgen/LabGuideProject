using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Enumerations;
using PRI.Project.Labogids.Core.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface IStorageConditionService
    {
        Task<ItemResultModel<StorageCondition>> GetAllAsync();
        Task<ItemResultModel<StorageCondition>> GetByIdAsync(int id);
        Task<ItemResultModel<StorageCondition>> AddAsync(string temperature, int timePeriod, TimeReference timeReference, IEnumerable<int> properties);
        Task<ItemResultModel<StorageCondition>> UpdateAsync(int id, string temperature, int timePeriod, TimeReference timeReference, IEnumerable<int> properties);
        Task DeleteAsync(int id);
    }
}
