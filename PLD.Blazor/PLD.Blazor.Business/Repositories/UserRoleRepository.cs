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
    public sealed class UserRoleRepository:GenericRepository<UserRole>, IUserRoleRepository<UserRole>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public UserRoleRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public void Update(UserRole entity)
        {
            var record = _applicationDBContext.UserRole.Where(obj => obj.UserId == entity.UserId && obj.RoleId  == obj.RoleId ).Single();            
            record.UserId = entity.UserId;
            record.RoleId = entity.RoleId;
            record.ModifiedBy = entity.ModifiedBy;
            record.ModifiedDate = entity.ModifiedDate;
        }
    }
}
