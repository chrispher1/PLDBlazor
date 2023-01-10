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
    public class PremiumModeRepository:GenericRepository<PremiumMode>, IPremiumModeRepository<PremiumMode>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public PremiumModeRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext) { 
            _applicationDBContext = applicationDBContext;
        }

        public void Update(PremiumMode entity)
        {
            var record = _applicationDBContext.PremiumMode.Where(premiumMode => premiumMode.Code == entity.Code).Single();

            record.Description= entity.Description;
            record.ModifiedBy= entity.ModifiedBy;
            record.ModifiedDate = entity.ModifiedDate;
        }
    }
}
