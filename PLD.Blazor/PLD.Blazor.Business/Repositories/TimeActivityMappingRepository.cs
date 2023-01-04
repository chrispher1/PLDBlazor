using Microsoft.EntityFrameworkCore.Storage;
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
    public class TimeActivityMappingRepository: GenericRepository<TimeActivityMapping>, ITimeActivityMappingRepository<TimeActivityMapping>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public TimeActivityMappingRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(TimeActivityMapping entity)
        {
            var record = _applicationDBContext.TimeActivityMapping.Where(x => x.Id == entity.Id).Single();
            record.CarrierTime = entity.CarrierTime;
            record.CarrierActivity = entity.CarrierActivity;
            record.PolicyYearStart = entity.PolicyYearStart;
            record.PolicyYearEnd = entity.PolicyYearEnd;
            record.TimeCode = entity.TimeCode;
            record.CarrierId = entity.CarrierId;
            record.TransactionType = entity.TransactionType;
            record.CompensableIndicator = entity.CompensableIndicator;
            record.ModifiedBy = entity.ModifiedBy;
            record.ModifiedDate = entity.ModifiedDate;
        }
    }
}
