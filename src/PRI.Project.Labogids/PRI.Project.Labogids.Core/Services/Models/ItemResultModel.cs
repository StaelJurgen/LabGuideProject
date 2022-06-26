using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Core.Services.Models
{
    public class ItemResultModel<T> where T : class
    {
        public IEnumerable<ValidationResult> ValidationErrors { get; set; }
        public IEnumerable<T> Items { get; set; }
        public bool IsSuccess { get; set; }
    }
}
