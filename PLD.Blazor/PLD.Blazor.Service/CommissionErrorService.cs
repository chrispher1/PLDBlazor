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
    public class CommissionErrorService : ICommissionErrorService
    {
        private readonly HttpClient _httpClient;
        public CommissionErrorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CommissionErrorDTO> Create(CommissionErrorDTO commissionErrorDTO)
        {
            var content = JsonConvert.SerializeObject(commissionErrorDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("/api/CommissionError",bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CommissionErrorDTO>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result.ErrorMessage);
            }
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/CommissionError/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
            }
        }

        public async Task<CommissionErrorDTO> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/CommissionError/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CommissionErrorDTO>(responseContent);
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<CommissionErrorDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/CommissionError");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<CommissionErrorDTO>();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<CommissionErrorDTO>>(responseContent);
                return result;
            }
            else
            {
                return emptyList;
            }
        }
        public async Task Update(CommissionErrorDTO commissionErrorDTO)
        {
            var content = JsonConvert.SerializeObject(commissionErrorDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/CommissionError", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result.ErrorMessage);
            }
        }
    }
}
