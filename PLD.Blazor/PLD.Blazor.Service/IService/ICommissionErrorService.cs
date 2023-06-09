using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICommissionErrorService
    {
        Task<PagedList<CommissionErrorDTO>> GetAll(GridParams gridParams, CommissionErrorSearchParams searchParams, string? sortParams = null);
        Task<CommissionErrorDTO?> GetById(int id);
        Task<CommissionErrorDTO?> Create(CommissionErrorDTO commissionErrorDTO);
        Task Update(CommissionErrorDTO commissionErrorDTO);
        Task Delete(int id);        
    }
}
