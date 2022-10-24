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
    public sealed class ProductTypeRepository: GenericRepository<ProductType>, IProductTypeRepository<ProductType>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public ProductTypeRepository(ApplicationDBContext applicationDBContext): base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(ProductType entity)
        {
            var record = _applicationDBContext.ProductType.Where(obj => obj.Id == entity.Id).Single();
            record.Code = entity.Code;
            record.Name = entity.Name;
            record.ModifiedBy = entity.ModifiedBy;
            record.ModifiedDate = entity.ModifiedDate;
        }
    }
}
