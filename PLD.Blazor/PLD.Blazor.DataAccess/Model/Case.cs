using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_CASE")]
    public class Case
    {
        [Key]
        [Column("Case_Id")]
        public int Id { get; set; }

        [Column("Carr_Id")]
        public int? CarrierId { get; set; }

        public Carrier Carrier { get; set; }

        [Column("Policy_Number")]
        [StringLength(30)]
        public string? Policy { get; set; }

        [Column("Case_Type")]
        [StringLength(15)]
        public string? CaseType { get; set; }

        [Column("Prod_Id")]
        public int? ProductId { get; set; }

        public Product Product { get; set; }

        [Column("Prod_Typ_Id")]        
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        [Column("Prim_Ins_FirstName")]
        [StringLength(30)]
        public string? ClientFirstName { get;set; }

        [Column("Prim_Ins_LastName")]
        [StringLength(30)]
        public string? ClientLastName { get; set; }

        [Column("Status")]
        [StringLength(50)]
        public string? Status { get; set; }

        [Column("Issue_State")]
        [StringLength(2)]
        public string? IssueState { get; set; }

        [Column("Issue_Age")]
        public int? IssueAge { get; set; }

        [Column("App_Receipt_Date")]
        public DateTime? AppReceiptDate { get; set; }

        [Column("Issue_Date")]
        public DateTime? IssueDate { get; set; }

        [Column("Policy_Eff_Date")]
        public DateTime? EffectiveDate { get; set; }

        [Column("Policy_Placed_Date")]
        public DateTime? PlacementDate { get; set; }

        [Column("Face_Amt",TypeName ="numeric(16,2)")]
        public Decimal? FaceAmount { get; set; }

        [Column("Modal_Premium", TypeName = "numeric(16,2)")]
        public Decimal? ModalPremium { get; set; }

        [Column("Premium_Mode")]
        [StringLength(50)]
        public string? PremiumMode { get; set; }

        [Column("Annualized_Premium", TypeName = "numeric(16,2)")]
        public Decimal? AnnualizedPremium { get; set; }

        [Column("Target_Prem_Amt", TypeName = "numeric(16,2)")]
        public Decimal? TargetPremium { get; set; }

        [Column("Excess_Premium", TypeName = "numeric(16,2)")]
        public Decimal? ExcessPremium { get; set; }

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
