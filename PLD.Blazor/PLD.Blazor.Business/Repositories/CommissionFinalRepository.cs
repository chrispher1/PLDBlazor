using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.DataAccess;
using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.Repositories
{
    internal class CommissionFinalRepository: GenericRepository<CommissionFinal>, ICommissionFinalRepository<CommissionFinal>
    {
        private readonly ApplicationDBContext _applicationDBContext;

        internal CommissionFinalRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext)
        {
            _applicationDBContext= applicationDBContext;
        }

        public void Update(CommissionFinal entity)
        {
            var commissionFinalRecord = _applicationDBContext.CommissionFinal.Where(commissionFinal => commissionFinal.Id == entity.Id).Single();

            commissionFinalRecord.CarrierId = entity.CarrierId;
            commissionFinalRecord.ProductId = entity.ProductId;
            commissionFinalRecord.PolicyYear = entity.PolicyYear;
            commissionFinalRecord.Policy = entity.Policy;
            commissionFinalRecord.TransDate = entity.TransDate;
            commissionFinalRecord.CommEffectiveDate = entity.CommEffectiveDate;
            commissionFinalRecord.TransType = entity.TransType;
            commissionFinalRecord.CommPremium = entity.CommPremium;
            commissionFinalRecord.CommOverridePayment = entity.CommOverridePayment;
            commissionFinalRecord.Compensable = entity.Compensable;
            commissionFinalRecord.CommOverrideRate = entity.CommOverrideRate;
            commissionFinalRecord.CommPremiumMode = entity.CommPremiumMode;
            commissionFinalRecord.ModifiedBy = entity.ModifiedBy;
            commissionFinalRecord.ModifiedDate = entity.ModifiedDate;
        }
    }
}
