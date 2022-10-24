using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.IRepositories
{
    public interface IUserRepository<T, U>: IGenericRepository<T> where T : class  where U : class
    {
        void Update(T entity);
        Task<T> Register(U entity);
        Task<bool> UserExists(string userName);

        Task<T> LogIn(string userName, string password);
    }
}
