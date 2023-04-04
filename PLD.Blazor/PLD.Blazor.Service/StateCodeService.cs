using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service
{
    public class StateCodeService : IStateCodeService
    {
        private readonly HttpClient _httpClient;

        public StateCodeService( HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<StateCodeDTO?> Create(StateCodeDTO stateCode)
        {
            var content = JsonConvert.SerializeObject(stateCode);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/StateCode", bodyContent); 
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<StateCodeDTO>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }

        public async Task Delete(string code)
        {
            var response = await _httpClient.DeleteAsync($"/api/StateCode/{code}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);

                throw new Exception(result?.ErrorMessage);
            }
        }

        public async Task<IEnumerable<StateCodeDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/StateCode");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<StateCodeDTO>();

            if (response.IsSuccessStatusCode) 
            {

                var result = JsonConvert.DeserializeObject<IEnumerable<StateCodeDTO>>(responseContent);
                return result ?? emptyList;
            }

            return emptyList;
        }
        public async Task<StateCodeDTO?> GetByCode(string code)
        {
            var response = await _httpClient.GetAsync($"/api/StateCode/{code}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<StateCodeDTO>(responseContent);
                return result; 
            }
            return null;
        }

        public async Task Update(StateCodeDTO stateCode)
        {
            var content = JsonConvert.SerializeObject(stateCode);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/StateCode", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);

                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
