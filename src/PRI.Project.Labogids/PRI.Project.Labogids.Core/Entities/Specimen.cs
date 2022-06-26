using System.Collections.Generic;

namespace PRI.Project.Labogids.Core.Entities
{
    public class Specimen : BaseEntity
    {
        public string Image { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
