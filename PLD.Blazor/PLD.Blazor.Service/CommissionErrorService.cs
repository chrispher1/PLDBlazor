using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using PLD.Blazor.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
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
        public async Task<CommissionErrorDTO?> Create(CommissionErrorDTO commissionErrorDTO)
        {
            commissionErrorDTO.Id = 0;
            commissionErrorDTO.Activity = null;
            commissionErrorDTO.Carrier = null;
            commissionErrorDTO.PremiumMode = null;
            commissionErrorDTO.Product = null;

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
                throw new Exception(result?.ErrorMessage);
            }
        }
        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/CommissionError/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
        public async Task<CommissionErrorDTO?> GetById(int id)
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
        public async Task<PagedList<CommissionErrorDTO>> GetAll(GridParams gridParams, CommissionErrorSearchParams searchParams, string? sortParams = null)
        {   
            var response = await _httpClient.GetAsync($"/api/CommissionError?PageNumber={gridParams.PageNumber}&PageSize={gridParams.PageSize}" +
                $"&CarrierId={searchParams.CarrierId}"+
                $"&Policy={searchParams.Policy}" +
                $"&TransDate={searchParams.TransDate}"+
                $"&TransType={searchParams.TransType}"+
                $"&CommPremium={searchParams.CommPremium}"+
                $"&CommOverrideRate={searchParams.CommOverrideRate}"+
                $"&CommOverridePayment={searchParams.CommOverridePayment}"+
                (sortParams != null ? $"&SortParams={sortParams}" : "")
                );

            var responseContent = await response.Content.ReadAsStringAsync();

            var responseValue = JsonConvert.DeserializeObject<PaginationHeader>(response.Headers.GetValues("Pagination").First());
            
            var emptyList =  new PagedList<CommissionErrorDTO>();
            if (response.IsSuccessStatusCode)
            {
                var result =( JsonConvert.DeserializeObject<IEnumerable<CommissionErrorDTO>>(responseContent));
                var pagedListResult = new PagedList<CommissionErrorDTO>(result?.ToList() == null ? new List<CommissionErrorDTO>() : result.ToList(), responseValue?.TotalItems == null ? 0: responseValue.TotalItems);
                return pagedListResult ?? emptyList;
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
                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
