using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using PLD.Blazor.Service.IService;
using System.Text;

namespace PLD.Blazor.Service
{
    public sealed class CarrierService: ICarrierService
    {
        private readonly HttpClient _httpClient;
        public CarrierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CarrierDTO?> Create(CarrierDTO carrier)
        {
            var content = JsonConvert.SerializeObject(carrier);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response =  await _httpClient.PostAsync("/api/Carrier", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CarrierDTO>(responseContent);
                return result;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel?.ErrorMessage);
            }
        }
        public async Task Update(CarrierDTO carrier)
        {
            var content = JsonConvert.SerializeObject(carrier);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/Carrier", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if( !response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel?.ErrorMessage);
            }
        }
        public async Task<IEnumerable<CarrierDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Carrier");
            var emptyList = new List<CarrierDTO>();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(responseContent);

                return result ?? emptyList;
            }

            return emptyList;
        }

        public async Task<CarrierDTO?> GetByCode(string code)
        {            
            var response = await _httpClient.GetAsync("/api/Carrier/GetByCode/" + code);            
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {                
                var result = JsonConvert.DeserializeObject<CarrierDTO>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                if (result?.ErrorMessage == ConstantClass.NoRecordFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception(result?.ErrorMessage);
                }
            }            
        }        
        public async Task<IEnumerable<CarrierDTO>?> GetByCodeAndNotID(string code, int id)
        {
            var response = await _httpClient.GetAsync("/api/Carrier/GetByCodeAndNotID/" + code +"/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                var result = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(responseContent);
                return result;
            }
            return null;
        }
        public async Task<CarrierDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync("/api/Carrier/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CarrierDTO>(responseContent);
                return result;
            }
            return null;
        }
        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync("/api/Carrier/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel?.ErrorMessage);
            }
        }
    }
}
