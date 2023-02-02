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
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProductDTO> Create(ProductDTO product)
        {
            var content = JsonConvert.SerializeObject(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Product", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ProductDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync("/api/Product/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result.ErrorMessage);
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Product");
            var emptyList = new List<ProductDTO>();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(responseContent);
                return result;
            }
            return emptyList;
        }

        public async Task<IEnumerable<ProductDTO>> GetByCarrierId(int carrierId)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetByCarrierId/{carrierId}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject< IEnumerable<ProductDTO>>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<ProductDTO> GetByCode(string code)
        {
            var response = await _httpClient.GetAsync("/api/Product/GetByCode/" + code);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ProductDTO>(responseContent);
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

        public async Task<IEnumerable<ProductDTO>> GetByCodeAndNotID(string code, int id)
        {
            var response = await _httpClient.GetAsync("/api/Product/GetByCodeAndNotID/" + code + "/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var response = await _httpClient.GetAsync("/api/Product/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ProductDTO>(responseContent);
                return result;
            }
            return null;
        }

        public async Task Update(ProductDTO product)
        {
            var content = JsonConvert.SerializeObject(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/Product", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result.ErrorMessage);
            }
        }
    }
}
