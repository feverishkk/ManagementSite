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
    public class DeleteController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteController(CommonDbContext commonDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _commonDbContext = commonDbContext;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost]
        public IActionResult DeleteAccItem([FromBody] int itemId)
        {
            if (itemId is 0)
            {
                return BadRequest();
            }

            object[] objects = new object[]
            {
                new SqlParameter("@paramBeltId", itemId)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                ("DELETE FROM Belt WHERE BeltId=@paramBeltId", objects);

            if (items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(itemId);

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
