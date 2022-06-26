using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Services.Models
{
    public class AuthenticateResultModel
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
