﻿using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.Repositories;
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
        ICommissionFinalRepository<CommissionFinal> CommissionFinal { get; }
        IStateCodeRepository<StateCode> StateCode { get; }
        ICommissionRepository<CommissionDTO> Commission { get; }
        ICaseRepository<Case> Case { get; }
        ICaseStatusRepository<CaseStatus> CaseStatus { get; }
        ICaseTypeRepository<CaseType> CaseType { get; } 
        IPaymentRepository<Payment> Payment { get; }
        Task Save();
    }
}
