using PLD.Blazor.Business.DTO;

namespace PLD.Blazor.Service.IService
{
    public interface ICarrierService
    {
        Task<IEnumerable<CarrierDTO>> GetAll();
        Task<CarrierDTO?> Create(CarrierDTO carrier);
        Task<CarrierDTO?> GetByCode(string code);
        Task<IEnumerable<CarrierDTO>?> GetByCodeAndNotID(string code, int id);
        Task<CarrierDTO?> GetById(int id);
        Task Update(CarrierDTO carrier);
        Task Delete(int id);

    }
}
