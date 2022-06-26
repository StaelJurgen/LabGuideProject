using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.Laboratories
{
    public class LaboratoryAddRequestDto
    {
        [Required(ErrorMessage = "Gelieve een naam in te vullen a.u.b.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gelieve een geldig adres in te vullen a.u.b.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Gelieve een postcode in te vullen a.u.b.")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Gelieve een stad in te vullen a.u.b.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Gelieve een land in te vullen a.u.b.")]
        public string Country { get; set; }

        //public IEnumerable<int> Properties { get; set; }

    }
}
