using PLD.Blazor.Business.DTO;
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
    public sealed class UnitOfWork : IUnitOfWork
    {
        public ICarrierRepository<Carrier> Carrier { get; }
        public IProductTypeRepository<ProductType> ProductType { get; }
        public IProductRepository<Product> Product { get; }
        public IUserRepository<User, UserForRegisterDTO> User { get; }
        public IRoleRepository<Role> Role { get; }
        public IUserRoleRepository<UserRole> UserRole { get; }
        public IActivityRepository<Activity> Activity { get; }
        public ITimeActivityMappingRepository<TimeActivityMapping> TimeActivityMapping { get; }
        public IPremiumModeRepository<PremiumMode> PremiumMode { get; }

        public ICommissionErrorRepository<CommissionError> CommissionError { get; }

        private readonly ApplicationDBContext _applicationDBContext;

        public UnitOfWork(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;   
            Carrier = new CarrierRepository(applicationDBContext);
            ProductType = new ProductTypeRepository(applicationDBContext);
            Product = new ProductRepository(applicationDBContext);
            User = new UserRepository(applicationDBContext);
            Role = new RoleRepository(applicationDBContext);
            UserRole = new UserRoleRepository(applicationDBContext);
            Activity = new ActivityRepository(applicationDBContext);
            TimeActivityMapping = new TimeActivityMappingRepository(applicationDBContext);
            PremiumMode = new PremiumModeRepository(applicationDBContext);
            CommissionError = new CommissionErrorRepository(applicationDBContext);
        }
        public async Task Save()
        {
            await _applicationDBContext.SaveChangesAsync();
        }
    }
}
