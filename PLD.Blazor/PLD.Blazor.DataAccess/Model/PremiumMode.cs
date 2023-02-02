using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_PREM_MODE_CD")]
    public class PremiumMode
    {
        [Key]
        [Column("Prem_Mode_Cd")]
        [StringLength(5)]
        public string Code { get; set; }

        [Required]
        [StringLength(25)]
        [Column("Desc_Txt")]
        public string Description { get; set; }

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
        public ICollection<CommissionError>? CommissionErrors { get; set; }
    }
}
