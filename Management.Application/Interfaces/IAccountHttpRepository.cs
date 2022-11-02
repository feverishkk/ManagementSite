using Management.Application.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IAccountHttpRepository
    {
        Task<RegisterResult> Register(RegisterViewModel registerViewModel);
        Task<LoginResult> Login(LoginViewModel loginViewModel);
        Task Logout();
        Task<ChangePasswordResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel);
        Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel);
        Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel);
    }
}