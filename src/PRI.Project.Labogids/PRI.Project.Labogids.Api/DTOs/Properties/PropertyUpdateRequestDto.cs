using PRI.Project.Labogids.Core.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.Properties
{
    public class PropertyUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide an {0}.")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please provide a {0}.")]
        public string Name { get; set; }
        public string Synonym { get; set; }
        public int SpecimenId { get; set; }
        public IEnumerable<int> StorageConditions { get; set; }
        public int LaboratoryId { get; set; }
        public string RequestCode { get; set; }
        public int RequestDefinitionId { get; set; }
        public int TurnAroundTime { get; set; }
        public TimeReference TimePeriod { get; set; }
        public IEnumerable<int> ReferenceValues { get; set; }
    }
}
