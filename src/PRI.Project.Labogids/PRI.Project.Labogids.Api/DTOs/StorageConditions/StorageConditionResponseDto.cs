using PRI.Project.Labogids.Core.Enumerations;
using System.Collections.Generic;

namespace PRI.Project.Labogids.Api.DTOs.StorageConditions
{
    public class StorageConditionResponseDto : BaseResponseDto
    {
        public string Temperature { get; set; }
        public int TimePeriod { get; set; }
        public TimeReference TimeReference { get; set; }
        public IEnumerable<string> Properties { get; set; }
    }
}
