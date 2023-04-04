using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class StateCodeDTO
    {

        #region Properties

        [Required]
        [Display(Name = "Code")]
        [MaxLength(3)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name")]
        public string Name { get; set; }
                
        public DateTime CreatedDate { get; set; }
        
        public string CreatedBy { get; set; }
                
        public DateTime? ModifiedDate { get; set; }
                
        public string? ModifiedBy { get; set; }

        #endregion
    }
}
