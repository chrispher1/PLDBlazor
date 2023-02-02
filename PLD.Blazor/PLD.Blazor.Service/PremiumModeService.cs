using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using PLD.Blazor.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service
{
    public class PremiumModeService : IPremiumModeService
    {
        private HttpClient _httpClient;
        public PremiumModeService(HttpClient httpClient) { 
            _httpClient = httpClient;
        }
        public async Task<PremiumModeDTO> Create(PremiumModeDTO premiumMode)
        {
            var content = JsonConvert.SerializeObject(premiumMode);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/PremiumMode", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if( response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<PremiumModeDTO>(responseContent);

                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result.ErrorMessage);
            }
        }

        public async Task Delete(string code)
        {
            var response = await _httpClient.DeleteAsync($"/api/PremiumMode/{code}");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if( !response.IsSuccessStatusCode )
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);

                throw new Exception(result.ErrorMessage);
            }
        }

        public async Task<IEnumerable<PremiumModeDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/PremiumMode");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<PremiumModeDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<PremiumModeDTO>>(responseContent);
                return result;
            }
            else
            {
                return emptyList;
            }
        }

        public async Task<PremiumModeDTO> GetByCode(string code)
        {
            var response = await _httpClient.GetAsync($"/api/PremiumMode/{code}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) { 
                var result = JsonConvert.DeserializeObject<PremiumModeDTO>(responseContent);
                return result;
            }

            return null;
        }
        public async Task<IEnumerable<PremiumModeDTO>> GetByDescriptionAndNotByCode(string description, string code)
        {
            var response = await _httpClient.GetAsync($"/api/PremiumMode/GetByDescriptionAndNotByCode/{description}/{code}");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<PremiumModeDTO>>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                if (result.ErrorMessage == ConstantClass.NoRecordFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception(result.ErrorMessage);
                }
            }
        }
        public async Task Update(PremiumModeDTO premiumMode)
        {
            var content = JsonConvert.SerializeObject(premiumMode);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/PremiumMode", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);

                throw new Exception(result.ErrorMessage);
            }
        }
    }
}
