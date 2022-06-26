using PRI.Project.Labogids.Core.Enumerations;
using System.Collections.Generic;

namespace PRI.Project.Labogids.Core.Entities
{
    public class StorageCondition : BaseEntity
    {
        public string Temperature { get; set; }
        public int TimePeriod { get; set; }
        public TimeReference TimeReference { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
