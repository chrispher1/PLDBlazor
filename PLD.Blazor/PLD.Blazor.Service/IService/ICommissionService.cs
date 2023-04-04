using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICommissionService
    {
        Task<IEnumerable<CommissionDTO>?> GetAll();
    }
}
