using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.IRepositories
{
    public interface IUnitOfWork
    {
        ICarrierRepository<Carrier> Carrier { get; }
        Task Save();
    }
}
