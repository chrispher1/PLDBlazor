using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICaseService
    {
        Task<IEnumerable<CaseDTO>> GetAll();
        Task<CaseDTO?> GetById(int id);
        Task<CaseDTO?> Create(CaseDTO caseDTO);
        Task Update(CaseDTO caseDTO);
        Task Delete(int id);
    }
}
