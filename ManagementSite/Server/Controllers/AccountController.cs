using Microsoft.AspNetCore.Mvc;
using Management.Application.Interfaces;
using System.Threading.Tasks;
using Management.Application.Dto.Account;
using Microsoft.AspNetCore.Identity;
using Management.Domain.Models;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace ManagementSite.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                IConfiguration configuration, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid || registerDto == null)
            {
                return BadRequest();
            }
            if ((await _userManager.FindByEmailAsync(registerDto.Email)) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                    ConfirmEmail = registerDto.ConfirmEmail,
                    Password = registerDto.Password,
                    Department = registerDto.Department,
                    DepartmentNumber = registerDto.DepartmentNumber,
                    GivenName = registerDto.GivenName,
                    FamilyName = registerDto.FamilyName,
                    MemberSince = DateTime.UtcNow.Date
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(errors => errors.Description);

                    return Ok(new RegisterResult { Successful = false, Errors = errors });
                }
                else
                {
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

            return Ok(new RegisterResult { Successful = true });
        }


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
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid || loginDto == null)
            {
                return BadRequest();
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                var checkPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);

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
                    var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
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
                            new Claim(ClaimTypes.Name, loginDto.Email)
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


                        return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
            }
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user = _userManager.FindByEmailAsync(changePasswordDto.Email);
            if (user == null || changePasswordDto == null)
            {
                return BadRequest();
            }

            var result = await _userManager.ChangePasswordAsync(await user, changePasswordDto.OldPassword, 
                                                                changePasswordDto.NewPassword);

            if(!result.Succeeded)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new ChangePasswordResult { Successful = true });
            }

        }


    }
}
