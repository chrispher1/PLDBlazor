using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICaseStatusService
    {
        Task<IEnumerable<CaseStatusDTO>?> GetAll();
        Task<CaseStatusDTO?> GetById(int id);
        Task<IEnumerable<CaseStatusDTO>?> GetByNameAndNotById(string name, int id);
        Task<CaseStatusDTO?> GetByName(string name);
        Task<CaseStatusDTO?> Create(CaseStatusDTO caseStatusDTO);
        Task Update(CaseStatusDTO caseStatusDTO);
        Task Delete(int id);
    }
}
