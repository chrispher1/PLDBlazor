using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class ProductDTO
    {   
        public int Id { get; set; }
            
        [Range(1, int.MaxValue,ErrorMessage ="Select a carrier")]
        public int CarrierId { get; set; }
        public CarrierDTO? Carrier { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a product type")]
        public int ProductTypeId { get; set; }
        public ProductTypeDTO? ProductType { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name="Product Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [MaxLength(6)]        
        public string? SalesLinkCarrierId { get; set; }

        [Required]
        public bool ProductRateIndicator { get; set; }

        [Required]
        public bool ProductTypeRateIndicator { get; set; }
                      
        public DateTime CreatedDate { get; set; }
                    
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        
        public DateTime? ModifiedDate { get; set; }
        
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
