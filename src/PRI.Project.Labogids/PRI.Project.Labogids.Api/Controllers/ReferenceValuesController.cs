using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Labogids.Api.DTOs.ReferenceValues;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceValuesController : Controller
    {
        private readonly IReferenceValueService _refValService;

        public ReferenceValuesController(IReferenceValueService refValService)
        {
            _refValService = refValService;
        }

        [HttpGet]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Get()
        {
            var norms = await _refValService.GetAllAsync();
            var refValResponseDto = norms.Items.Select(r =>
            new ReferenceValueResponseDto
            {
                Id = r.Id,
                MaximalAge = r.MaximalAge,
                MinimumValue = r.MinimumValue,
                MaximumValue = r.MaximumValue,
                Period = r.Period.ToString(),
                Sex = r.Sex,
                StringValue = r.StringValue,
                Unit = r.Unit,
            });

            return Ok(refValResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Get(int id)
        {
            var norm = await _refValService.GetByIdAsync(id);

            if (!norm.IsSuccess) { return BadRequest(norm.ValidationErrors); }

            ReferenceValueResponseDto refValResponseDto = new()
            {
                Id = norm.Items.First().Id,
                MaximalAge = norm.Items.First().MaximalAge,
                MinimumValue = norm.Items.First().MinimumValue,
                MaximumValue = norm.Items.First().MaximumValue,
                Period = norm.Items.First().Period.ToString(),
                Sex = norm.Items.First().Sex,
                StringValue = norm.Items.First().StringValue,
                Unit = norm.Items.First().Unit,
            };

            return Ok(refValResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add([FromForm]ReferenceValueAddRequestDto refValAddRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _refValService.AddAsync(
                refValAddRequestDto.MinimumValue,
                refValAddRequestDto.MaximumValue,
                refValAddRequestDto.Unit,
                refValAddRequestDto.StringValue,
                refValAddRequestDto.Sex,
                refValAddRequestDto.MaximalAge,
                refValAddRequestDto.PropertyId,
                refValAddRequestDto.Period);

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Referentiewaarde werd toegevoegd!");
        }

        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update(ReferenceValueUpdateRequestDto refValUpdateRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _refValService.UpdateAsync(
                refValUpdateRequestDto.Id,
                refValUpdateRequestDto.ReferenceValue.MinimumValue,
                refValUpdateRequestDto.ReferenceValue.MaximumValue,
                refValUpdateRequestDto.ReferenceValue.Unit,
                refValUpdateRequestDto.ReferenceValue.StringValue,
                refValUpdateRequestDto.ReferenceValue.Sex,
                refValUpdateRequestDto.ReferenceValue.MaximalAge,
                //refValUpdateRequestDto.ReferenceValue.PropertyId,
                refValUpdateRequestDto.ReferenceValue.Period
                );

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Referentiewaarde werd aangepast!");
        }

        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var refVal = await _refValService.GetByIdAsync(id);

            if (!refVal.IsSuccess) { return BadRequest(refVal.ValidationErrors); }

            await _refValService.DeleteAsync(id);
            return Ok("Referentiewaarde werd verwijderd!");
        }
    }
}
