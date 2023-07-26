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
    public sealed class PaymentRepository : GenericRepository<Payment>, IPaymentRepository<Payment>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public PaymentRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(Payment entity)
        {
            var paymentRecord = _applicationDBContext.Payment.Where(payment => payment.Id == entity.Id).Single();
            paymentRecord.CarrierId = entity.CarrierId;
            paymentRecord.PaymentDate = entity.PaymentDate;
            paymentRecord.CheckWireNumber = entity.CheckWireNumber;
            paymentRecord.DepositDate = entity.DepositDate;
            paymentRecord.EFTOverrideAmount = entity.EFTOverrideAmount;
            paymentRecord.ModifiedBy = entity.ModifiedBy;
            paymentRecord.ModifiedDate = entity.ModifiedDate;
        }
    }
}
