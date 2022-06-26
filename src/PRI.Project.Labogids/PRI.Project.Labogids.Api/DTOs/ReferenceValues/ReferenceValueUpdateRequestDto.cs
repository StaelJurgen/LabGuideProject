using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.ReferenceValues
{
    public class ReferenceValueUpdateRequestDto
    {
        [Required(ErrorMessage = "Geef een geldige referentiewaarde op")]
        public int Id { get; set; }

        public ReferenceValueAddRequestDto ReferenceValue { get; set; }
    }
}
