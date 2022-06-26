using PRI.Project.Labogids.Core.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.Properties
{
    public class PropertyAddRequestDto
    {
        [Required(ErrorMessage = "Gelieve een naam toe te wijzen.")]
        public string Name { get; set; }

        public string Synonym { get; set; }

        [Required(ErrorMessage="Gelieve een staaltype toe te wijzen.")]
        public int SpecimenId { get; set; }
        
        //public IEnumerable<int> StorageConditions { get; set; }

        [Required(ErrorMessage = "Gelieve een laboratorium toe te wijzen.")]
        public int LaboratoryId { get; set; }

        [Required(ErrorMessage = "Gelieve een aanvraagcode in te vullen.")]
        public string RequestCode { get; set; }

        public int RequestDefinitionId { get; set; }
        public int TurnAroundTime { get; set; }
        public TimeReference TimePeriod { get; set; }
        //public IEnumerable<int> ReferenceValues { get; set; }
    }
}
