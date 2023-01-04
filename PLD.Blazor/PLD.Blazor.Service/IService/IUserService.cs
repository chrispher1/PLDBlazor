using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface IUserService
    {
        Task<UserDTO> Register(UserForRegisterDTO userForLoginDTO);
        Task<UserDTO> Login(UserForLoginDTO userForLoginDTO);
        Task<UserDTO> GetByUserName(string userName);
        Task Logout();
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task<UserDTO> Create(UserDTO user);
        Task Update(UserDTO user);
        Task<IEnumerable<UserDTO>> GetByUserNameAndNotID(string userName, int id);
        Task Delete(int id);
    }
}
