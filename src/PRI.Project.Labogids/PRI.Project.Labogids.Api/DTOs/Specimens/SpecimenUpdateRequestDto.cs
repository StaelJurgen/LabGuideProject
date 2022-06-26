using System.Collections.Generic;

namespace PRI.Project.Labogids.Api.DTOs.Specimens
{
    public class SpecimenUpdateRequestDto
    {
        public int Id { get; set; }
        public SpecimenAddRequestDto Specimen { get; set; }
    }
}
