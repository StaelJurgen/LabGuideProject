namespace PRI.Project.Labogids.Api.DTOs.RequestDefinitions
{
    public class RequestDefinitionResponseDto : BaseResponseDto
    {
        public int BillingCode { get; set; }
        public string DiagnoseRule { get; set; }
        public string CumulationRule { get; set; }
    }
}
