using Microsoft.AspNetCore.Mvc;
using Management.Application.Interfaces;
using System.Threading.Tasks;
using Management.Application.Dto.Account;
using Microsoft.AspNetCore.Identity;
using Management.Domain.Models;
using System;
using System.Linq;

namespace ManagementSite.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                if(!result.Succeeded)
                {
                    var errors = result.Errors.Select(errors => errors.Description);

                    return Ok(new RegisterResult { Successful = false, Errors = errors });
                }
            }
            return Ok(new RegisterResult { Successful = true });

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
                if(checkPassword==false)
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
                        return Ok(new LoginResult { Successful = true });
                    }
                }
            }
        }





    }
}
