using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Labogids.Api.DTOs.RequestDefinitions;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDefinitionsController : Controller
    {
        private readonly IRequestDefinitionService _reqDefService;
        public RequestDefinitionsController(IRequestDefinitionService reqDefService)
        {
            _reqDefService = reqDefService;
        }

        [HttpGet]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Get()
        {
            var reqDefs = await _reqDefService.GetAllAsync();
            var reqDefResponseDto = reqDefs.Items.Select(rd =>
                new RequestDefinitionResponseDto
                {
                    Id = rd.Id,
                    BillingCode = rd.BillingCode,
                    DiagnoseRule = rd.DiagnoseRule,
                    CumulationRule = rd.CumulationRule
                }).OrderBy(rd => rd.BillingCode);

            return Ok(reqDefResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Get(int id)
        {
            var reqDef = await _reqDefService.GetByIdAsync(id);

            if (!reqDef.IsSuccess) { return BadRequest(reqDef.ValidationErrors); }
            
            RequestDefinitionResponseDto reqDefResponseDto = new()
            {
                BillingCode = reqDef.Items.First().BillingCode,
                DiagnoseRule = reqDef.Items.First().DiagnoseRule,
                CumulationRule = reqDef.Items.First().CumulationRule
            };

            return Ok(reqDefResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add(RequestDefinitionAddRequestDto reqDefAddDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _reqDefService.AddAsync(
                reqDefAddDto.BillingCode,
                reqDefAddDto.DiagnoseRule,
                reqDefAddDto.CumulationRule);

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Aanvraagdefinitie werd toegevoegd!");
        }

        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update(RequestDefinitionUpdateRequestDto reqDefUpdateDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _reqDefService.UpdateAsync(
                reqDefUpdateDto.Id,
                reqDefUpdateDto.RequestDefinition.BillingCode,
                reqDefUpdateDto.RequestDefinition.DiagnoseRule,
                reqDefUpdateDto.RequestDefinition.CumulationRule);

            if (!result.IsSuccess) {  return BadRequest(result); }

            return Ok("Aanvraagdefinitie werd aangepast!");
        }

        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var reqDef = await _reqDefService.GetByIdAsync(id);

            if (!reqDef.IsSuccess) { return BadRequest(reqDef.ValidationErrors); }

            await _reqDefService.DeleteAsync(id);
            return Ok("Aanvraagdefinitie werd verwijderd!");
        }
    }
}
