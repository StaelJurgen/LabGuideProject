using PRI.Project.Labogids.Core.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.StorageConditions
{
    public class StorageConditionAddRequestDto
    {
        [Required(ErrorMessage = "Geef een geldige temperatuur in.")]
        public string Temperature { get; set; }

        [Required(ErrorMessage = "Geef een geldige tijdsperiode in.")]
        public int TimePeriod { get; set; }

        [Required(ErrorMessage = "Geef een geldige tijdseenheid in.")]
        public TimeReference TimeReference { get; set; }

        public IEnumerable<int> Properties { get; set; }
    }
}
