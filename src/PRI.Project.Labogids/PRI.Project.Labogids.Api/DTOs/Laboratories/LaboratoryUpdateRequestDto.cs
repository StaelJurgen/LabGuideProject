using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.Laboratories
{
    public class LaboratoryUpdateRequestDto
    {
        [Required(ErrorMessage = "Kies een geldig laboratorium!")]
        public int Id { get; set; }

        public LaboratoryAddRequestDto Laboratory { get; set; }
    }
}
