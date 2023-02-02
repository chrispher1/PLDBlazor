using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_COMM_ERR")]
    public class CommissionError
    {
        [Key]
        [Column("Comm_Id")]
        public int Id { get; set; }
        
        [Column("Carr_Id")]
        public int? CarrierId { get; set; }
        public Carrier Carrier { get; set; }

        [Column("Prod_Id")]
        public int? ProductId { get; set; }

        public Product Product { get; set; }

        [Column("Yr_Num")]
        public int? PolicyYear { get; set; }

        [Column("Pol_Num")]
        [StringLength(30)]
        public string? Policy { get; set; }

        [Column("Trans_Dt")]
        public DateTime? TransDate { get; set; }

        [Column("Pol_Dt")]
        public DateTime? CommEffectiveDate { get; set;}

        [Column("Act_Cd")]
        [StringLength(4)]
        public string? TransType { get; set; }
        public Activity Activity { get; set; }

        [Column("Comm_Prem_Amt",TypeName ="numeric(16, 2)")]
        public decimal? CommPremium { get; set; }

        [Column("Prem_Mode_Cd")]
        [StringLength(5)]
        public string? CommPremiumMode { get; set;}
        public PremiumMode PremiumMode { get; set; }

        [Column("Comm_Rt",TypeName ="decimal(12, 9)")]
        public decimal? CommOverrideRate { get; set; }

        [Column("Comm_Amt", TypeName="numeric(16, 2)")]
        public decimal? CommOverridePayment { get; set; }

        [Column("Comp_Ind")]
        [StringLength(2)]
        public string? Compensable { get; set; }

        [Required]
        [Column("Crt_Dt")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("Crt_By")]
        [MaxLength(100)]
        public string? CreatedBy { get; set; }

        [Column("Mod_Dt")]
        public DateTime? ModifiedDate { get; set; }

        [Column("Mod_By")]
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
