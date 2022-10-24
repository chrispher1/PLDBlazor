using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Common
{
    public class APISettings
    {
        public string SecretKey { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
    }
}
