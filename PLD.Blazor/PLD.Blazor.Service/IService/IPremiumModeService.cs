using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{    
    public interface IPremiumModeService
    {
        Task<IEnumerable<PremiumModeDTO>> GetAll();
        Task<PremiumModeDTO?> GetByCode(string code);
        Task<PremiumModeDTO?> Create(PremiumModeDTO premiumMode);
        Task Update(PremiumModeDTO premiumMode);
        Task Delete(string code);
        Task<IEnumerable<PremiumModeDTO>?> GetByDescriptionAndNotByCode(string description, string code);
    }
}
