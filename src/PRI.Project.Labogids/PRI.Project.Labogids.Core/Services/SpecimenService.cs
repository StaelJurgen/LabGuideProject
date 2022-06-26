using Microsoft.AspNetCore.Http;
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
    public class SpecimenService : ISpecimenService
    {
        private readonly ISpecimenRepository _specimenRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IImageService _imageService;

        public const string Fault = "Er is een fout opgetreden. Probeer opnieuw!";
        public const string SpecNotFound = "Het staaltype werd niet gevonden!";
        public const string SpecsNotFound = "Er zijn geen staaltypes gevonden!";

        public SpecimenService(ISpecimenRepository specimenRepository, IPropertyRepository propertyRepository, IImageService imageService)
        {
            _specimenRepository = specimenRepository;
            _propertyRepository = propertyRepository;
            _imageService = imageService;
        }

        public async Task<ItemResultModel<Specimen>> GetAllAsync()
        {
            var specimens = await _specimenRepository.GetAllAsync();
            ItemResultModel<Specimen> itemResultModel = new();

            if (specimens != null)
            {
                itemResultModel.Items = specimens;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(SpecsNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<Specimen>> GetByIdAsync(int id)
        {
            ItemResultModel<Specimen> itemResultModel = new();
            var specimen = await _specimenRepository.GetByIdAsync(id);

            if (specimen != null)
            {
                //specimen.Image = _imageService.GetUrl<Specimen>(specimen.Image);
                itemResultModel.Items = new List<Specimen> { specimen };
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(SpecNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<Specimen>> AddAsync(string name, IFormFile image/*, IEnumerable<int> properties*/)
        {
            //var allProperties = await _propertyRepository.GetAllAsync();

            var newSpecimen = new Specimen
            {
                Name = name,
                Image = await _imageService.AddOrUpdateImageAsync<Specimen>(image),
                //Properties = allProperties.Where(pr => properties.Contains(pr.Id))
                //    .ToList()
            };

            if (!await _specimenRepository.AddAsync(newSpecimen))
            {
                return new ItemResultModel<Specimen>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<Specimen> { IsSuccess = true };
        }

        public async Task<ItemResultModel<Specimen>> UpdateAsync(int id, string name, IFormFile image/*, IEnumerable<int> properties*/)
        {
            var specimen = await _specimenRepository.GetByIdAsync(id);

            if (specimen == null)
            {
                return new ItemResultModel<Specimen>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(SpecNotFound) }
                };
            }

            specimen.Name = name;
            specimen.Image = await _imageService.AddOrUpdateImageAsync<Specimen>(image, specimen.Image);
            //specimen.Properties =
            //    _propertyRepository.GetAll().Where(pr => properties.Contains(pr.Id)).ToList();

            if (!await _specimenRepository.UpdateAsync(specimen))
            {
                return new ItemResultModel<Specimen>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<Specimen> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            var specimen = await _specimenRepository.GetByIdAsync(id);

            if (specimen != null)
            {
                await _specimenRepository.DeleteAsync(specimen);
            }
        }
    }
}
