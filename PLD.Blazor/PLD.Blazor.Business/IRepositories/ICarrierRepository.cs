using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.IRepositories
{
    public interface ICarrierRepository<T> : IGenericRepository<T>
    {
        void Update(T entity);
    }
}
