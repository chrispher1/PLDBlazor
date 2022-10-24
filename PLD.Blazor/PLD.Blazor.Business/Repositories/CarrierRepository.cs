using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess;
using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.Repositories
{
    public sealed class CarrierRepository : GenericRepository<Carrier> , ICarrierRepository<Carrier> 
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public CarrierRepository(ApplicationDBContext applicationDBContext): base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(Carrier entity)
        {            
            var carrierRecord = _applicationDBContext.Carrier.Where( carrier => carrier.Id == entity.Id ).Single();
            carrierRecord.CarrierCode = entity.CarrierCode;
            carrierRecord.Name = entity.Name;
            carrierRecord.ModifiedBy = entity.ModifiedBy;
            carrierRecord.ModifiedDate = entity.ModifiedDate;
        }
    }
}
