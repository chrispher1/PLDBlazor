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
    public class ActivityService : IActivityService
    {
        private HttpClient _httpClient;

        public ActivityService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<ActivityDTO> Create(ActivityDTO activity)
        {
            var content = JsonConvert.SerializeObject(activity);
            var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("/api/Activity", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ActivityDTO>(responseContent);
                return result;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task Delete(string code)
        {
            var response = await _httpClient.DeleteAsync("/api/Activity/" + code);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<ActivityDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Activity");
            var emptyList = new List<ActivityDTO>();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<IEnumerable<ActivityDTO>>(responseContent);

                return list;
            }
            else
            {
                return emptyList;
            }
        }

        public async Task<ActivityDTO> GetByCode(string code)
        {
            var response = await _httpClient.GetAsync("/api/Activity/"+ code);
            var emptyList = new List<ActivityDTO>();
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var record = JsonConvert.DeserializeObject<ActivityDTO>(responseContent);
                return record;
            }
            return null;
        }
        public async Task Update(ActivityDTO activity)
        {
            var content = JsonConvert.SerializeObject(activity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/Activity", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
            
    }
}
