using PLD.Blazor.Common;
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
        Task<PagedList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, GridParams? gridParams = null, string? sortParams = null);
    }
}
