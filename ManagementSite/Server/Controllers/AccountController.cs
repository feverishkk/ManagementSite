using Microsoft.AspNetCore.Mvc;
using Management.Application.Interfaces;
using System.Threading.Tasks;
using Management.Application.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Management.Domain.Models;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Management.Application.Validator;
using Microsoft.AspNetCore.Http;
using Management.Application.Enums.Roles;
using ManagementDbContext.DbContext;
using Microsoft.Extensions.Logging;
using Management.Application.Log;

namespace ManagementSite.Server.Controllers
{
    /// <summary>
    /// 계정 관련
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IConfiguration _configuration;
        private readonly IEmailSenderRepository _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                 IConfiguration configuration, IEmailSenderRepository emailSender, RoleManager<IdentityRole> roleManager,
                                 IHttpContextAccessor httpContextAccessor, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid || registerViewModel == null)
            {
                return BadRequest();
            }

            RegisterValidator registerValidator = new RegisterValidator();
            var validationResult = registerValidator.Validate(registerViewModel);
            if (validationResult.IsValid is false)
            {
                return BadRequest(validationResult.Errors);
            }

            if ((await _userManager.FindByEmailAsync(registerViewModel.Email)) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                    ConfirmEmail = registerViewModel.ConfirmEmail,
                    Password = registerViewModel.Password,
                    Department = registerViewModel.Department,
                    DepartmentNumber = registerViewModel.DepartmentNumber,
                    GivenName = registerViewModel.GivenName,
                    FamilyName = registerViewModel.FamilyName,
                    MemberSince = DateTime.UtcNow.Date
                };

                if (!(await _roleManager.RoleExistsAsync(registerViewModel.Role.ToString())))
                {
                    var role = new IdentityRole
                    {
                        Name = registerViewModel.Role.ToString(),
                    };
                    var roleResult = await _roleManager.CreateAsync(role);
                    if (roleResult.Succeeded == false)
                    {
                        var errors = roleResult.Errors.Select(e => e.Description);
                        ModelState.AddModelError("Role", string.Join(",", errors));
                        return Ok(new RegisterResult { Successful = false, Errors = errors });
                    }
                }
                var passwordMatch1 = registerViewModel.Password;
                var passwordMatch2 = registerViewModel.ConfirmPassword;
                if (passwordMatch1 == passwordMatch2)
                {
                    var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                    if (result.Succeeded == false)
                    {
                        var errors = result.Errors.Select(errors => errors.Description);

                        return Ok(new RegisterResult { Successful = false, Errors = errors });
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, registerViewModel.Role.ToString());

                        string subject = "Confirmation Email Address";
                        //userId에 Email이 포함된다.
                        var userId = await _userManager.FindByIdAsync(user.Id);
                        var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account",
                                                          new { userId = userId, token = emailToken },
                                                          protocol: HttpContext.Request.Scheme);

                        await _emailSender.SendEmail(user.Email, subject, confirmationLink);
                    }
                }
            }
            GetLogInfo(registerViewModel.Email);
            return Ok(new RegisterResult { Successful = true });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid || loginViewModel == null)
            {
                return BadRequest();
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                var checkPassword = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

                if (user == null)
                {
                    return BadRequest();
                }
                if (checkPassword == false)
                {
                    return BadRequest();
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
                    if (!result.Succeeded)
                    {
                        //실패
                        return Ok(new LoginResult
                        {
                            Successful = false,
                            Errors = "User Name or Password is not correct!"
                        });
                    }
                    else
                    {
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, loginViewModel.Email),
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:SecretKey"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JWTSettings:JwtExpiryInDays"]));

                        var token = new JwtSecurityToken(
                            _configuration["JwtIssuer"],
                            _configuration["JwtAudience"],
                            claims,
                            expires: expiry,
                            signingCredentials: creds
                            );

                        GetLogInfo(loginViewModel.Email);
                        return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel changePasswordViewModel)
        {
            var user = _userManager.FindByEmailAsync(changePasswordViewModel.Email);
            if (user == null || changePasswordViewModel == null)
            {
                return BadRequest();
            }

            ChangePasswordValidator changePWValidator = new ChangePasswordValidator();
            var validationResult = changePWValidator.Validate(changePasswordViewModel);
            if (validationResult.IsValid is false)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _userManager.ChangePasswordAsync(await user, changePasswordViewModel.OldPassword,
                                                                changePasswordViewModel.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest();
            }
            else
            {
                GetLogInfo(changePasswordViewModel.Email);
                return Ok(new ChangePasswordResult { Successful = true });
            }

        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
            if (user == null || !ModelState.IsValid)
            {
                return Ok(new ForgotPasswordResult { Successful = false, Error = "User Id cannot be null" });
            }

            ForgotPasswordValidator forgotPWValidator = new ForgotPasswordValidator();
            var validationResult = forgotPWValidator.Validate(forgotPasswordViewModel);
            if (validationResult.IsValid is false)
            {
                return BadRequest(validationResult.Errors);
            }
            else
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var generateLink = Url.Action(nameof(ResetPassword), "Account",
                                              new { userId = forgotPasswordViewModel.Email, token = token },
                                              protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmail(forgotPasswordViewModel.Email, "Reset your Password", generateLink);

                GetLogInfo(forgotPasswordViewModel.Email);
                return Ok(new ForgotPasswordResult { Successful = true });
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel resetPasswordViewModel)
        {
            if (resetPasswordViewModel == null || !ModelState.IsValid)
            {
                return Ok(new ResetPasswordResult { Successful = false, Errors = "Please Refresh and Try Again." });
            }
            ResetPasswordValidator resetPWValidator = new ResetPasswordValidator();
            var validationResult = resetPWValidator.Validate(resetPasswordViewModel);
            if (validationResult.IsValid is false)
            {
                return BadRequest(validationResult.Errors);
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);

                if (user == null)
                {
                    return Ok(new ResetPasswordResult { Successful = false, Errors = "User Email cannot be null" });
                }
                else
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.ConfirmPassword);
                    if (!result.Succeeded)
                    {
                        return Ok(new ForgotPasswordResult { Successful = false, Error = "Something Went Wrong.. Please Try Again" });
                    }
                    else
                    {
                        GetLogInfo(resetPasswordViewModel.Email);
                        return Ok(new ResetPasswordResult { Successful = true });
                    }
                }
            }
        }

        private void GetLogInfo(string UserName)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var logResult = new AccountLog()
            {
                Host = context.Host.ToString(),
                Method = context.Method.ToString(),
                Path = context.Path.ToString(),
                Port = context.Host.Port.Value,
                UserName = UserName.ToString(),
                RemoteIpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                StatusCode = context.HttpContext.Response.StatusCode.ToString(),
            };
            Serilog.Log.Information("{@logResult}", logResult);
        }
    }
}
