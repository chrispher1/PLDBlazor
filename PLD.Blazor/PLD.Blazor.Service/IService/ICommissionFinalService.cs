using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICommissionFinalService
    {
        Task<IEnumerable<CommissionFinalDTO>> GetAll();
        Task<CommissionFinalDTO> GetById(int id);
        Task<CommissionFinalDTO> Create(CommissionFinalDTO commissionFinalDTO);
        Task Update(CommissionFinalDTO commissionFinalDTO);
        Task Delete(int id);
    }
}
