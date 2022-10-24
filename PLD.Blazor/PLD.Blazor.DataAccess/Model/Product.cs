using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_PROD")]
    public class Product
    {
        [Key]
        [Column("Prod_Id")]
        public int Id { get; set; }

        [Column("Carr_Id")]
        [Required]
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }

        [Column("Prod_Typ_Id")]
        [Required]        
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("Prod_Cd")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name")]
        public string Name { get; set; }
        
        [MaxLength(6)]
        [Column("SalesLink_Carrier_Id")]
        public string? SalesLinkCarrierId { get; set; }

        [Required]
        [Column("Prod_Rt_Ind")]
        public bool ProductRateIndicator { get; set; }

        [Required]
        [Column("Prod_Typ_Rt_Ind")]
        public bool ProductTypeRateIndicator { get; set; }

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
