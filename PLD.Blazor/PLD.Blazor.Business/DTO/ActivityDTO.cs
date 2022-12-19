using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class ActivityDTO
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }                
        public DateTime? ModifiedDate { get; set; }                
        public string? ModifiedBy { get; set; }
    }
}
