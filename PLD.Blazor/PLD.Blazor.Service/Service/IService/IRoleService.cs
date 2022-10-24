using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAll();
        Task<RoleDTO> Create(RoleDTO role);
        Task<RoleDTO> GetByName(string name);
        Task<IEnumerable<RoleDTO>> GetByNameAndNotID(string name, int id);
        Task<RoleDTO> GetById(int id);
        Task Update(RoleDTO role);
        Task Delete(int id);
    }
}
