using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
    public class CaseStatusService : ICaseStatusService
    {
        private readonly HttpClient _httpClient; 
        public CaseStatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CaseStatusDTO?> Create(CaseStatusDTO caseStatusDTO)
        {
            var content = JsonConvert.SerializeObject(caseStatusDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/CaseStatus", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseStatusDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync($"/api/CaseStatus/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode) 
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
        public async Task<IEnumerable<CaseStatusDTO>?> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/CaseStatus");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<CaseStatusDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<CaseStatusDTO>>(responseContent);
                return result;
            }
            else
            {
                return emptyList;
            }
        }

        public async Task<CaseStatusDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/CaseStatus/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseStatusDTO>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<CaseStatusDTO?> GetByName(string name)
        {
            var response = await _httpClient.GetAsync($"/api/CaseStatus/GetByName/{name}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseStatusDTO>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CaseStatusDTO>?> GetByNameAndNotById(string name, int id)
        {
            var response = await _httpClient.GetAsync($"/api/CaseStatus/GetByNameAndNotById/{name}/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<IEnumerable<CaseStatusDTO>>(responseContent);
                return result;
            }
            return null;

        }

        public async Task Update(CaseStatusDTO caseStatusDTO)
        {
            var content = JsonConvert.SerializeObject(caseStatusDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/CaseStatus", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
