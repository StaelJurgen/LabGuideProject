namespace PRI.Project.Labogids.Core.Entities
{
    public class RequestDefinition : BaseEntity
    {
        public int BillingCode { get; set; }
        public string DiagnoseRule { get; set; }
        public string CumulationRule { get; set; }
    }
}
