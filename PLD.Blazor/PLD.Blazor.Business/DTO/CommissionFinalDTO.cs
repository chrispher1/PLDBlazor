using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class CommissionFinalDTO
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Carrier field is required.")]
        public int CarrierId { get; set; }
        public CarrierDTO? Carrier { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Product field is required.")]
        public int ProductId { get; set; }

        public ProductDTO? Product { get; set; }

        [Required]
        public int? PolicyYear { get; set; }

        [Required]
        [StringLength(30)]
        public string? Policy { get; set; }

        [Required]
        public DateTime? TransDate { get; set; }

        [Required]
        public DateTime? CommEffectiveDate { get; set; }

        [Required]
        [StringLength(4)]
        public string? TransType { get; set; }
        public ActivityDTO? Activity { get; set; }

        [Required]
        public decimal? CommPremium { get; set; }

        [Required]
        [StringLength(5)]
        public string? CommPremiumMode { get; set; }
        public PremiumModeDTO? PremiumMode { get; set; }

        [Required]
        public decimal? CommOverrideRate { get; set; }

        [Required]
        public decimal? CommOverridePayment { get; set; }

        [Required]
        [StringLength(2)]
        public string? Compensable { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
