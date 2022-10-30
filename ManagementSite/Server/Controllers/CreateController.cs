using CommonDatabase.Models.Accessories;
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
    public class CreateController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;

        public CreateController(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }

        [HttpPost]
        public IActionResult CreateAccItem([FromBody] Belt arrayList)
        {
            //var accId = (int)(long)arrayList[0];
            //var accImageAddress = arrayList[1].ToString();
            //var accName = arrayList[2].ToString();
            //var ac = (int)(long)arrayList[3];
            //var accClass = arrayList[4].ToString();
            //var accDescription = arrayList[5].ToString();

            var accId = arrayList.BeltId;
            var accImageAddress = arrayList.Image;
            var accName = arrayList.Name;
            var ac = arrayList.AC;
            var accClass = arrayList.Class;
            var accDescription = arrayList.Description;

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

            return Ok();

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

            if(items is 0)
            {
                return BadRequest();
            }

            return Ok();
        }





    }
}
