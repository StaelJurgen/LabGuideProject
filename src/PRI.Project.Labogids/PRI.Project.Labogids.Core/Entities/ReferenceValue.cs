using PRI.Project.Labogids.Core.Enumerations;

namespace PRI.Project.Labogids.Core.Entities
{
    public class ReferenceValue : BaseEntity
    {
        public double? MinimumValue { get; set; } //e.g. 1.6, 2.8
        public double? MaximumValue { get; set; } //e.G. 10.2, 11.3
        public string StringValue { get; set; } // e.g. "Negatief", "Positief"
        public string Unit { get; set; }
        public string Sex { get; set; } // M, F
        public int? MaximalAge { get; set; } // value
        public TimeReference? Period { get; set; } //days, weeks, months, ...
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
