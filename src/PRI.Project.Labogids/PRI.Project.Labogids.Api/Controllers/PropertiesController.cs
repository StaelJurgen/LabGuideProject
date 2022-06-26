using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Labogids.Api.DTOs.Properties;
using PRI.Project.Labogids.Api.DTOs.ReferenceValues;
using PRI.Project.Labogids.Api.DTOs.Specimens;
using PRI.Project.Labogids.Api.DTOs.StorageConditions;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var properties = await _propertyService.GetAllAsync();
            var propertyResponseDto = properties.Items.Select(pr =>
               new PropertyResponseDto
               {
                   Id = pr.Id,
                   Name = pr.Name,
                   Synonym = pr.Synonym,
                   LaboratoryName = pr.Laboratory.Name,
               }).OrderBy(p => p.Name);

            return Ok(propertyResponseDto);
            //return Ok(properties);
        }

        [HttpGet("Laboratory/{labId}")]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Laboratory(int labId)
        {
            var properties = await _propertyService.GetByLaboratoryIdAsync(labId);

            var propertyResponseDto = properties.Items.Select(pr =>
                new PropertyResponseDto
                {
                    Id = pr.Id,
                    Name = pr.Name,
                    //Synonym = pr.Synonym,
                    //LaboratoryName = pr.Laboratory.Name
                });

            return Ok(propertyResponseDto);
        }

        [HttpGet("Specimen/{specId}")]
        [Authorize(Policy ="user")]
        public async Task<IActionResult> Specimen(int specId)
        {
            var properties = await _propertyService.GetBySpecimenIdAsync(specId);

            var propertyResponseDto = properties.Items.Select(pr =>
                new PropertyResponseDto
                {
                    Id = pr.Id,
                    Name = pr.Name,
                    Synonym = pr.Synonym,
                    SpecimenName = pr.Specimen.Name,
                });

            return Ok(propertyResponseDto);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Id(int id)
        {
            var property = await _propertyService.GetByIdAsync(id);

            if (!property.IsSuccess) { return BadRequest(property.ValidationErrors); }

            var propertyResponseDto = new PropertyResponseDto
            {
                Id = property.Items.First().Id,
                Name = property.Items.First().Name,
                Synonym = property.Items.First().Synonym,
                SpecimenName = property.Items.FirstOrDefault().Specimen.Name,
                LaboratoryName = property.Items.First().Laboratory.Name,
                StorageConditions = property.Items.FirstOrDefault().StorageConditions.Select(sc => new StorageConditionResponseDto
                {
                    Temperature = sc.Temperature,
                    TimePeriod = sc.TimePeriod,
                    TimeReference = sc.TimeReference,
                }),
                RequestCode = property.Items.First().RequestCode,
                ReferenceValues = property.Items.FirstOrDefault().ReferenceValues.Select(rv => new ReferenceValueResponseDto
                {
                    MaximalAge = rv.MaximalAge,
                    MinimumValue = rv.MinimumValue,
                    MaximumValue = rv.MaximumValue,
                    Period = rv.Period.ToString(),
                    Sex = rv.Sex,
                    StringValue = rv.StringValue,
                    Unit = rv.Unit,
                }),
            };

            return Ok(propertyResponseDto);
        }

        [HttpGet("{needle}")]
        public async Task<IActionResult> SearchAsync(string needle)
        {
            var properties = await _propertyService.SearchAsync(needle);

            var propertyResponseDto = properties.Items.Select(pr => new PropertyResponseDto
            {
                Id = pr.Id,
                Name = pr.Name,
                Synonym = pr.Synonym,
                Specimen = pr.Specimen,
            });
            
            return Ok(propertyResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add([FromForm]PropertyAddRequestDto propertyAddRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _propertyService.AddAsync(
                propertyAddRequestDto.Name,
                propertyAddRequestDto.Synonym,
                propertyAddRequestDto.SpecimenId,
                //propertyAddRequestDto.StorageConditions,
                propertyAddRequestDto.LaboratoryId,
                propertyAddRequestDto.RequestCode,
                propertyAddRequestDto.RequestDefinitionId,
                propertyAddRequestDto.TurnAroundTime,
                propertyAddRequestDto.TimePeriod/*,
                propertyAddRequestDto.ReferenceValues*/);

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); 
            }
            return Ok(result.Items);
        }

        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update(PropertyUpdateRequestDto propertyUpdateRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _propertyService.UpdateAsync(
                propertyUpdateRequestDto.Id,
                propertyUpdateRequestDto.Name,
                propertyUpdateRequestDto.Synonym,
                propertyUpdateRequestDto.SpecimenId,
                propertyUpdateRequestDto.StorageConditions,
                propertyUpdateRequestDto.LaboratoryId,
                propertyUpdateRequestDto.RequestCode,
                propertyUpdateRequestDto.RequestDefinitionId,
                propertyUpdateRequestDto.TurnAroundTime,
                propertyUpdateRequestDto.TimePeriod,
                propertyUpdateRequestDto.ReferenceValues
                );

            if (!result.IsSuccess) { return BadRequest(result.ValidationErrors); }

            return Ok("Bepaling werd aangepast!");
        }

        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _propertyService.GetByIdAsync(id);

            if (!property.IsSuccess) { return BadRequest(property.ValidationErrors); }

            await _propertyService.DeleteAsync(id);
            return Ok("Bepaling werd verwijderd!");
        }
    }
}
