using Management.Application.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<RegisterResult> Register(RegisterViewModel registerDto);
        Task<LoginResult> Login(LoginViewModel loginDto);
        Task Logout();
        Task<ChangePasswordResult> ChangePassword(ChangePasswordViewModel changePasswordDto);
        Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordDto);
        Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel resetPasswordDto);
    }
}