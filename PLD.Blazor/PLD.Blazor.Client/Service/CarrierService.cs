using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Client.Service.IService;
using System.Text;

namespace PLD.Blazor.Client.Service
{
    public sealed class CarrierService: ICarrierService
    {
        private readonly HttpClient _httpClient;
        public CarrierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarrierDTO> Create(CarrierDTO carrier)
        {
            var content = JsonConvert.SerializeObject(carrier);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response =  await _httpClient.PostAsync("/api/Carrier", bodyContent);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CarrierDTO>(responseResult);
                return result;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseResult);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<CarrierDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Carrier");
            var emptyList = new List<CarrierDTO>();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(content);

                return result;
            }

            return emptyList;

        }

        public async Task<CarrierDTO> GetByCode(string code)
        {            
            var response = await _httpClient.GetAsync("/api/Carrier/GetByCode/" + code);
            var emptyList = new CarrierDTO();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CarrierDTO>(content);

                return result;
            }

            return emptyList;
        }

        
    }
}
