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
    public class CaseTypeRepository : GenericRepository<CaseType>, ICaseTypeRepository<CaseType>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        
        public CaseTypeRepository(ApplicationDBContext applicationDBContext): base (applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(CaseType entity)
        {
            var record = _applicationDBContext.CaseType.Where(obj => obj.Id == entity.Id).Single();
            record.Name = entity.Name;
            record.ModifiedBy = entity.ModifiedBy;
            record.ModifiedDate = entity.ModifiedDate;
        }
    }
}
