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
    public class StorageConditionService : IStorageConditionService
    {
        private readonly IStorageConditionRepository _stoConRepository;
        private readonly IPropertyRepository _propertyRepository;

        public const string Fault = "Er is een fout opgetreden. Probeer opnieuw!";
        public const string StoConNotFound = "Er werd geen bewaarconditie gevonden!";
        public const string StoConsNotFound = "Geen bewaarcondities gevonden!";

        public StorageConditionService(IStorageConditionRepository stoConRepository, IPropertyRepository propertyRepository)
        {
            _stoConRepository = stoConRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<ItemResultModel<StorageCondition>> GetAllAsync()
        {
            var storageConditions = await _stoConRepository.GetAllAsync();
            ItemResultModel<StorageCondition> itemResultModel = new();

            if (storageConditions != null)
            {
                itemResultModel.Items = storageConditions;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(StoConsNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<StorageCondition>> GetByIdAsync(int id)
        {
            ItemResultModel<StorageCondition> itemResultModel = new();
            var storageCondition = await _stoConRepository.GetByIdAsync(id);

            if (storageCondition != null)
            {
                itemResultModel.Items = new List<StorageCondition> { storageCondition };
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            
            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(StoConNotFound) };
            
            return itemResultModel;
        }

        public async Task<ItemResultModel<StorageCondition>> AddAsync(string temperature, int timePeriod, TimeReference timeReference, IEnumerable<int> properties)
        {
            var allProperties = await _propertyRepository.GetAllAsync();

            //var allStorageConditions = await _stoConRepository.GetAllAsync();
            //foreach (var stoCon in allStorageConditions)
            //{
            //    if (stoCon.Temperature == temperature && stoCon.TimePeriod == timePeriod && stoCon.TimeReference.ToString() == timeReference.ToString())
            //    {
            //        return new ItemResultModel<StorageCondition>
            //        {
            //            IsSuccess = false,
            //            ValidationErrors = new List<ValidationResult> { new ValidationResult("Deze bewaarconditie bestaat al!") }
            //        };
            //    }
            //    else
            //    {
            //        var newStorageCondition = new StorageCondition
            //        {
            //            Temperature = temperature,
            //            TimePeriod = timePeriod,
            //            TimeReference = timeReference,
            //            Properties = allProperties.Where(pr => properties.Contains(pr.Id))
            //        .ToList()
            //        };
            //    }
            //}

            var newStorageCondition = new StorageCondition
            {
                Temperature = temperature,
                TimePeriod = timePeriod,
                TimeReference = timeReference,
                Properties = allProperties.Where(pr => properties.Contains(pr.Id))
                    .ToList()
            };

            if (!await _stoConRepository.AddAsync(newStorageCondition))
            {
                return new ItemResultModel<StorageCondition>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<StorageCondition> { IsSuccess = true };
        }

        public async Task<ItemResultModel<StorageCondition>> UpdateAsync(int id, string temperature, int timePeriod, TimeReference timeReference, IEnumerable<int> properties)
        {
            var storageCondition = await _stoConRepository.GetByIdAsync(id);

            if (storageCondition == null)
            {
                return new ItemResultModel<StorageCondition>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(StoConNotFound) }
                };
            }

            storageCondition.Temperature = temperature;
            storageCondition.TimePeriod = timePeriod;
            storageCondition.TimeReference = timeReference;
            storageCondition.Properties =
                _propertyRepository.GetAll().Where(pr => properties.Contains(pr.Id)).ToList();

            if (!await _stoConRepository.UpdateAsync(storageCondition))
            {
                return new ItemResultModel<StorageCondition>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<StorageCondition> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            var storageCondition = await _stoConRepository.GetByIdAsync(id);

            if (storageCondition != null)
            {
                await _stoConRepository.DeleteAsync(storageCondition);
            }
        }
    }
}
