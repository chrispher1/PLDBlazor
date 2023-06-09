using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class CarrierDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string? CarrierCode { get; set; }
        [Required]
        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        
        //public ICollection<ProductDTO>? Products { get; set; }
        //public ICollection<TimeActivityMappingDTO>? TimeActivityMappings { get; set; }
    }
}
