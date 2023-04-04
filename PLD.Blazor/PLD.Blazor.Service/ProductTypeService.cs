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
    public sealed class ProductTypeService : IProductTypeService
    {
        private readonly HttpClient _httpClient;
        public ProductTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductTypeDTO?> Create(ProductTypeDTO productType)
        {
            var content = JsonConvert.SerializeObject(productType);
            var bodyContent = new StringContent(content,Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/ProductType" , bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ProductTypeDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync("/api/ProductType/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }

        public async Task<IEnumerable<ProductTypeDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/ProductType");
            var emptyList = new List<ProductTypeDTO>();

            if (response.IsSuccessStatusCode)
            {
                var respoonseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<ProductTypeDTO>>(respoonseContent);

                return result ?? emptyList;
            }
            return emptyList;
        }

        public async Task<ProductTypeDTO?> GetByCode(string code)
        {
            var response = await _httpClient.GetAsync("/api/ProductType/GetByCode/" + code);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ProductTypeDTO>(responseContent);

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

        public async Task<IEnumerable<ProductTypeDTO>?> GetByCodeAndNotID(string code, int id)
        {
            var response = await _httpClient.GetAsync("/api/ProductType/GetByCodeAndNotID/" + code + "/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var  result = JsonConvert.DeserializeObject<IEnumerable<ProductTypeDTO>>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<ProductTypeDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync("/api/Producttype/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {                
                var result = JsonConvert.DeserializeObject<ProductTypeDTO>(responseContent);
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

        public async Task Update(ProductTypeDTO productType)
        {
            var content = JsonConvert.SerializeObject(productType);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/ProductType", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel?.ErrorMessage);
            }
        }
    }
}
