using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ICaseTypeService
    {
        Task<IEnumerable<CaseTypeDTO>?> GetAll();
        Task<CaseTypeDTO?> GetById(int id);
        Task<IEnumerable<CaseTypeDTO>?> GetByNameAndNotById(string name, int id);
        Task<CaseTypeDTO?> GetByName(string name);
        Task<CaseTypeDTO?> Create(CaseTypeDTO CaseTypeDTO);
        Task Update(CaseTypeDTO CaseTypeDTO);
        Task Delete(int id);
    }
}
