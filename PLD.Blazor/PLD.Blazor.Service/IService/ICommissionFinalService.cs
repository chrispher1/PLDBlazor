using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICommissionFinalService
    {
        Task<PagedList<CommissionFinalDTO>> GetAll(GridParams gridParams, CommissionFinalSearchParams searchParams, string? sortParams = null);
        Task<CommissionFinalDTO?> GetById(int id);
        Task<CommissionFinalDTO?> Create(CommissionFinalDTO commissionFinalDTO);
        Task Update(CommissionFinalDTO commissionFinalDTO);
        Task Delete(int id);
    }
}
