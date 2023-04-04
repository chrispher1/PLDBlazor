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
    public class CommissionService : ICommissionService
    {
        private readonly HttpClient _httpClient;
        public CommissionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CommissionDTO>?> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Commission");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<CommissionDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<CommissionDTO>>(responseContent);
                return result;
            }
            else
            {
                return emptyList;
            }
        }
    }
}
