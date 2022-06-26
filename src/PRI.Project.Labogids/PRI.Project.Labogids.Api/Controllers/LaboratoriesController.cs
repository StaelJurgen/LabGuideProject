using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Labogids.Api.DTOs.Laboratories;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoriesController : ControllerBase
    {
        private readonly ILaboratoryService _laboratoryService;

        public LaboratoriesController(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        [HttpGet]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Get()
        {
            var laboratories = await _laboratoryService.GetAllAsync();
            var laboratoryResponseDto = laboratories.Items.Select(l =>
                new LaboratoryResponseDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    Address = l.Address,
                    PostalCode = l.PostalCode,
                    City = l.City,
                    Country = l.Country,
                    Properties = l.Properties.Select(pr => pr.Name)
                }).OrderBy(l => l.Name);

            return Ok(laboratoryResponseDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var laboratory = await _laboratoryService.GetByIdAsync(id);

            if (!laboratory.IsSuccess) { return BadRequest(laboratory.ValidationErrors); }

            LaboratoryResponseDto laboratoryResponseDto = new()
            {
                Id = laboratory.Items.First().Id,
                Name = laboratory.Items.First().Name,
                Address = laboratory.Items.First().Address,
                PostalCode = laboratory.Items.First().PostalCode,
                City = laboratory.Items.First().City,
                Country = laboratory.Items.First().Country,
                //Properties = laboratory.Items.First().Properties
                //    .Select(pr => pr.Name),
            };

            return Ok(laboratoryResponseDto);
        }

        [HttpPost]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Add([FromForm]LaboratoryAddRequestDto laboratoryAddRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var result = await _laboratoryService.AddAsync(
                laboratoryAddRequestDto.Name,
                laboratoryAddRequestDto.Address,
                laboratoryAddRequestDto.PostalCode,
                laboratoryAddRequestDto.City,
                laboratoryAddRequestDto.Country//,
                //laboratoryAddRequestDto.Properties
                );

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Laboratorium werd toegevoegd!");
        }

        [HttpPut]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Update([FromForm]LaboratoryUpdateRequestDto laboratoryUpdateRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _laboratoryService.UpdateAsync(
                laboratoryUpdateRequestDto.Id,
               laboratoryUpdateRequestDto.Laboratory.Name,
               laboratoryUpdateRequestDto.Laboratory.Address,
               laboratoryUpdateRequestDto.Laboratory.PostalCode,
               laboratoryUpdateRequestDto.Laboratory.City,
               laboratoryUpdateRequestDto.Laboratory.Country
               );

            if (!result.IsSuccess || !ModelState.IsValid) { return BadRequest(result.ValidationErrors); }

            return Ok("Laboratorium werd aangepast!");
        }

        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var laboratory = await _laboratoryService.GetByIdAsync(id);

            if (!laboratory.IsSuccess) { return BadRequest(laboratory.ValidationErrors); }

            await _laboratoryService.DeleteAsync(id);
            return Ok("Laboratorium werd verwijderd!");
        }
    }
}
