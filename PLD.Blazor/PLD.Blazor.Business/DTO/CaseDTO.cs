using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class CaseDTO
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Carrier field is required.")]
        public int CarrierId { get; set; }
        public CarrierDTO? Carrier { get; set; }

        [Required]
        [StringLength(30)]
        public string? Policy { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Case Type field is required.")]
        public int TypeId { get; set; }
        public CaseTypeDTO? CaseType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Product field is required.")]
        public int ProductId { get; set; }
        public ProductDTO? Product { get; set; }
        public int ProductTypeId { get; set; }
        public ProductTypeDTO? ProductType { get; set; }

        [Column("Prim_Ins_FirstName")]
        [StringLength(30)]
        public string? ClientFirstName { get; set; }

        [Column("Prim_Ins_LastName")]
        [StringLength(30)]
        public string? ClientLastName { get; set; }        

        [Column("Status_Id")]
        [Range(1, int.MaxValue, ErrorMessage = "The Case Status field is required.")]
        public int StatusId { get; set; }

        public CaseStatusDTO? CaseStatus { get; set; }

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

        [Column("Face_Amt", TypeName = "numeric(16,2)")]
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

        public DateTime CreatedDate { get; set; }                
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }                
        public string? ModifiedBy { get; set; }

    }
}
