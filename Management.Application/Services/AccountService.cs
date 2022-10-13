using Management.Application.Dto.Account;
using Management.Application.Interfaces;
using Management.Domain.Models;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RegisterResult> Register(RegisterDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Register", registerDto);
            return await response.Content.ReadFromJsonAsync<RegisterResult>();
        }

        public async Task<LoginResult> Login(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/Account/Login", loginDto);
            return await response.Content.ReadFromJsonAsync<LoginResult>();
        }


    }
}
