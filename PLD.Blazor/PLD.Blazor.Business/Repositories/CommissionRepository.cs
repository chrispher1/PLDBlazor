using PLD.Blazor.Business.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLD.Blazor.Business;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PLD.Blazor.DataAccess;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using PLD.Blazor.Common.Utilities.ExtensionMethods;


namespace PLD.Blazor.Business.Repositories
{
    public class CommissionRepository<T,U, V> : ICommissionRepository<T> 
                                                    where T: CommissionDTO, new()  
                                                    where U : class
                                                    where V : class
        
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly DbSet<U> _dbSetCommissionError;
        private readonly DbSet<V> _dbSetCommissionFinal;
        public CommissionRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
            _dbSetCommissionError = _applicationDBContext.Set<U>();
            _dbSetCommissionFinal = _applicationDBContext.Set<V>();
        }

        public async Task<PagedList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, GridParams? gridParams = null, string? sortParams = null)
        {            
            IQueryable<U> queryCommissionError = this._dbSetCommissionError;    
            IQueryable<V> queryCommissionFinal = this._dbSetCommissionFinal;

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryCommissionError = queryCommissionError.Include(property);
                    queryCommissionFinal = queryCommissionFinal.Include(property);
                }
            }

            IEnumerable<U> commissionErrorList = await queryCommissionError.ToListAsync();
            IEnumerable<V> commissionFinalList = await queryCommissionFinal.ToListAsync();

            var firstCommissionResultList = commissionErrorList.Select(
                    obj =>
                    new T()
                    {
                        Id = (int)(obj?.GetType().GetProperty("Id")?.GetValue(obj, null) ?? 0),
                        TransDate = (DateTime?)obj?.GetType().GetProperty("TransDate")?.GetValue(obj, null),
                        CarrierId = (int)(obj?.GetType().GetProperty("CarrierId")?.GetValue(obj, null) ?? 0),
                        TransType = (string)(obj?.GetType().GetProperty("TransType")?.GetValue(obj, null) ?? 0),
                        Carrier = new CarrierDTO
                        {
                            Id = (obj?.GetType().GetProperty("Carrier")?.GetValue(obj, null) as Carrier ?? new Carrier()).Id,
                            Name = (obj?.GetType().GetProperty("Carrier")?.GetValue(obj, null) as Carrier ?? new Carrier()).Name,
                            CarrierCode = (obj?.GetType().GetProperty("Carrier")?.GetValue(obj, null) as Carrier ?? new Carrier()).CarrierCode
                        },
                        Policy = (string)(obj?.GetType().GetProperty("Policy")?.GetValue(obj, null) ?? String.Empty),
                        Activity = new ActivityDTO { Description = (obj?.GetType().GetProperty("Activity")?.GetValue(obj, null) as Activity ?? new Activity()).Description },
                        CommPremium = (decimal?)(obj?.GetType().GetProperty("CommPremium")?.GetValue(obj, null) ?? 0),
                        CommOverrideRate = (decimal?)(obj?.GetType().GetProperty("CommOverrideRate")?.GetValue(obj, null) ?? 0),
                        CommOverridePayment = (decimal?)(obj?.GetType().GetProperty("CommOverridePayment")?.GetValue(obj, null) ?? 0),
                        TableName = EnumClass.Commission.Error
                    }
               ).AsQueryable();

            var secondCommissionResultList = commissionFinalList.Select(
                    obj =>
                    new T()
                    {
                        Id = (int)(obj?.GetType().GetProperty("Id")?.GetValue(obj, null) ?? 0),
                        TransDate = (DateTime?)obj?.GetType().GetProperty("TransDate")?.GetValue(obj, null),
                        CarrierId = (int)(obj?.GetType().GetProperty("CarrierId")?.GetValue(obj, null) ?? 0),
                        TransType = (string)(obj?.GetType().GetProperty("TransType")?.GetValue(obj, null) ?? 0),
                        Carrier = new CarrierDTO
                        {
                            Id = (obj?.GetType().GetProperty("Carrier")?.GetValue(obj, null) as Carrier ?? new Carrier()).Id,
                            Name = (obj?.GetType().GetProperty("Carrier")?.GetValue(obj, null) as Carrier ?? new Carrier()).Name,
                            CarrierCode = (obj?.GetType().GetProperty("Carrier")?.GetValue(obj, null) as Carrier ?? new Carrier()).CarrierCode
                        },
                        Policy = (string)(obj?.GetType().GetProperty("Policy")?.GetValue(obj, null) ?? String.Empty),
                        Activity = new ActivityDTO { Description = (obj?.GetType().GetProperty("Activity")?.GetValue(obj, null) as Activity ?? new Activity()).Description },
                        CommPremium = (decimal?)(obj?.GetType().GetProperty("CommPremium")?.GetValue(obj, null) ?? 0),
                        CommOverrideRate = (decimal?)(obj?.GetType().GetProperty("CommOverrideRate")?.GetValue(obj, null) ?? 0),
                        CommOverridePayment = (decimal?)(obj?.GetType().GetProperty("CommOverridePayment")?.GetValue(obj, null) ?? 0),
                        TableName = EnumClass.Commission.Final
                    }
               ).AsQueryable();

            if (filter != null)
            {
                firstCommissionResultList = firstCommissionResultList.Where(filter);
                secondCommissionResultList = secondCommissionResultList.Where(filter);
            }

            PagedList<T> list;

            var unionResultList = firstCommissionResultList.Union(secondCommissionResultList);

            if (sortParams != null)
            {
                unionResultList = unionResultList.OrderBy(sortParams);
            }

            if (gridParams != null)
            {
                list =  PagedList<T>.Create(unionResultList, gridParams.PageNumber, gridParams.PageSize);
            }
            else
            {
                list =  PagedList<T>.Create(unionResultList);                
            }
            
            return list;
        }        
    }    
}
