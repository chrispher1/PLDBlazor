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
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RoleDTO> Create(RoleDTO role)
        {
            var content = JsonConvert.SerializeObject(role);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Role", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<RoleDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync($"/api/Role/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);

                throw new Exception(result.ErrorMessage);
            }
        }

        public async Task<IEnumerable<RoleDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Role");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<RoleDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<RoleDTO>>(responseContent);
                return result;
            }
            return emptyList;
        }
        public async Task<RoleDTO> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Role/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<RoleDTO>(responseContent);
                return result;
            }
            return null;            
        }
        public async Task<RoleDTO> GetByName(string name)
        {
            var response = await _httpClient.GetAsync($"/api/Role/GetByName/{name}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<RoleDTO>(responseContent);
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
            return null;
        }
        public async Task<IEnumerable<RoleDTO>> GetByNameAndNotID(string name, int id)
        {
            var response = await _httpClient.GetAsync($"/api/Role/GetByNameAndNotID/{name}/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<RoleDTO>>(responseContent);
                return result;
            }
            return null;
        }
        public async Task Update(RoleDTO role)
        {
            var content = JsonConvert.SerializeObject(role);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/Role", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result.ErrorMessage);
            }
        }
    }
}
