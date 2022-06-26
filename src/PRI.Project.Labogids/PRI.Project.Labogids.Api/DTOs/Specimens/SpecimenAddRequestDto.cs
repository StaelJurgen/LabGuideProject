using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.Specimens
{
    public class SpecimenAddRequestDto
    {
        [Required(ErrorMessage="Gelieve een geldige naam in te geven.")]
        public string Name { get; set; }

        public IFormFile Image { get; set; }
        //public IEnumerable<int> Properties { get; set; }
    }
}
