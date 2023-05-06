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
    public class CaseTypeService: ICaseTypeService
    {
        private readonly HttpClient _httpClient;
        public CaseTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CaseTypeDTO?> Create(CaseTypeDTO caseTypeDTO)
        {
            var content = JsonConvert.SerializeObject(caseTypeDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/CaseType", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseTypeDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync($"/api/CaseType/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
        public async Task<IEnumerable<CaseTypeDTO>?> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/CaseType");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<CaseTypeDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<CaseTypeDTO>>(responseContent);
                return result;
            }
            else
            {
                return emptyList;
            }
        }

        public async Task<CaseTypeDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/CaseType/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseTypeDTO>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<CaseTypeDTO?> GetByName(string name)
        {
            var response = await _httpClient.GetAsync($"/api/CaseType/GetByName/{name}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseTypeDTO>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CaseTypeDTO>?> GetByNameAndNotById(string name, int id)
        {
            var response = await _httpClient.GetAsync($"/api/CaseType/GetByNameAndNotById/{name}/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<CaseTypeDTO>>(responseContent);
                return result;
            }
            return null;
        }

        public async Task Update(CaseTypeDTO caseTypeDTO)
        {
            var content = JsonConvert.SerializeObject(caseTypeDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/CaseType", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
