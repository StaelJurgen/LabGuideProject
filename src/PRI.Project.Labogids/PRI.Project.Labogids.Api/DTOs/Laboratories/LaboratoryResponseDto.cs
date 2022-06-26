using System.Collections.Generic;

namespace PRI.Project.Labogids.Api.DTOs.Laboratories
{
    public class LaboratoryResponseDto : BaseResponseDto
    {
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public IEnumerable<string> Properties { get; set; }
    }
}
