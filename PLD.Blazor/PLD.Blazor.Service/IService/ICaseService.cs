using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLD.Blazor.Common;


namespace PLD.Blazor.Service.IService
{
    public interface ICaseService
    {
        Task<PagedList<CaseDTO>> GetAll(GridParams gridParams, CaseAllSearchParams searchParams, string? sortParams = null);
        Task<PagedList<CaseDTO>> GetForApproval(GridParams gridParams, CaseForApprovalSearchParams searchParams, string? sortParams = null);
        Task<PagedList<CaseDTO>> GetComplete(GridParams gridParams, CaseCompleteSearchParams searchParams, string? sortParams = null);

        Task<CaseDTO?> GetById(int id);
        Task<CaseDTO?> Create(CaseDTO caseDTO);
        Task Update(CaseDTO caseDTO);
        Task Delete(int id);
    }
}
