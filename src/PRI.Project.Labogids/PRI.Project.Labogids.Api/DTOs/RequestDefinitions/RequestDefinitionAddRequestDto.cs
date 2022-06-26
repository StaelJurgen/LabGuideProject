using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.RequestDefinitions
{
    public class RequestDefinitionAddRequestDto
    {
        [Required(ErrorMessage = "Geef een verrekencode in.")]
        public int BillingCode { get; set; }

        public string DiagnoseRule { get; set; }
        public string CumulationRule { get; set; }
    }
}
