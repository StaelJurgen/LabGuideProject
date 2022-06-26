using System.Collections.Generic;

namespace PRI.Project.Labogids.Core.Entities
{
    public class Laboratory : BaseEntity
    {
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
