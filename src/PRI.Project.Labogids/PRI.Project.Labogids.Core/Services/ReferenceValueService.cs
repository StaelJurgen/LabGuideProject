using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Enumerations;
using PRI.Project.Labogids.Core.Interfaces.Repositories;
using PRI.Project.Labogids.Core.Interfaces.Services;
using PRI.Project.Labogids.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Services
{
    public class ReferenceValueService : IReferenceValueService
    {
        private readonly IReferenceValueRepository _refValRepository;

        public const string Fault = "Er is een fout opgetreden. Probeer opnieuw!";
        public const string RefValNotFound = "De referentiewaarde werd niet gevonden!";
        public const string RefValsNotFound = "Geen referentiewaarden gevonden!";

        public ReferenceValueService(IReferenceValueRepository referenceValueRepository)
        {
            _refValRepository = referenceValueRepository;
        }

        public async Task<ItemResultModel<ReferenceValue>> GetAllAsync()
        {
            var references = await _refValRepository.GetAllAsync();
            ItemResultModel<ReferenceValue> itemResultModel = new();

            if (references != null)
            {
                itemResultModel.Items = references;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(RefValsNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<ReferenceValue>> GetByIdAsync(int id)
        {
            ItemResultModel<ReferenceValue> itemResultModel = new();
            var reference = await _refValRepository.GetByIdAsync(id);

            if (reference != null)
            {
                itemResultModel.Items = new List<ReferenceValue> { reference };
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(RefValNotFound) };
            
            return itemResultModel;
        }

        public async Task<ItemResultModel<ReferenceValue>> AddAsync(double? minimumValue, double? maximumValue, string unit, string stringValue, string sex, int? maximalAge, int propertyId, TimeReference? period)
        {
            TimeReference parsedPeriod;
            if (period == null)
            {
                parsedPeriod = TimeReference.None;
            }
            else
            {
                parsedPeriod = (TimeReference)Enum.Parse(typeof(TimeReference), period.ToString());
            }

            var newReferenceValue = new ReferenceValue
            {
                MinimumValue = minimumValue,
                MaximumValue = maximumValue,
                Unit = unit,
                StringValue = stringValue,
                Sex = sex,
                MaximalAge = maximalAge,
                PropertyId = propertyId,
                Period = parsedPeriod,
            };

            if (!await _refValRepository.AddAsync(newReferenceValue))
            {
                return new ItemResultModel<ReferenceValue>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<ReferenceValue> { IsSuccess = true };
        }

        public async Task<ItemResultModel<ReferenceValue>> UpdateAsync(int id, double? minValue, double? maxValue, string unit, string stringValue, string sex, int? maxAge, /*int propertyId,*/ TimeReference? period)
        {
            var reference = await _refValRepository.GetByIdAsync(id);

            if (reference == null)
            {
                return new ItemResultModel<ReferenceValue>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(RefValNotFound) }
                };
            }

            reference.Id = id;
            reference.MinimumValue = minValue;
            reference.MaximumValue = maxValue;
            reference.Unit = unit;
            reference.StringValue = stringValue;
            reference.Sex = sex;
            reference.MaximalAge = maxAge;
            reference.Period = period;
            //reference.PropertyId = propertyId;

            if (!await _refValRepository.UpdateAsync(reference))
            {
                return new ItemResultModel<ReferenceValue>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<ReferenceValue> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            var reference = await _refValRepository.GetByIdAsync(id);
            if (reference != null)
            {
                await _refValRepository.DeleteAsync(reference);
            }
        }
    }
}

