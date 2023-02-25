using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{    
    [Table("DMT_CARR")]
    public class Carrier
    {
        [Key]
        [Column("Carr_Id")]
        public int Id { get; set; }
        
        [Required]
        [Column("Carr_Cd")]
        [MaxLength(25)]
        public string CarrierCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

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
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<TimeActivityMapping>? TimeActivityMappings { get; set; }
        public virtual ICollection<CommissionError>? CommissionErrors { get; set; }
        public virtual ICollection<CommissionFinal>? CommissionFinals { get; set; }
    }
}
