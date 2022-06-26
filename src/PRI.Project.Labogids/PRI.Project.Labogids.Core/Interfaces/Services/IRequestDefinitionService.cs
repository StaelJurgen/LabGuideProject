using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Services.Models;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface IRequestDefinitionService
    {
        Task<ItemResultModel<RequestDefinition>> GetAllAsync();
        Task<ItemResultModel<RequestDefinition>> GetByIdAsync(int id);
        Task<ItemResultModel<RequestDefinition>> AddAsync(int billingCode, string diagnoseRule, string cumulationRule);
        Task<ItemResultModel<RequestDefinition>> UpdateAsync(int id, int billingCode, string diagnoseRule, string cumulationRule);
        Task DeleteAsync(int id);
    }
}
