using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using Management.Application.Dto.CommonDb.TotalItems;
using Management.Application.Interfaces.CommonDb;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;

        public WeaponController(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }

        //[HttpGet]
        //public IActionResult GetAllWeapons()
        //{
        //    var result = _commonDbContext.TotalWeapon.ToList();

        //    return Ok(result);
        //}

    }
}
