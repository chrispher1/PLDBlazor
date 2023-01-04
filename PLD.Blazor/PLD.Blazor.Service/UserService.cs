using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using PLD.Blazor.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PLD.Blazor.Common.Utilities.AuthenticationProviders;
using System.Net.Http.Headers;

namespace PLD.Blazor.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public UserService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<UserDTO> GetByUserName(string userName)
        {
            var response = await _httpClient.GetAsync($"/api/User/GetByUserName/{userName}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserDTO>(responseContent);
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

        public async Task<IEnumerable<UserDTO>> GetByUserNameAndNotID(string userName, int id)
        {
            var response = await _httpClient.GetAsync($"/api/User/GetByUserNameAndNotID/{userName}/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(responseContent);
                return result;
            }
            return null;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/User/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserDTO>(responseContent);
                return result;
            }            
            return null;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/User");
            var emptyList = new List<UserDTO>();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(responseContent);

                return result;
            }
            return emptyList;
        }

        public async Task<UserDTO> Login(UserForLoginDTO userForLoginDTO)
        {              
            var response = await _httpClient.GetAsync($"/api/User/login?UserName={userForLoginDTO.UserName}&Password={userForLoginDTO.Password}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserResponseDTO>(responseContent);

                //for token saving
                await _localStorage.SetItemAsync(ConstantClass.Local_Token, result.Token);
                await _localStorage.SetItemAsync(ConstantClass.Local_User, result.User);                
                (_authenticationStateProvider as WebAssemblyAuthenticationStateProvider)?.NotifyUserLoggedIn(result.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return result.User;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                if (errorModel.ErrorMessage == ConstantClass.NoRecordFound)
                {
                    throw new Exception(ConstantClass.UserNoRecordFound);
                }
                else
                {
                    throw new Exception(errorModel.ErrorMessage);
                }
            }
        }

        public async Task<UserDTO> Register(UserForRegisterDTO userForRegisterDTO)
        {
            var content = JsonConvert.SerializeObject(userForRegisterDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("/api/User/register", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserResponseDTO>(responseContent);
                //for token saving
                await _localStorage.SetItemAsync(ConstantClass.Local_Token, result.Token);
                await _localStorage.SetItemAsync(ConstantClass.Local_User, result.User);
                (_authenticationStateProvider as WebAssemblyAuthenticationStateProvider)?.NotifyUserLoggedIn(result.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return result.User;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
        public async Task<UserDTO> Create(UserDTO user)
        {
            var content = JsonConvert.SerializeObject(user);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/User", bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserDTO>(responseContent);
                return result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);

                throw new Exception(result.ErrorMessage);
            }            
        }
        public async Task Update(UserDTO user)
        {
            var content = JsonConvert.SerializeObject(user);
            var bodyContent = new StringContent(content,Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/User",bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseContent);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(ConstantClass.Local_Token);
            await _localStorage.RemoveItemAsync(ConstantClass.Local_User);

            ((WebAssemblyAuthenticationStateProvider)_authenticationStateProvider).NotifyUserLogout();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync("/api/User/" + id);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (! response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ErrorModelDTO> (responseContent);
                throw new Exception(result.ErrorMessage);
            }
        }
        
    }
}
