using PRI.Project.Labogids.Core.Enumerations;
using System.Collections.Generic;

namespace PRI.Project.Labogids.Core.Entities
{
    public class Property : BaseEntity
    {
        public string Synonym { get; set; }
        public Specimen Specimen { get; set; }
        public int SpecimenId { get; set; }
        public ICollection<StorageCondition> StorageConditions { get; set; }
        public Laboratory Laboratory { get; set; }
        public int LaboratoryId { get; set; }
        public string RequestCode { get; set; }
        public RequestDefinition RequestDefinition { get; set; }
        public int RequestDefinitionId { get; set; }
        public int TurnAroundTime { get; set; }
        public TimeReference TimePeriod { get; set; }
        public ICollection<ReferenceValue> ReferenceValues { get; set; }
    }
}
