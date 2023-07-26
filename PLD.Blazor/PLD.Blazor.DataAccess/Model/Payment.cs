using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_PAY")]
    public class Payment
    {
        [Key]
        [Column("Pay_Id")]
        public int Id { get; set; }

        [Column("Carr_Id")]
        [Required]
        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }

        [Required]
        [Column("Pay_Dt")]
        public DateTime PaymentDate { get; set; }
        
        [Column("Chk_Wire_Num")]
        [MaxLength(20)]
        public string? CheckWireNumber { get; set; }
                
        [Column("Dep_Dt")]
        public DateTime? DepositDate { get; set; }

        [Required]
        [Column("Eft_Ovr_Amt", TypeName = "numeric(16, 2)")]
        public decimal EFTOverrideAmount { get; set; }

        [Required]
        [Column("Crt_Dt")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("Crt_By")]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Column("Mod_Dt")]
        public DateTime? ModifiedDate { get; set; }

        [Column("Mod_By")]
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
