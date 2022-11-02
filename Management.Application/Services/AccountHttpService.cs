using Blazored.LocalStorage;
using Management.Application.Authentication;
using Management.Application.ViewModel.Account;
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
    public class AccountHttpService : IAccountHttpRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AccountHttpService(HttpClient httpClient, ILocalStorageService localStorage, 
                              AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<RegisterResult> Register(RegisterViewModel registerViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Register", registerViewModel);
            return await response.Content.ReadFromJsonAsync<RegisterResult>();
        }

        public async Task<LoginResult> Login(LoginViewModel loginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Login", loginViewModel);
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });    
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).AuthenticateUser(loginViewModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<ChangePasswordResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            var result = await _httpClient.PostAsJsonAsync("Account/ChangePassword", changePasswordViewModel);
            return await result.Content.ReadFromJsonAsync<ChangePasswordResult>();
        }

        public async Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var result = await _httpClient.PostAsJsonAsync("Account/ForgotPassword", forgotPasswordViewModel);
            return await result.Content.ReadFromJsonAsync<ForgotPasswordResult>();
        }

        public async Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var result = await _httpClient.PostAsJsonAsync("Account/ResetPassword", resetPasswordViewModel);
            return await result.Content.ReadFromJsonAsync<ResetPasswordResult>();
        }

    }
}
