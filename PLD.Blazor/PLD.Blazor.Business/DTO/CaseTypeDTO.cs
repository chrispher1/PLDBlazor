using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class CaseTypeDTO
    {   
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]        
        public string Name { get; set; }
                
        public DateTime? CreatedDate { get; set; }
                
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
                
        public DateTime? ModifiedDate { get; set; }
                
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
