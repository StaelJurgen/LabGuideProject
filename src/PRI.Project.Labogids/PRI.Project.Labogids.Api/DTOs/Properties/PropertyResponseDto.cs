using PRI.Project.Labogids.Api.DTOs.ReferenceValues;
using PRI.Project.Labogids.Api.DTOs.RequestDefinitions;
using PRI.Project.Labogids.Api.DTOs.StorageConditions;
using PRI.Project.Labogids.Core.Entities;
using System.Collections.Generic;

namespace PRI.Project.Labogids.Api.DTOs.Properties
{
    public class PropertyResponseDto : BaseResponseDto
    {
        public string Synonym { get; set; }
        public string SpecimenName { get; set; }
        public Specimen Specimen { get; set; }
        public IEnumerable<StorageConditionResponseDto> StorageConditions { get; set; }
        public string LaboratoryName { get; set; }
        public Laboratory Laboratory { get; set; }
        public string RequestCode { get; set; }
        public IEnumerable<RequestDefinitionResponseDto> RequestDefinitions { get; set; }
        public int TurnAroundTime { get; set; }
        public string PropTimeReference { get; set; }
        public IEnumerable<ReferenceValueResponseDto> ReferenceValues { get; set; }
    }
}
