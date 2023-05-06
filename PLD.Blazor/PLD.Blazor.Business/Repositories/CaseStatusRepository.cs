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
    public class CaseStatusRepository : GenericRepository<CaseStatus>, ICaseStatusRepository<CaseStatus>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public CaseStatusRepository(ApplicationDBContext applicationDBContext) : base (applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public void Update(CaseStatus entity)
        {
            var record = _applicationDBContext.CaseStatus.Where( obj => obj.Id == entity.Id ).Single();
            record.Name = entity.Name;
            record.ModifiedDate = entity.ModifiedDate;
            record.ModifiedBy = entity.ModifiedBy;
        }
    }
}
