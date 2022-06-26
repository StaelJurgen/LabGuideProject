using PRI.Project.Labogids.Core.Enumerations;

namespace PRI.Project.Labogids.Api.DTOs.ReferenceValues
{
    public class ReferenceValueAddRequestDto
    {
        public double? MinimumValue { get; set; }
        public double? MaximumValue { get; set; } 
        public string StringValue { get; set; }
        public string Unit { get; set; }
        public string Sex { get; set; } 
        public int? MaximalAge { get; set; } 
        public TimeReference? Period { get; set; } 
        public int PropertyId { get; set; }
    }
}
