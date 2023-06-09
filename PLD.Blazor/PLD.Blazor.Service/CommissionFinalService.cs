using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
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

        public async Task<PagedList<CommissionFinalDTO>> GetAll(GridParams gridParams, CommissionFinalSearchParams searchParams, string? sortParams = null)
        {
            var response = await _httpClient.GetAsync($"/api/CommissionFinal?PageNumber={gridParams.PageNumber}&PageSize={gridParams.PageSize}" +
                $"&CarrierId={searchParams.CarrierId}" +
                $"&Policy={searchParams.Policy}" +
                $"&TransDate={searchParams.TransDate}" +
                $"&TransType={searchParams.TransType}" +
                $"&CommPremium={searchParams.CommPremium}" +
                $"&CommOverrideRate={searchParams.CommOverrideRate}" +
                $"&CommOverridePayment={searchParams.CommOverridePayment}"+
                (sortParams != null ? $"&SortParams={sortParams}" : "")
                );
            
            var responseContent = await response.Content.ReadAsStringAsync();

            var responseValue = JsonConvert.DeserializeObject<PaginationHeader>(response.Headers.GetValues("Pagination").First());
                        
            var emptyList = new PagedList<CommissionFinalDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = (JsonConvert.DeserializeObject<IEnumerable<CommissionFinalDTO>>(responseContent));
                var pagedListResult = new PagedList<CommissionFinalDTO>(result?.ToList() == null ? new List<CommissionFinalDTO>() : result.ToList(), responseValue?.TotalItems == null ? 0 : responseValue.TotalItems);
                return pagedListResult ?? emptyList;

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
