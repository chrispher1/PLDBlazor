using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class PaymentDTO
    {        
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Carrier field is required.")]
        public int CarrierId { get; set; }

        public CarrierDTO? Carrier { get; set; }

        [Required(ErrorMessage ="Please enter Payment Date")]       
        public DateTime? PaymentDate { get; set; }
                
        [MaxLength(20)]
        public string? CheckWireNumber { get; set; }
                
        public DateTime? DepositDate { get; set; }

        [Required(ErrorMessage ="Please enter EFT Override Amount")]        
        public decimal? EFTOverrideAmount { get; set; }
                
        public DateTime CreatedDate { get; set; }
                
        [MaxLength(100)]
        public string CreatedBy { get; set; }
                
        public DateTime? ModifiedDate { get; set; }
                
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
    }

    //class A2
    //{
    //    //public virtual void F2<T>(T? t) where T : struct { }
    //    public virtual void F2<T>(T? t) { }
    //}

    //class B2 : A2
    //{
    //    //public override void F2<T>(T? t) /*where T : struct*/ { }
    //    public override void F2<T>(T? t) where T : default { }
    //    //public override void F2<T>(T? t) where T : default { }

    //}

    //class C2
    //{
    //    public void Test()
    //    {
    //        //B2 b2 = new B2();
    //        //b2.F2(2);
    //        //int? c = null;
    //        //int d = 25;
    //        //PaymentDTO obj= new PaymentDTO();

    //        //b2.F2(25);
    //        //b2.F2(c);
    //        //b2.F2(obj);
    //    }
    //}

}
