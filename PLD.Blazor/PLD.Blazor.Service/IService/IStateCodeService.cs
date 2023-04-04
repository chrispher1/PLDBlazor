using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface IStateCodeService
    {
        Task<IEnumerable<StateCodeDTO>> GetAll();
        Task<StateCodeDTO?> GetByCode(string code);

        Task<StateCodeDTO?> Create(StateCodeDTO stateCode);

        Task Update(StateCodeDTO stateCode);
        Task Delete(string code);
    }
}
