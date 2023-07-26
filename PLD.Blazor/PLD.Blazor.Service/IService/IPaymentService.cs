using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface IPaymentService
    {
        Task<PagedList<PaymentDTO>?> GetAll(GridParams gridParams, PaymentSearchParams searchParams, string? sortParams = null);
        Task<PaymentDTO?> Create(PaymentDTO payment);        
        Task<PaymentDTO?> GetById(int id);
        Task Update(PaymentDTO payment);
        Task Delete(int id);
    }
}
