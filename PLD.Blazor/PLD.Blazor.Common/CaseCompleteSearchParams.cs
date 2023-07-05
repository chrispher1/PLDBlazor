using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Common
{
    public class CaseCompleteSearchParams
    {
        public int? CarrierId { get; set; }
        public string? Policy { get; set; }
        public int? StatusId { get; set; }
        public int? ProductTypeId { get; set; }
        public decimal? FaceAmount { get; set; }
        public decimal? AnnualizedPremium { get; set; }
        public decimal? TargetPremium { get; set; }
        public decimal? ModalPremium { get; set; }
        public DateTime? PlacementDate { get; set; }
        public int? CaseTypeId { get; set; }
        public int? ProductId { get; set; }
        public string? ClientFirstName { get; set; }
        public string? ClientLastName { get; set; }
    }
}
