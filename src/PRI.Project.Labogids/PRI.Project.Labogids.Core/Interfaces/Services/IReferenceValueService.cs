using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Enumerations;
using PRI.Project.Labogids.Core.Services.Models;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface IReferenceValueService
    {
        Task<ItemResultModel<ReferenceValue>> GetAllAsync();
        Task<ItemResultModel<ReferenceValue>> GetByIdAsync(int id);
        Task<ItemResultModel<ReferenceValue>> AddAsync(double? minimumValue, double? maximumValue, string unit, string stringValue, string sex, int? maximalAge, int propertyId, TimeReference? period);
        Task<ItemResultModel<ReferenceValue>> UpdateAsync(int id, double? minimumValue, double? maximumValue, string unit, string stringValue, string sex, int? maximalAge, /*int propertyId,*/ TimeReference? period);
        Task DeleteAsync(int id);
    }
}
