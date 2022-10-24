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
    public sealed class ProductRepository : GenericRepository<Product>, IProductRepository<Product>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public ProductRepository(ApplicationDBContext applicationDBContext): base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(Product entity)
        {
            var record = _applicationDBContext.Product.Where( x => x.Id == entity.Id ).Single();
            record.CarrierId = entity.CarrierId;
            record.ProductTypeId = entity.ProductTypeId;
            record.Name = entity.Name;
            record.SalesLinkCarrierId = entity.SalesLinkCarrierId;
            record.ProductRateIndicator = entity.ProductRateIndicator;
            record.ProductTypeRateIndicator = entity.ProductTypeRateIndicator;
            record.ModifiedBy = entity.ModifiedBy;
            record.ModifiedDate = entity.ModifiedDate;
        }
    }
}
