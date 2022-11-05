using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using Management.Application.Log;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSite.Server.Controllers
{
    /// <summary>
    /// 아이템 CRUD
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class CreateItemController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateItemController(CommonDbContext commonDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _commonDbContext = commonDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult CreateBelt([FromBody] Belt belt)
        {
            var accId = belt.BeltId;
            var accImageAddress = belt.Image;
            var accName = belt.Name;
            var ac = belt.AC;
            var accClass = belt.Class;
            var accDescription = belt.Description;

            if (accId is 0 || _commonDbContext.Belt.Any(x => x.BeltId == accId))
            {
                return BadRequest();
            }
            if (accImageAddress is null || accName is null || accName is null
                || ac > 0 || accClass is null || accDescription is null)
            {
                return BadRequest();
            }

            object[] paramItems = new object[]
            {
                new SqlParameter("@paramAccId", accId),
                new SqlParameter("@paramImageAddress", accImageAddress),
                new SqlParameter("@paramAccName", accName),
                new SqlParameter("@paramAc", ac),
                new SqlParameter("@paramAccClass", accClass),
                new SqlParameter("@paramAccDesc", accDescription)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                       ("INSERT INTO Belt (BeltId, Image, Name, AC, Class, Description) " +
                        "VALUES (@paramAccId, @paramImageAddress, @paramAccName, @paramAc, @paramAccClass, @paramAccDesc)",
                        paramItems);

            if (items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(accId);

            return Ok();

        }

        [HttpPost]
        public IActionResult CreateArmor([FromBody] Armor armor)
        {
            var eqpId = armor.ArmorId;
            var eqpImageAddress = armor.Image;
            var eqpName = armor.Name;
            var ac = armor.AC;
            var eqpClass = armor.Class;
            var eqpDescription = armor.Description;

            if (eqpId is 0 || _commonDbContext.Armor.Any(x => x.ArmorId == eqpId))
            {
                return BadRequest();
            }
            if (eqpImageAddress is null || eqpName is null || eqpName is null
                || ac > 0 || eqpClass is null || eqpDescription is null)
            {
                return BadRequest();
            }

            object[] paramItems = new object[]
            {
                new SqlParameter("@paramEqpId", eqpId),
                new SqlParameter("@paramImageAddress", eqpImageAddress),
                new SqlParameter("@paramEqpName", eqpName),
                new SqlParameter("@paramAc", ac),
                new SqlParameter("@paramEqpClass", eqpClass),
                new SqlParameter("@paramEqpDesc", eqpDescription)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                       ("INSERT INTO Armor (ArmorId, Image, Name, AC, Class, Description) " +
                        "VALUES (@paramEqpId, @paramImageAddress, @paramEqpName, @paramAc, @paramEqpClass, @paramEqpDesc)",
                        paramItems);

            if (items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(eqpId);

            return Ok();

        }

        [HttpPost]
        public IActionResult CreateOneHandSword([FromBody] OneHandSword oneHandSword)
        {
            var wpId = oneHandSword.OneHandSwordId;
            var wpImageAddress = oneHandSword.Image;
            var wpName = oneHandSword.Name;
            var Damage1 = oneHandSword.Damage1;
            var Damage2 = oneHandSword.Damage2;
            var wpClass = oneHandSword.Class;
            var wpDescription = oneHandSword.Description;

            if (wpId is 0 || _commonDbContext.OneHandSword.Any(x => x.OneHandSwordId == wpId))
            {
                return BadRequest();
            }
            if (wpImageAddress is null || wpName is null || wpName is null
                || Damage1 < 0 || Damage2 < 0 || wpClass is null || wpDescription is null)
            {
                return BadRequest();
            }

            object[] paramItems = new object[]
            {
                new SqlParameter("@paramWpId", wpId),
                new SqlParameter("@paramImageAddress", wpImageAddress),
                new SqlParameter("@paramWpName", wpName),
                new SqlParameter("@paramDamage1", Damage1),
                new SqlParameter("@paramDamage2", Damage2),
                new SqlParameter("@paramWpClass", wpClass),
                new SqlParameter("@paramWpDesc", wpDescription)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                       ("INSERT INTO OneHandSword (OneHandSwordId, Image, Name, Damage1, Damage2, Class, Description) " +
                        "VALUES (@paramWpId, @paramImageAddress, @paramWpName, @paramDamage1, @paramDamage2, @paramWpClass, @paramWpDesc)",
                        paramItems);

            if (items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(wpId);

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
