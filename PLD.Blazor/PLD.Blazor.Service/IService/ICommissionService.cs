using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICommissionService
    {
        Task<PagedList<CommissionDTO>?> GetAll(GridParams gridParams, CommissionAllSearchParams searchParams, string? sortParams = null);
    }
}
