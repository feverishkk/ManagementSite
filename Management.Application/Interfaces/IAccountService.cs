using Management.Application.Dto.Account;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResult> Register(RegisterDto registerDto);
    }
}