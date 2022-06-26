using System.Collections.Generic;

namespace PRI.Project.Labogids.Api.DTOs.Specimens
{
    public class SpecimenResponseDto : BaseResponseDto
    {
        public string Image { get; set; }
        public IEnumerable<string> Properties { get; set; }
    }
}
