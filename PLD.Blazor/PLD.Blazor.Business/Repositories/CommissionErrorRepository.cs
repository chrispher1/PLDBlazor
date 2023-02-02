using Microsoft.EntityFrameworkCore;
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
    public sealed class CommissionErrorRepository: GenericRepository<CommissionError>, ICommissionErrorRepository<CommissionError>
    {
        private readonly ApplicationDBContext _applicationDBContext;
       public CommissionErrorRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext) { 
            _applicationDBContext= applicationDBContext;
        }

        public void Update(CommissionError entity)
        {
            var commissionErrorRecord = _applicationDBContext.CommissionError.Where(commissionError => commissionError.Id == entity.Id).Single();

            commissionErrorRecord.CarrierId = entity.CarrierId;
            commissionErrorRecord.ProductId = entity.ProductId;
            commissionErrorRecord.PolicyYear = entity.PolicyYear;
            commissionErrorRecord.Policy = entity.Policy;
            commissionErrorRecord.TransDate = entity.TransDate;
            commissionErrorRecord.CommEffectiveDate = entity.CommEffectiveDate;
            commissionErrorRecord.TransType = entity.TransType;
            commissionErrorRecord.CommPremium = entity.CommPremium;
            commissionErrorRecord.CommOverridePayment = entity.CommOverridePayment;
            commissionErrorRecord.Compensable = entity.Compensable;
            commissionErrorRecord.CommOverrideRate = entity.CommOverrideRate;
            commissionErrorRecord.CommPremiumMode = entity.CommPremiumMode;
            commissionErrorRecord.ModifiedBy = entity.ModifiedBy;
            commissionErrorRecord.ModifiedDate = entity.ModifiedDate;
        }
    }
}
