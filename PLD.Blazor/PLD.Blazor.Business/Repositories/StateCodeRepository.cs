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
    public class StateCodeRepository : GenericRepository<StateCode>, IStateCodeRepository<StateCode>
    {

        #region Fields

        private readonly ApplicationDBContext _applicationDBContext;

        #endregion

        #region Methods
        public StateCodeRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(StateCode entity)
        {
            var stateCodeRecord = _applicationDBContext.StateCode.Where( obj => obj.Code == entity.Code ).Single();

            stateCodeRecord.Name= entity.Name;
            stateCodeRecord.ModifiedDate= entity.ModifiedDate;
            stateCodeRecord.ModifiedBy= entity.ModifiedBy;
        }

        #endregion
    }
}
