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
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
            //var result = await _userManager.CreateAsync(user, registerDto.Password);

            //if(!result.Succeeded)
            //{
            //    var errors = result.Errors.Select(error => error.Description);
            //    return BadRequest(errors);
            //}

            //return StatusCode(201);

        }


    }
}
