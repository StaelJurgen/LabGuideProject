using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Interfaces.Repositories;
using PRI.Project.Labogids.Core.Interfaces.Services;
using PRI.Project.Labogids.Core.Services.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Services
{
    public class RequestDefinitionService : IRequestDefinitionService
    {
        private readonly IRequestDefinitionRepository _reqDefRepository;

        public const string Fault = "Er is een fout opgetreden. Probeer opnieuw!";
        public const string ReqDefNotFound = "De aanvraagdefinitie werd niet gevonden!";
        public const string ReqDefsNotFound = "Geen aanvraagdefinities gevonden!";

        public RequestDefinitionService(IRequestDefinitionRepository reqDefRepository)
        {
            _reqDefRepository = reqDefRepository;
        }

        public async Task<ItemResultModel<RequestDefinition>> GetAllAsync()
        {
            var reqDefs = await _reqDefRepository.GetAllAsync();
            ItemResultModel<RequestDefinition> itemResultModel = new();

            if (reqDefs != null)
            {
                itemResultModel.Items = reqDefs;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(ReqDefNotFound) };

            return itemResultModel;
        }

        public async Task<ItemResultModel<RequestDefinition>> GetByIdAsync(int id)
        { 
            ItemResultModel<RequestDefinition> itemResultModel = new();
            var reqDef = await _reqDefRepository.GetByIdAsync(id);

            if (reqDef != null)
            {
                itemResultModel.Items = new List<RequestDefinition> { reqDef };
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult> { new ValidationResult(ReqDefNotFound) };
            
            return itemResultModel;
        }

        public async Task<ItemResultModel<RequestDefinition>> AddAsync(int billingCode, string diagnoseRule, string cumulationRule)
        {
            var newReqDef = new RequestDefinition
            {
                BillingCode = billingCode,
                DiagnoseRule = diagnoseRule,
                CumulationRule = cumulationRule
            };

            if (!await _reqDefRepository.AddAsync(newReqDef))
            {
                return new ItemResultModel<RequestDefinition>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<RequestDefinition> { IsSuccess = true };
        }

        public async Task<ItemResultModel<RequestDefinition>> UpdateAsync(int id, int billingCode, string diagnoseRule, string cumulationRule)
        {
            var reqDef = await _reqDefRepository.GetByIdAsync(id);

            if (reqDef == null)
            {
                return new ItemResultModel<RequestDefinition>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(ReqDefNotFound) }
                };
            }

            reqDef.BillingCode = billingCode;
            reqDef.DiagnoseRule = diagnoseRule;
            reqDef.CumulationRule = cumulationRule;

            if(!await _reqDefRepository.UpdateAsync(reqDef))
            {
                return new ItemResultModel<RequestDefinition>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult(Fault) }
                };
            }

            return new ItemResultModel<RequestDefinition> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            var reqDef = await _reqDefRepository.GetByIdAsync(id);
            if (reqDef != null)
            {
                await _reqDefRepository.DeleteAsync(reqDef);
            }
        }
    }
}
