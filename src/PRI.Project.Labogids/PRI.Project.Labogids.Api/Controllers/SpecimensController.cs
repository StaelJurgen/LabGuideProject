using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Labogids.Api.DTOs.Specimens;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecimensController : Controller
    {
        private readonly ISpecimenService _specimenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SpecimensController(ISpecimenService specimenService, IHttpContextAccessor httpContextAccessor)
        {
            _specimenService = specimenService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Get()
        {
            var specimens = await _specimenService.GetAllAsync();
            var specimenResponseDto = specimens.Items.Select(s =>
                new SpecimenResponseDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Image = s.Image,
                    Properties = s.Properties?.Select(p => p.Name)
                }).OrderBy(s => s.Name);

            return Ok(specimenResponseDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //get the product
            var specimen = await _specimenService.GetByIdAsync(id);

            if (!specimen.IsSuccess) { return BadRequest(specimen.ValidationErrors); 
            }
            SpecimenResponseDto specimenResponseDto = new()
            {
                Id = specimen.Items.First().Id,
                Name = specimen.Items.First().Name,
                Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/Images/Specimen/{specimen.Items.First().Image}",
                Properties = specimen.Items.First().Properties
                    .Select(pr => pr.Name),
            };

            return Ok(specimenResponseDto);
        }

        [HttpPost]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Add([FromForm]SpecimenAddRequestDto specimenAddRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _specimenService.AddAsync(
                specimenAddRequestDto.Name,
                specimenAddRequestDto.Image//,
                //specimenAddRequestDto.Properties
                );

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Staaltype werd toegevoegd!");
        }

        [HttpPut]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Update([FromForm]SpecimenUpdateRequestDto specimenUpdateRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _specimenService.UpdateAsync(
               specimenUpdateRequestDto.Id,
               specimenUpdateRequestDto.Specimen.Name,
               specimenUpdateRequestDto.Specimen.Image//,
               //specimenUpdateRequestDto.Specimen.Properties
               );

            if (!result.IsSuccess || !ModelState.IsValid) { return BadRequest(result.ValidationErrors); }

            return Ok("Staaltype werd aangepast!");
        }

        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var specimen = await _specimenService.GetByIdAsync(id);

            if (!specimen.IsSuccess) { return BadRequest(specimen.ValidationErrors); }

            await _specimenService.DeleteAsync(id);
            return Ok("Staaltype werd verwijderd!");
        }
    }
}
