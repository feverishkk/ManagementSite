using Management.Application.ViewModel.Managers;
using Management.Domain.Models;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSite.Server.Controllers
{
    /// <summary>
    /// 사이트 담당 운영자들 정보
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManagerController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetAllManagers()
        {
            var userRoleList = _dbContext.ApplicationUsers.ToList();
            var userRole = _dbContext.UserRoles.ToList();
            var roles = _dbContext.Roles.ToList();

            foreach (var user in userRoleList)
            {
                var role = userRole.FirstOrDefault(obj => obj.UserId == user.Id);

                if (role == null)
                {
                    user.Role = "None";
                }

                else
                {
                    user.Role = roles.FirstOrDefault(user => user.Id == role.RoleId).Name;
                }
            }

            return Ok(userRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> GetManagersInfo([FromBody] string userId)
        {
            var CurrentUser = await _userManager.FindByIdAsync(userId);

            return Ok(new ManagerResult { Successful = true, AppUsers = CurrentUser });
        }

        [HttpPost]
        public async Task<IActionResult> GetUserRole([FromBody] string userId)
        {
            var CurrentUserId = await _userManager.FindByIdAsync(userId);
            var role = _userManager.GetRolesAsync(CurrentUserId)?.Result;
            var result = role[0];

            return Ok(new ManagerResult { Successful = true, Roles = result });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteManager([FromBody] string userId)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return Ok(new ManagerResult { Successful = false, Error = "User is null" });
            }
            else
            {
                _dbContext.ApplicationUsers.Remove(user);
                await _dbContext.SaveChangesAsync();

                return Ok(new ManagerResult { Successful = true });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateManagerRole(ArrayList paramList)
        {
            if (paramList == null)
            {
                return Ok(new ManagerResult { Successful = false, Error = "user id is null" });
            }
            else
            {
                var userId = paramList[0].ToString();
                var role = paramList[1].ToString();
                var ChosenRole = paramList[2].ToString();

                var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == userId.ToString());
                if (user == null)
                {
                    return Ok(new ManagerResult { Successful = false, Error = "user is null" });
                }
                var oldUser = await _roleManager.FindByIdAsync(user.Id);

                // 유저의 현재 Role을 가져온다.
                var RoleId = await _roleManager.FindByNameAsync(role);

                // 유저의 현재 Role Id를 가져온다.
                var UpdateRoleId = await _roleManager.GetRoleIdAsync(RoleId);

                // 현재의 Role을 지운다.
                await _userManager.RemoveFromRoleAsync(user, role);

                // 선택한 Role을 추가한다.
                await _userManager.AddToRoleAsync(user, ChosenRole);

                return Ok(new ManagerResult { Successful = true });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateManagerInfo([FromBody] UpdateManagerInfoViewModel managerInfoDto)
        {
            if(managerInfoDto == null)
            {
                return Ok(new ManagerResult { Successful = false, Error = "Your data is null. Please Re-try!" });
            }

            var user = await _userManager.FindByIdAsync(managerInfoDto.UserId);
            if(user == null)
            {
                return Ok(new ManagerResult { Successful = false, Error = "Cannot find user!" });
            }
            else
            {
                user.FamilyName = managerInfoDto.FamilyName;
                user.GivenName = managerInfoDto.GivenName;
                user.Department = managerInfoDto.Department;
                user.DepartmentNumber = managerInfoDto.DepartmentNumber;

                _dbContext.ApplicationUsers.Update(user);
                await _dbContext.SaveChangesAsync();
            }

            return Ok(new ManagerResult { Successful = true, AppUsers = user });
        }

    }
}
