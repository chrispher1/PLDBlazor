using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.DataAccess;
using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICarrierRepository<Carrier> Carrier { get; }
        private readonly ApplicationDBContext _applicationDBContext;

        public UnitOfWork(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;   
            Carrier = new CarrierRepository(applicationDBContext);
        }
        public async Task Save()
        {
            await _applicationDBContext.SaveChangesAsync();
        }
    }
}
