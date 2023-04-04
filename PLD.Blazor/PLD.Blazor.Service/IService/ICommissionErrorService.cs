using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICommissionErrorService
    {
        Task<IEnumerable<CommissionErrorDTO>> GetAll();
        Task<CommissionErrorDTO?> GetById(int id);
        Task<CommissionErrorDTO?> Create(CommissionErrorDTO commissionErrorDTO);
        Task Update(CommissionErrorDTO commissionErrorDTO);
        Task Delete(int id);
    }
}
