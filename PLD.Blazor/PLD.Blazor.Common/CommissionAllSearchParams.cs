using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Common
{
    public class CommissionAllSearchParams
    {
        public int? CarrierId { get; set; }
        public string? Policy { get; set; }
        public DateTime? TransDate { get; set; }
        public string? TransType { get; set; }
        public decimal? CommPremium { get; set; }
        public decimal? CommOverrideRate { get; set; }
        public decimal? CommOverridePayment { get; set; }
    }
}
