using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLD.Blazor.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public async Task<PaymentDTO?> Create(PaymentDTO payment)
        {
            var content = JsonConvert.SerializeObject(payment);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Payment", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<PaymentDTO>(responseContent);
                return result;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel?.ErrorMessage);
            }
        }
        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync("/api/Payment/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel?.ErrorMessage);
            }            
        }

        public async Task<PagedList<PaymentDTO>?> GetAll(GridParams gridParams, PaymentSearchParams searchParams, string? sortParams = null)
        {
            var response = await _httpClient.GetAsync($"/api/Payment?PageNumber={gridParams.PageNumber}&PageSize={gridParams.PageSize}" +
                $"&CarrierId={searchParams.CarrierId}" +
                $"&PaymentDate={searchParams.PaymentDate}" +
                $"&CheckWireNumber={searchParams.CheckWireNumber}" +
                $"&DepositDate={searchParams.DepositDate}" +
                $"&EFTOverrideAmount={searchParams.EFTOverrideAmount}" +                
                (sortParams != null ? $"&SortParams={sortParams}" : "")
                );

            var responseContent = await response.Content.ReadAsStringAsync();

            var responseValue = JsonConvert.DeserializeObject<PaginationHeader>(response.Headers.GetValues("Pagination").First());

            var emptyList = new PagedList<PaymentDTO>();
            if (response.IsSuccessStatusCode)
            {
                var result = (JsonConvert.DeserializeObject<IEnumerable<PaymentDTO>>(responseContent));
                var pagedListResult = new PagedList<PaymentDTO>(result?.ToList() == null ? new List<PaymentDTO>() : result.ToList(), responseValue?.TotalItems == null ? 0 : responseValue.TotalItems);
                return pagedListResult ?? emptyList;
            }
            else
            {
                return emptyList;
            }
        }

        public async Task<PaymentDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync("/api/Payment/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<PaymentDTO>(responseContent);
                return result;
            }
            return null;
        }

        public async Task Update(PaymentDTO payment)
        {
            var content = JsonConvert.SerializeObject(payment);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/Payment", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel?.ErrorMessage);
            }
        }
    }
}
