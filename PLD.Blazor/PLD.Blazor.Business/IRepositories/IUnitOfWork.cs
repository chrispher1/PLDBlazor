using PLD.Blazor.Business.DTO;
using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.IRepositories
{
    public interface IUnitOfWork
    {
        ICarrierRepository<Carrier> Carrier { get; }
        IProductTypeRepository<ProductType> ProductType { get; }
        IProductRepository<Product> Product { get; }
        IUserRepository<User, UserForRegisterDTO> User { get; }
        IRoleRepository<Role> Role { get; }
        IUserRoleRepository<UserRole> UserRole { get; }
        IActivityRepository<Activity> Activity { get; }
        ITimeActivityMappingRepository<TimeActivityMapping> TimeActivityMapping { get; }
        IPremiumModeRepository<PremiumMode> PremiumMode { get; }
        ICommissionErrorRepository<CommissionError> CommissionError { get; }
        Task Save();
    }
}
