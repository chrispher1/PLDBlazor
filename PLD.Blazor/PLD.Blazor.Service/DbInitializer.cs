﻿using PLD.Blazor.DataAccess;
using PLD.Blazor.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.Common;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using Microsoft.Extensions.Options;

namespace PLD.Blazor.Service
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DefaultAdmin _defaultAdmin;
        private readonly DefaultRoles _defaultRoles;

        public DbInitializer(ApplicationDBContext applicationDBContext, 
            IUnitOfWork unitOfWork, 
            IOptions<DefaultAdmin> option,
            IOptions<DefaultRoles> optionRoles)
        {
            _applicationDBContext = applicationDBContext;
            _unitOfWork = unitOfWork;
            _defaultAdmin = option.Value;
            _defaultRoles = optionRoles.Value;
        }
        public async Task Initialize()
        {
            try 
            {
                if (_applicationDBContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _applicationDBContext.Database.Migrate();
                }
                else
                {
                    return;
                }

                // Seed the role table
                IEnumerable<Role> roles = new List<Role>() {
                    new Role
                    {                        
                        Name = _defaultRoles.Role_Admin,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {                        
                        Name = _defaultRoles.Role_Commission_User,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Commission_User_Read,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Commission_User_Edit,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Commission_User_Create,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Commission_User_Delete,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Case_User,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Case_User_Create,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Case_User_Read,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Case_User_Edit,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Case_User_Delete,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Payment_User,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Reports_User,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Role
                    {
                        Name = _defaultRoles.Role_Maintenance_User,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                };

                await _unitOfWork.Role.Add(roles);      
                await _unitOfWork.Save();

                // Seed the default user
                var userForRegisterDTO = new UserForRegisterDTO
                {
                    UserName = _defaultAdmin.DefaultAdminUser,
                    Password = _defaultAdmin.DefaultAdminPassword,
                    ConfirmPassword = _defaultAdmin.DefaultAdminPassword,
                    FirstName = _defaultAdmin.DefaultAdminFirstName,
                    LastName = _defaultAdmin.DefaultAdminLasttName,
                    BirthDate = _defaultAdmin.DefaultAdminBirthDate,
                    CreatedDate = DateTime.Now,
                    CreatedBy = ConstantClass.SystemUser,

                    UserRoles = new List<UserRoleDTO>
                    {
                        new UserRoleDTO
                        {
                            CreatedDate = DateTime.Now,
                            CreatedBy = ConstantClass.SystemUser,
                            RoleId = _applicationDBContext.Role.Where(r => r.Name == _defaultRoles.Role_Admin).Select( Roleid => Roleid.Id).Single()
                        }
                    }
                };
                
                await _unitOfWork.User.Register(userForRegisterDTO);

                // Seed the products
                IEnumerable<Product> products = new List<Product>() {
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "AIG").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Indexed Universal Life").Select( p => p.Id).SingleOrDefault(),
                        Code = "PLTNCHCV",
                        Name = "AG-Platinum Choice - CV",
                        SalesLinkCarrierId = "60488",
                        ProductRateIndicator = false,
                        ProductTypeRateIndicator = false,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "Lincoln").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Variable Universal Life").Select( p => p.Id).SingleOrDefault(),
                        Code = "VULAE9",
                        Name = "Lincoln AssetEdge VUL 2009",
                        SalesLinkCarrierId = "LLCTB",
                        ProductRateIndicator = true,
                        ProductTypeRateIndicator = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "John Hancock").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Term").Select( p => p.Id).SingleOrDefault(),
                        Code = "J1016NY",
                        Name = "JOHN HANCOCK TERM 10",
                        SalesLinkCarrierId = "86375",
                        ProductRateIndicator = true,
                        ProductTypeRateIndicator = false,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "Pacific Life").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Term").Select( p => p.Id).SingleOrDefault(),
                        Code = "PRIME10",
                        Name = "PRIME Term-10",
                        SalesLinkCarrierId = "PL",
                        ProductRateIndicator = true,
                        ProductTypeRateIndicator = false,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "Protective").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Universal Life").Select( p => p.Id).SingleOrDefault(),
                        Code = "ADVCHUL16",
                        Name = "ADVANTAGE CHOICE UL 2/2016",
                        SalesLinkCarrierId = "68136",
                        ProductRateIndicator = true,
                        ProductTypeRateIndicator = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "Protective").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Term").Select( p => p.Id).SingleOrDefault(),
                        Code = "CUSTCHUL",
                        Name = "Custom Choice UL",
                        SalesLinkCarrierId = "68136",
                        ProductRateIndicator = true,
                        ProductTypeRateIndicator = false,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "Mass Mutual").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Whole Life").Select( p => p.Id).SingleOrDefault(),
                        Code = "W100",
                        Name = "Whole Life Legacy 100",
                        SalesLinkCarrierId = "65935",
                        ProductRateIndicator = false,
                        ProductTypeRateIndicator = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Product
                    {
                        CarrierId = _applicationDBContext.Carrier.Where( c => c.Name == "Mass Mutual").Select( c => c.Id).SingleOrDefault(),
                        ProductTypeId = _applicationDBContext.ProductType.Where( p => p.Name == "Whole Life").Select( p => p.Id).SingleOrDefault(),
                        Code = "LP20",
                        Name = "Whole Life Legacy 20 Pay",
                        SalesLinkCarrierId = "65935",
                        ProductRateIndicator = false,
                        ProductTypeRateIndicator = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                };
                
                await _unitOfWork.Product.Add(products);
                
                IEnumerable<StateCode> stateCodes = new List<StateCode>()
                {
                    new StateCode()
                    {
                        Code = "AA",
                        Name = "Armed Forces - America",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "AK",
                        Name = "Alaska",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "AL",
                        Name = "Alabama",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "AP",
                        Name = "Military Address Designation",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "AR",
                        Name = "Arkansas",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "AZ",
                        Name = "Arizona",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "CA",
                        Name = "California",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "CO",
                        Name = "Colorado",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "CT",
                        Name = "Connecticut",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "DC",
                        Name = "District of Columbia",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "DE",
                        Name = "Delaware",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "FL",
                        Name = "Florida",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "GA",
                        Name = "Georgia",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "GU",
                        Name = "Guam",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "HI",
                        Name = "Hawaii",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "IA",
                        Name = "Iowa",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "ID",
                        Name = "Idaho",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "IL",
                        Name = "Illinois",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "IN",
                        Name = "Indiana",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "KS",
                        Name = "Kansas",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "KY",
                        Name = "Kentucky",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new StateCode()
                    {
                        Code = "LA",
                        Name = "Louisiana",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                };

                await _unitOfWork.StateCode.Add(stateCodes);

                //Seed the activities
                var activities = new List<Activity>()
                {
                    new Activity()
                    {
                        Code = "T",
                        Description = "Target",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Activity()
                    {
                        Code = "E",
                        Description = "Excess",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Activity()
                    {
                        Code = "R",
                        Description = "Renewal",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new Activity()
                    {
                        Code = "A",
                        Description = "Adjustment",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    }
                };
                await _unitOfWork.Activity.Add(activities);

                //Seed premium mode
                var premiumModes = new List<PremiumMode>()
                {
                    new PremiumMode()
                    {
                        Code = "AB",
                        Description = "Annual - Bank Draft",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "AN",
                        Description = "Annual",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "MB",
                        Description = "Semiannual - Bank Draft",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "MN",
                        Description = "Monthly",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "N/A",
                        Description = "N/A",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "OT",
                        Description = "Other",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "QT",
                        Description = "Quarterly",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "SA",
                        Description = "Semiannual",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "SB",
                        Description = "Monthly - Bank Draft",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new PremiumMode()
                    {
                        Code = "SP",
                        Description = "Singple Payment/Lump Sum",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    }
                };

                await _unitOfWork.PremiumMode.Add(premiumModes);

                // Seed Case Status

                var caseStatuses = new List<CaseStatus>() {
                    new CaseStatus() {                        
                        Name = "Draft",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new CaseStatus() {
                        Name = "Active",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new CaseStatus() {
                        Name = "Placed",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    }
                };

                await _unitOfWork.CaseStatus.Add(caseStatuses);

                var caseTypes = new List<CaseType>() { 
                    new CaseType()
                    {
                        Name = "Formal",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    },
                    new CaseType()
                    {
                        Name = "Informal",
                        CreatedDate = DateTime.Now,
                        CreatedBy = ConstantClass.SystemUser
                    }
                };

                await _unitOfWork.CaseType.Add(caseTypes);
                //todo Seed Transaction Type

                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
