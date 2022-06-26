using PRI.Project.Labogids.Core.Entities;
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
    public class LaboratoryService : ILaboratoryService
    {
        private readonly ILaboratoryRepository _laboratoryRepository;
        private readonly IPropertyRepository _propertyRepository;

        public const string Fault = "Er is een fout opgetreden. Probeer opnieuw!";
        public const string LabNotFound = "Het laboratorium werd niet gevonden!";
        public const string LabsNotFound = "Geen laboratoria gevonden!";

        public LaboratoryService(ILaboratoryRepository laboratoryRepository, IPropertyRepository propertyRepository)
        {
            _laboratoryRepository = laboratoryRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<ItemResultModel<Laboratory>> GetAllAsync()
        {
            var laboratories = await _laboratoryRepository.GetAllAsync();

            ItemResultModel<Laboratory> itemResultModel = new();
            if (laboratories != null)
            {
                itemResultModel.Items = laboratories;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(LabsNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<Laboratory>> GetByIdAsync(int id)
        {
            var laboratory = await _laboratoryRepository.GetByIdAsync(id);

            ItemResultModel<Laboratory> itemResultModel = new();
            if (laboratory != null)
            {
                itemResultModel.Items = new List<Laboratory> { laboratory };
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(LabNotFound) };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Laboratory>> AddAsync(string name, string address, int postalCode, string city, string country/*, IEnumerable<int> properties*/)
        {
            //var allProperties = await _propertyRepository.GetAllAsync();

            if (postalCode.ToString().Length != 4)
            {
                return new ItemResultModel<Laboratory>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            var newLaboratory = new Laboratory
            {
                Name = name,
                Address = address,
                PostalCode = postalCode,
                City = city,
                Country = country,
                /*Properties = allProperties.Where(pr => properties.Contains(pr.Id))
                    .ToList()*/
            };

            if (!await _laboratoryRepository.AddAsync(newLaboratory))
            {
                return new ItemResultModel<Laboratory>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<Laboratory> { IsSuccess = true };
        }

        public async Task<ItemResultModel<Laboratory>> UpdateAsync(int id, string name, string address, int postalCode, string city, string country/*, IEnumerable<int> properties*/)
        {
            var laboratory = await _laboratoryRepository.GetByIdAsync(id);

            if (laboratory == null)
            {
                return new ItemResultModel<Laboratory>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult(LabNotFound)
                    }
                };
            }

            if (postalCode.ToString().Length != 4)
            {
                return new ItemResultModel<Laboratory>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            laboratory.Name = name;
            laboratory.Address = address;
            laboratory.PostalCode = postalCode;
            laboratory.City = city;
            laboratory.Country = country;
            /*laboratory.Properties =
                _propertyRepository.GetAll().Where(pr => properties.Contains(pr.Id)).ToList();*/

            if (!await _laboratoryRepository.UpdateAsync(laboratory))
            {
                return new ItemResultModel<Laboratory>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<Laboratory> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            var laboratory = await _laboratoryRepository.GetByIdAsync(id);

            if (laboratory != null)
            {
                await _laboratoryRepository.DeleteAsync(laboratory);
            }
        }

    }
}
