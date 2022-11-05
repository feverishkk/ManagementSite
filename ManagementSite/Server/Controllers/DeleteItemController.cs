using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using Management.Application.Log;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DeleteItemController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteItemController(CommonDbContext commonDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _commonDbContext = commonDbContext;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost]
        public IActionResult DeleteBelt([FromBody] int beltId)
        {
            if (beltId is 0)
            {
                return BadRequest();
            } 

            object[] objects = new object[]
            {
                new SqlParameter("@paramBeltId", beltId)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                ("DELETE FROM Belt WHERE BeltId = @paramBeltId", objects);

            if (items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(beltId);

            return Ok();
        }


        [HttpPost]
        public IActionResult DeleteArmor([FromBody] int armorId)
        {
            if (armorId is 0)
            {
                return BadRequest();
            }

            object[] objects = new object[]
            {
                new SqlParameter("paramArmorId", armorId)
            };

            int item = _commonDbContext.Database.ExecuteSqlRaw(
                "DELETE FROM Armor WHERE ArmorId = @paramArmorId", objects);

            if (item is 0)
            {
                return BadRequest();
            }

            GetLogInfo(armorId);
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteOneHandSword([FromBody] int oneHandSwordId)
        {
            if(oneHandSwordId is 0)
            {
                return BadRequest();
            }

            object[] objects = new object[]
            {
                new SqlParameter("paramOneHandSwordId", oneHandSwordId)
            };

            int item = _commonDbContext.Database.ExecuteSqlRaw(
                "DELETE FROM OneHandSword WHERE OneHandSwordId = @paramOneHandSwordId", objects);

            if(item is 0)
            {
                return BadRequest();
            }

            GetLogInfo(oneHandSwordId);
            return Ok();
        }

        private void GetLogInfo(object? Target = null)
        {
            var context = _httpContextAccessor.HttpContext.Request;

            var logResult = new CRUDLog()
            {
                Host = context.Host.ToString(),
                Method = context.Method.ToString(),
                Path = context.Path.ToString(),
                Port = context.Host.Port.Value,
                UserName = _httpContextAccessor.HttpContext.User.Identity.Name,
                Target = Target.ToString(),
                RemoteIpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                StatusCode = context.HttpContext.Response.StatusCode.ToString(),
            };

            Serilog.Log.Information("{@logResult}", logResult);
        }
    }
}
