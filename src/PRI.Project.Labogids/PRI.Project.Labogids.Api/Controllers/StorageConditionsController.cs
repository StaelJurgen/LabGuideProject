using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Labogids.Api.DTOs.StorageConditions;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageConditionsController : Controller
    {
        private readonly IStorageConditionService _stoConService;
        public StorageConditionsController(IStorageConditionService stoConService)
        {
            _stoConService = stoConService;
        }

        [HttpGet]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Get()
        {
            var stoCons = await _stoConService.GetAllAsync();
            var stoConResponseDto = stoCons.Items.Select(s =>
                new StorageConditionResponseDto
                {
                    Id = s.Id,
                    Temperature = s.Temperature,
                    TimePeriod = s.TimePeriod,
                    TimeReference = s.TimeReference,
                    Properties = s.Properties?.Select(p => p.Name)
                });

            return Ok(stoConResponseDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var stoCon = await _stoConService.GetByIdAsync(id);
            
            if (!stoCon.IsSuccess) { return BadRequest(stoCon.ValidationErrors); }

            StorageConditionResponseDto stoConResponseDto = new()
            {
                Temperature = stoCon.Items.First().Temperature,
                TimePeriod = stoCon.Items.First().TimePeriod,
                TimeReference = stoCon.Items.First().TimeReference,
                Properties = stoCon.Items.First().Properties
                    .Select(pr => pr.Name)
            };

            return Ok(stoConResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Add(StorageConditionAddRequestDto stoConAddRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _stoConService.AddAsync(
                stoConAddRequestDto.Temperature,
                stoConAddRequestDto.TimePeriod,
                stoConAddRequestDto.TimeReference,
                stoConAddRequestDto.Properties);

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Bewaarconditie werd toegevoegd!");
        }

        [HttpPut]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> Update(StorageConditionUpdateRequestDto stoConUpdateRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _stoConService.UpdateAsync(
                stoConUpdateRequestDto.Id,
                stoConUpdateRequestDto.StorageCondition.Temperature,
                stoConUpdateRequestDto.StorageCondition.TimePeriod,
                stoConUpdateRequestDto.StorageCondition.TimeReference,
                stoConUpdateRequestDto.StorageCondition.Properties
                );

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Bewaarconditie werd aangepast!");
        }

        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var stoCon = await _stoConService.GetByIdAsync(id);

            if (!stoCon.IsSuccess) { return BadRequest(stoCon.ValidationErrors); }

            await _stoConService.DeleteAsync(id);
            return Ok("Bewaarconditie werd verwijderd!");
        }
    }
}
