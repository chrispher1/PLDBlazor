using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.IRepositories
{
    public interface ICommissionRepository<T>
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    }
}
