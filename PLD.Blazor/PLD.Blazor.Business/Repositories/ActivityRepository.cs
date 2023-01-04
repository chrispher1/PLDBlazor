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
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository<Activity>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public ActivityRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(Activity entity)
        {
            var activityRecord = _applicationDBContext.Activity.Where(activity => activity.Code == entity.Code).Single();
            
            activityRecord.Description = entity.Description;
            activityRecord.ModifiedBy = entity.ModifiedBy;
            activityRecord.ModifiedDate = entity.ModifiedDate;
        }
    }
}
