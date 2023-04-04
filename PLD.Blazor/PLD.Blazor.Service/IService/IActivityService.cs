using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDTO>> GetAll();
        Task<ActivityDTO?> Create(ActivityDTO activity);
        Task<ActivityDTO?> GetByCode(string code);
        Task Update(ActivityDTO activity);
        Task Delete(string code);
    }
}
