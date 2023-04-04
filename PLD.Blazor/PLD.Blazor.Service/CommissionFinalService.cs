using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service
{
    public class CommissionFinalService: ICommissionFinalService
    {
        private HttpClient _httpClient;
        public CommissionFinalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommissionFinalDTO?> Create(CommissionFinalDTO commissionFinalDTO)
        {
            commissionFinalDTO.Activity = null;
            commissionFinalDTO.Carrier = null;
            commissionFinalDTO.PremiumMode = null;
            commissionFinalDTO.Product = null;

            var content = JsonConvert.SerializeObject(commissionFinalDTO);
            var bodyContent = new StringContent(content,Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/CommissionFinal", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CommissionFinalDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync($"/api/CommissionFinal/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }

        public async Task<IEnumerable<CommissionFinalDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/CommissionFinal");
            var respnseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<CommissionFinalDTO>();
            if (response.IsSuccessStatusCode)
            {
                var list = JsonConvert.DeserializeObject<IEnumerable<CommissionFinalDTO>>(respnseContent);
                return list ?? emptyList;
            }
            return emptyList;
        }

        public async Task<CommissionFinalDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/CommissionFinal/{id}");
            var respnseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CommissionFinalDTO>(respnseContent);
                return result;
            }
            return null;
        }
        public async Task Update(CommissionFinalDTO commissionFinalDTO)
        {
            var content = JsonConvert.SerializeObject(commissionFinalDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/CommissionFinal", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
