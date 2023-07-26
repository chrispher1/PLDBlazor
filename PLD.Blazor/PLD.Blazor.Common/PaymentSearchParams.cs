using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Common
{
    public class PaymentSearchParams
    {        
        public int? CarrierId { get; set; }
        public DateTime? PaymentDate { get; set; }                
        public string? CheckWireNumber { get; set; }
        public DateTime? DepositDate { get; set; }                
        public decimal? EFTOverrideAmount { get; set; }
        
    }
}
