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
    public class CommissionService : ICommissionService
    {
        private readonly HttpClient _httpClient;
        public CommissionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PagedList<CommissionDTO>?> GetAll(GridParams gridParams, CommissionAllSearchParams searchParams, string? sortParams = null)
        {
            var response = await _httpClient.GetAsync($"/api/Commission?PageNumber={gridParams.PageNumber}&PageSize={gridParams.PageSize}" +
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
                        
            var emptyList = new PagedList<CommissionDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = (JsonConvert.DeserializeObject<IEnumerable<CommissionDTO>>(responseContent));
                var pagedListResult = new PagedList<CommissionDTO>(result?.ToList() == null ? new List<CommissionDTO>() : result.ToList(), responseValue?.TotalItems == null ? 0 : responseValue.TotalItems);
                return pagedListResult ?? emptyList;
            }
            else
            {
                return emptyList;
            }
        }
    }
}
