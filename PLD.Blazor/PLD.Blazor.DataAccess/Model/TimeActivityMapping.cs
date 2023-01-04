using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_TM_ACT_MAP")]
    public class TimeActivityMapping
    {
        [Key]
        [Column("Time_Activity_Id")]
        public int Id { get; set; }
                
        [Column("Carr_Id")]
        [Required]
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }


        [Column("Src_Tm_Cd")]
        [MaxLength(5)]
        public string? CarrierTime { get; set; }

        [Column("Src_Act_Cd")]
        [MaxLength(5)]
        [Required]
        public string? CarrierActivity { get; set; }

        [Column("Yr_Start_Num")]
        [Required]
        public int PolicyYearStart { get; set; }

        [Column("Yr_End_Num")]
        [Required]
        public int PolicyYearEnd{ get; set; }

        [Column("Tm_Cd")]
        [MaxLength(4)]
        public string? TimeCode { get; set; }

        [Column("Act_Cd")]
        [MaxLength(4)]
        [Required]
        public string TransactionType { get; set; }
        public Activity Activity { get; set; }

        [Column("Comp_Ind")]
        [MaxLength(2)]
        [Required]
        public string CompensableIndicator { get; set; }

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
