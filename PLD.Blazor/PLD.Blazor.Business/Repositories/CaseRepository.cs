using PLD.Blazor.Business.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.DataAccess;

namespace PLD.Blazor.Business.Repositories
{
    public class CaseRepository : GenericRepository<Case>, ICaseRepository<Case>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public CaseRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public void Update(Case entity)
        {
            var caseRecord = _applicationDBContext.Case.Where( obj => obj.Id == entity.Id ).Single();
            caseRecord.CarrierId = entity.CarrierId;
            caseRecord.Policy = entity.Policy;
            caseRecord.CaseType = entity.CaseType;
            caseRecord.ProductId = entity.ProductId;
            caseRecord.ProductTypeId = entity.ProductTypeId;
            caseRecord.ClientFirstName = entity.ClientFirstName;
            caseRecord.ClientLastName = entity.ClientLastName;
            caseRecord.Status = entity.Status;
            caseRecord.IssueState = entity.IssueState;
            caseRecord.IssueAge = entity.IssueAge;
            caseRecord.AppReceiptDate = entity.AppReceiptDate;
            caseRecord.IssueDate = entity.IssueDate;
            caseRecord.EffectiveDate = entity.EffectiveDate;
            caseRecord.PlacementDate = entity.PlacementDate;
            caseRecord.FaceAmount = entity.FaceAmount;
            caseRecord.ModalPremium = entity.ModalPremium;
            caseRecord.PremiumMode = entity.PremiumMode;
            caseRecord.AnnualizedPremium = entity.AnnualizedPremium;
            caseRecord.TargetPremium = entity.TargetPremium;
            caseRecord.ExcessPremium = entity.ExcessPremium;
            caseRecord.ModifiedBy = entity.ModifiedBy;
            caseRecord.ModifiedDate = entity.ModifiedDate;
        }
    }
}
