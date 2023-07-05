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
    public class CaseService : ICaseService
    {
        private readonly HttpClient _httpClient;
        public CaseService(HttpClient httpClient) 
        { 
            this._httpClient = httpClient;
        }
        public async Task<CaseDTO?> Create(CaseDTO caseDTO)
        {
            var content = JsonConvert.SerializeObject(caseDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Case", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseDTO>(responseContent);
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
            var response = await _httpClient.DeleteAsync($"/api/Case/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }            
        }
        public async Task<PagedList<CaseDTO>> GetAll(GridParams gridParams, CaseAllSearchParams searchParams, string? sortParams = null)
        {
            var response = await _httpClient.GetAsync($"/api/Case?PageNumber={gridParams.PageNumber}&PageSize={gridParams.PageSize}" +
                $"&CarrierId={searchParams.CarrierId}" +
                $"&Policy={searchParams.Policy}" +
                $"&StatusId={searchParams.StatusId}" +
                $"&ProductTypeId={searchParams.ProductTypeId}" +
                $"&FaceAmount={searchParams.FaceAmount}" +
                $"&AnnualizedPremium={searchParams.AnnualizedPremium}" +
                $"&TargetPremium={searchParams.TargetPremium}"+
                $"&ModalPremium={searchParams.ModalPremium}" +
                $"&PlacementDate={searchParams.PlacementDate}" +
                $"&CaseTypeId={searchParams.CaseTypeId}" +
                $"&ProductId={searchParams.ProductId}" +
                $"&ClientFirstName={searchParams.ClientFirstName}" +
                $"&ClientLastName={searchParams.ClientLastName}" +
                (sortParams != null ? $"&SortParams={sortParams}" : "")
                );

            var responseContent = await response.Content.ReadAsStringAsync();

            var responseValue = JsonConvert.DeserializeObject<PaginationHeader>(response.Headers.GetValues("Pagination").First());

            var emptyList = new PagedList<CaseDTO>();

            if (response.IsSuccessStatusCode)
            {   
                var result = (JsonConvert.DeserializeObject<IEnumerable<CaseDTO>>(responseContent));
                var pagedListResult = new PagedList<CaseDTO>(result?.ToList() == null ? new List<CaseDTO>() : result.ToList(), responseValue?.TotalItems == null ? 0 : responseValue.TotalItems);

                return pagedListResult ?? emptyList;
            }
            else
            {
                return emptyList;
            }
        }

        public async Task<PagedList<CaseDTO>> GetForApproval(GridParams gridParams, CaseForApprovalSearchParams searchParams, string? sortParams = null)
        {
            var response = await _httpClient.GetAsync($"/api/Case/GetForApproval?PageNumber={gridParams.PageNumber}&PageSize={gridParams.PageSize}" +
                $"&CarrierId={searchParams.CarrierId}" +
                $"&Policy={searchParams.Policy}" +
                $"&StatusId={searchParams.StatusId}" +
                $"&ProductTypeId={searchParams.ProductTypeId}" +
                $"&FaceAmount={searchParams.FaceAmount}" +
                $"&AnnualizedPremium={searchParams.AnnualizedPremium}" +
                $"&TargetPremium={searchParams.TargetPremium}" +
                $"&ModalPremium={searchParams.ModalPremium}" +
                $"&PlacementDate={searchParams.PlacementDate}" +
                $"&CaseTypeId={searchParams.CaseTypeId}" +
                $"&ProductId={searchParams.ProductId}" +
                $"&ClientFirstName={searchParams.ClientFirstName}" +
                $"&ClientLastName={searchParams.ClientLastName}" +
                (sortParams != null ? $"&SortParams={sortParams}" : "")
                );

            var responseContent = await response.Content.ReadAsStringAsync();

            var responseValue = JsonConvert.DeserializeObject<PaginationHeader>(response.Headers.GetValues("Pagination").First());

            var emptyList = new PagedList<CaseDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = (JsonConvert.DeserializeObject<IEnumerable<CaseDTO>>(responseContent));
                var pagedListResult = new PagedList<CaseDTO>(result?.ToList() == null ? new List<CaseDTO>() : result.ToList(), responseValue?.TotalItems == null ? 0 : responseValue.TotalItems);

                return pagedListResult ?? emptyList;
            }
            else
            {
                return emptyList;
            }
        }

        public async Task<PagedList<CaseDTO>> GetComplete(GridParams gridParams, CaseCompleteSearchParams searchParams, string? sortParams = null)
        {
            var response = await _httpClient.GetAsync($"/api/Case/GetComplete?PageNumber={gridParams.PageNumber}&PageSize={gridParams.PageSize}" +
                $"&CarrierId={searchParams.CarrierId}" +
                $"&Policy={searchParams.Policy}" +
                $"&StatusId={searchParams.StatusId}" +
                $"&ProductTypeId={searchParams.ProductTypeId}" +
                $"&FaceAmount={searchParams.FaceAmount}" +
                $"&AnnualizedPremium={searchParams.AnnualizedPremium}" +
                $"&TargetPremium={searchParams.TargetPremium}" +
                $"&ModalPremium={searchParams.ModalPremium}" +
                $"&PlacementDate={searchParams.PlacementDate}" +
                $"&CaseTypeId={searchParams.CaseTypeId}" +
                $"&ProductId={searchParams.ProductId}" +
                $"&ClientFirstName={searchParams.ClientFirstName}" +
                $"&ClientLastName={searchParams.ClientLastName}" +
                (sortParams != null ? $"&SortParams={sortParams}" : "")
                );

            var responseContent = await response.Content.ReadAsStringAsync();

            var responseValue = JsonConvert.DeserializeObject<PaginationHeader>(response.Headers.GetValues("Pagination").First());

            var emptyList = new PagedList<CaseDTO>();

            if (response.IsSuccessStatusCode)
            {
                var result = (JsonConvert.DeserializeObject<IEnumerable<CaseDTO>>(responseContent));
                var pagedListResult = new PagedList<CaseDTO>(result?.ToList() == null ? new List<CaseDTO>() : result.ToList(), responseValue?.TotalItems == null ? 0 : responseValue.TotalItems);

                return pagedListResult ?? emptyList;
            }
            else
            {
                return emptyList;
            }
        }
        public async Task<CaseDTO?> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Case/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CaseDTO?>(responseContent);
                return result;
            }
            return null;
        }
        public async Task Update(CaseDTO caseDTO)
        {
            var content = JsonConvert.SerializeObject(caseDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/Case", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(result?.ErrorMessage);
            }
        }
    }
}
