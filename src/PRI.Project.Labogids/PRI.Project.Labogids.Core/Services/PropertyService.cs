using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Enumerations;
using PRI.Project.Labogids.Core.Interfaces.Repositories;
using PRI.Project.Labogids.Core.Interfaces.Services;
using PRI.Project.Labogids.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IReferenceValueRepository _refValRepository;
        private readonly IStorageConditionRepository _stoConRepository;

        public const string Fault = "Er is een fout opgetreden. Probeer opnieuw!";
        public const string PropertiesNotFound = "Geen bepalingen gevonden!";
        public const string PropertyNotFound = "De bepaling werd niet gevonden!";
        
        public PropertyService(IPropertyRepository propertyRepository, IReferenceValueRepository refValRepository, IStorageConditionRepository stoConRepository)
        {
            _propertyRepository = propertyRepository;
            _refValRepository = refValRepository;
            _stoConRepository = stoConRepository;
        }

        public async Task<ItemResultModel<Property>> GetAllAsync()
        {
            var properties = await _propertyRepository.GetAllAsync();

            ItemResultModel<Property> itemResultModel = new();
            if (properties != null)
            {
                itemResultModel.Items = properties;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(PropertiesNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<Property>> GetByIdAsync(int id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);

            ItemResultModel<Property> itemResultModel = new();
            if (property != null)
            {
                itemResultModel.Items = new List<Property> { property };
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(PropertyNotFound) };

            return itemResultModel;            
        }

        public async Task<ItemResultModel<Property>> GetByLaboratoryIdAsync(int laboratoryId)
        {
            var properties = await _propertyRepository.GetByLaboratoryIdAsync(laboratoryId);
            ItemResultModel<Property> itemResultModel = new();

            if (properties != null)
            {
                itemResultModel.Items = properties;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(PropertiesNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<Property>> GetBySpecimenIdAsync(int specimenId)
        {
            var properties = await _propertyRepository.GetBySpecimenIdAsync(specimenId);
            ItemResultModel<Property> itemResultModel = new();

            if (properties != null)
            {
                itemResultModel.Items = properties;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(PropertiesNotFound) };
            
            return itemResultModel;
        }

        public async Task<ItemResultModel<Property>> SearchAsync(string needle)
        {
            var properties = await _propertyRepository.SearchAsync(needle);
            ItemResultModel<Property> itemResultModel = new();

            if (properties != null)
            {
                itemResultModel.Items = properties;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(PropertiesNotFound) };

            return itemResultModel;

        }

        public async Task<ItemResultModel<Property>> AddAsync(string name, string synonym, int specimenId, /*IEnumerable<int> storageConditions, */int laboratoryId, string requestCode, int reqDefId, int turnAroundTime, TimeReference period/*, IEnumerable<int> referenceValues*/)
        {
            //var allStorageConditions = await _stoConRepository.GetAllAsync();
            //var allReferenceValues = await _refValRepository.GetAllAsync();

            var newProperty = new Property
            {
                Name = name,
                Synonym = synonym,
                SpecimenId = specimenId,
                //StorageConditions = allStorageConditions.Where(sc => storageConditions.Contains(sc.Id))
                //    .ToList(),
                LaboratoryId = laboratoryId,
                RequestCode = requestCode,
                RequestDefinitionId = reqDefId,
                TurnAroundTime = turnAroundTime,
                TimePeriod = period,
                //ReferenceValues = allReferenceValues.Where(rv => referenceValues.Contains(rv.Id))
                //    .ToList()
            };

            if (!await _propertyRepository.AddAsync(newProperty))
            {
                return new ItemResultModel<Property>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            List<Property> properties = new List<Property>();
            properties.Add(newProperty);

            return new ItemResultModel<Property> { IsSuccess = true, Items = properties };
        }

        public async Task<ItemResultModel<Property>> UpdateAsync(int id, string name, string synonym, int specimenId, IEnumerable<int> storageConditions, int laboratoryId, string requestCode, int reqDefId, int turnAroundTime, TimeReference period, IEnumerable<int> referenceValues)
        {
            var allStorageConditions = await _stoConRepository.GetAllAsync();
            var allReferenceValues = await _refValRepository.GetAllAsync();
            var newProperty = new Property
            {
                Id = id,
                Name = name,
                Synonym = synonym,
                SpecimenId = specimenId,
                StorageConditions = allStorageConditions.Where(sc => storageConditions.Contains(sc.Id))
                    .ToList(),
                LaboratoryId = laboratoryId,
                RequestCode = requestCode,
                RequestDefinitionId = reqDefId,
                TurnAroundTime = turnAroundTime,
                TimePeriod = period,
                ReferenceValues = allReferenceValues.Where(rv => referenceValues.Contains(rv.Id))
                    .ToList()
            };

            if (!await _propertyRepository.UpdateAsync(newProperty))
            {
                return new ItemResultModel<Property>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<Property> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property != null)
            {
                await _propertyRepository.DeleteAsync(property);
            }
        }
    }
}
