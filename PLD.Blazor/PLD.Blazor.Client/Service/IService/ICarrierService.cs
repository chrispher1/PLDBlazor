using PLD.Blazor.Business.DTO;

namespace PLD.Blazor.Client.Service.IService
{
    public interface ICarrierService
    {
        Task<IEnumerable<CarrierDTO>> GetAll();
        Task<CarrierDTO> Create(CarrierDTO carrier);
        Task<CarrierDTO> GetByCode(string code);


    }
}
