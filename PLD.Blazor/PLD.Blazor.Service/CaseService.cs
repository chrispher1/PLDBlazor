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
    public class CaseService : ICaseService
    {
        private readonly HttpClient _httpClient;
        public CaseService(HttpClient httpClient) 
        { 
            this._httpClient = httpClient;
        }
        public async Task<CaseDTO?> Create(CaseDTO caseDTO)
        {
            var content = JsonConvert.SerializeObject(caseDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Case", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseDTO>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Case/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }            
        }
        public async Task<IEnumerable<CaseDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Case");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<CaseDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<CaseDTO>>(responseContent);
                return result ?? emptyList;
            }
            else
            {
                return emptyList;
            }
        }
        public async Task<CaseDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Case/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseDTO?>(responseContent);
                return result;
            }
            return null;
        }
        public async Task Update(CaseDTO caseDTO)
        {
            var content = JsonConvert.SerializeObject(caseDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/Case", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
