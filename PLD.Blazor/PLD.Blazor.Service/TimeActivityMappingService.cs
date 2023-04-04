using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using PLD.Blazor.Service.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Service
{
    public class TimeActivityMappingService : ITimeActivityMappingService
    {
        private readonly HttpClient _httpClient;

        public TimeActivityMappingService( HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<TimeActivityMappingDTO?> Create(TimeActivityMappingDTO timeActivityMappingDTO)
        {
            var content = JsonConvert.SerializeObject(timeActivityMappingDTO);
            var bodyContent = new StringContent(content,Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("/api/TimeActivityMapping", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TimeActivityMappingDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync($"/api/TimeActivityMapping/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
        public async Task<IEnumerable<TimeActivityMappingDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/TimeActivityMapping");
            var responseContent = await response.Content.ReadAsStringAsync();
            var emptyList = new List<TimeActivityMappingDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<TimeActivityMappingDTO>>(responseContent);
                return result ?? emptyList;
            }
            return emptyList;
        }

        public async Task<TimeActivityMappingDTO?> GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEnd(
            int carrierId, string carrierActivity, int policyYearStart, int policyYearEnd, string? carrierTime = null)
        {
            StringBuilder sb = new();
            sb.Append("/api/TimeActivityMapping/GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEnd");
            sb.Append($"/{carrierId}");
            sb.Append($"/{carrierActivity}");
            sb.Append($"/{policyYearStart}");
            sb.Append($"/{policyYearEnd}");
            if (carrierTime != null)
                sb.Append($"/{carrierTime}");

            var response = await _httpClient.GetAsync(sb.ToString());
            var responseContent = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TimeActivityMappingDTO>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                if (result?.ErrorMessage == ConstantClass.NoRecordFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception(result?.ErrorMessage);
                }
            }            
        }

        public async Task<IEnumerable<TimeActivityMappingDTO>?> GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEndAndNotById(
            int carrierId, string carrierActivity, int policyYearStart, int policyYearEnd, int id, string? carrierTime = null)
        {
            StringBuilder sb = new();
            sb.Append("/api/TimeActivityMapping/GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEndAndNotById");
            sb.Append($"/{carrierId}");
            sb.Append($"/{carrierActivity}");
            sb.Append($"/{policyYearStart}");
            sb.Append($"/{policyYearEnd}");
            sb.Append($"/{id}");

            if (carrierTime != null)
                sb.Append($"/{carrierTime}");

            var response = await _httpClient.GetAsync(sb.ToString());
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<TimeActivityMappingDTO>>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                if (result?.ErrorMessage == ConstantClass.NoRecordFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception(result?.ErrorMessage);
                }
            }
        }

        public async Task<TimeActivityMappingDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/TimeActivityMapping/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TimeActivityMappingDTO>(responseContent);
                return result;
            }
            return null;
        }

        public async Task Update(TimeActivityMappingDTO timeActivityMappingDTO)
        {
            var content = JsonConvert.SerializeObject(timeActivityMappingDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/TimeActivityMapping", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
