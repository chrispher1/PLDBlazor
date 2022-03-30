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
        [Column("CARR_ID")]
        public int Id { get; set; }
        
        [Required]
        [Column("CARR_CD")]
        [MaxLength(25)]
        public string CarrierCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("CRT_DT")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("CRT_BY")]
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        
        [Column("MOD_DT")]
        public DateTime? ModifiedDate { get; set; }

        [Column("MOD_BY")]
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }

    }
}
