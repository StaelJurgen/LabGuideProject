using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.RequestDefinitions
{
    public class RequestDefinitionUpdateRequestDto
    {
        [Required(ErrorMessage = "Geef een geldige aanvraagdefinitie op")]
        public int Id { get; set; }

        public RequestDefinitionAddRequestDto RequestDefinition { get; set; }
    }
}
