using Management.Application.Dto.Account;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResult> Register(RegisterDto registerDto);
        Task<LoginResult> Login(LoginDto loginDto);
        Task Logout();
        Task<ChangePasswordResult> ChangePassword(ChangePasswordDto changePasswordDto);
        Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto);
        Task<ResetPasswordResult> ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}