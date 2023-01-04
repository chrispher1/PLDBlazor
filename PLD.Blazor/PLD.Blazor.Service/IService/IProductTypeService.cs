using PLD.Blazor.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service.IService
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductTypeDTO>> GetAll();
        Task<ProductTypeDTO> GetById(int id);
        Task<ProductTypeDTO> Create(ProductTypeDTO productType);
        Task<ProductTypeDTO> GetByCode(string code);
        Task<IEnumerable<ProductTypeDTO>> GetByCodeAndNotID(string code, int id);
        Task Update(ProductTypeDTO productType);
        Task Delete(int id);
    }
}
