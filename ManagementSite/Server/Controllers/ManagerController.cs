using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ManagerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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




    }
}
