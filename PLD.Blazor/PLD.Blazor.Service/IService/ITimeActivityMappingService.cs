using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface ITimeActivityMappingService
    {
        Task<IEnumerable<TimeActivityMappingDTO>> GetAll();
        Task<TimeActivityMappingDTO?> GetById(int id);

        Task<TimeActivityMappingDTO?> Create(TimeActivityMappingDTO timeActivityMappingDTO);

        Task Update(TimeActivityMappingDTO timeActivityMappingDTO);
        Task Delete(int id);
        Task<TimeActivityMappingDTO?> GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEnd(
            int carrierId, string carrierActivity,
            int policyYearStart,
            int policyYearEnd,
            string? carrierTime = null);
        Task<IEnumerable<TimeActivityMappingDTO>?> GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEndAndNotById(
            int carrierId, string carrierActivity,
            int policyYearStart,
            int policyYearEnd,
            int id,
            string? carrierTime = null);

    }
}
