using Blazored.LocalStorage;
using Management.Application.Authentication;
using Management.Application.Dto.Account;
using Management.Application.Interfaces;
using Management.Domain.Models;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AccountService(HttpClient httpClient, ILocalStorageService localStorage, 
                              AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<RegisterResult> Register(RegisterDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Register", registerDto);
            return await response.Content.ReadFromJsonAsync<RegisterResult>();
        }

        public async Task<LoginResult> Login(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Login", loginDto);
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });    
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).AuthenticateUser(loginDto.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<ChangePasswordResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var result = await _httpClient.PostAsJsonAsync("Account/ChangePassword", changePasswordDto);
            return await result.Content.ReadFromJsonAsync<ChangePasswordResult>();
        }

        public async Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _httpClient.PostAsJsonAsync("Account/ForgotPassword", forgotPasswordDto);
            return await result.Content.ReadFromJsonAsync<ForgotPasswordResult>();
        }

        public async Task<ResetPasswordResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await _httpClient.PostAsJsonAsync("Account/ResetPassword", resetPasswordDto);
            return await result.Content.ReadFromJsonAsync<ResetPasswordResult>();
        }

    }
}
