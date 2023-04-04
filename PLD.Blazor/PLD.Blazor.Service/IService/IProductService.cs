using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO?> Create(ProductDTO product);
        Task<ProductDTO?> GetByCode(string code);
        Task<IEnumerable<ProductDTO>?> GetByCodeAndNotID(string code, int id);
        Task<ProductDTO?> GetById(int id);
        Task Update(ProductDTO product);
        Task Delete(int id);
        Task<IEnumerable<ProductDTO> ?> GetByCarrierId(int carrierId);

    }
}
