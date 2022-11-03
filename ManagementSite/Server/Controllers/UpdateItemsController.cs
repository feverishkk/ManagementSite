using CommonDatabase.Models.Accessories;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using Management.Application.Log;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UpdateItemsController : ControllerBase
    {
        private readonly IGenericRepository<Belt> _beltRepo;
        private readonly CommonDbContext _commonDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateItemsController(IGenericRepository<Belt> beltRepo, CommonDbContext commonDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _beltRepo = beltRepo;
            _commonDbContext = commonDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 고객들의 장비를 업데이트 한다.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateCustomerEquipment([FromBody] ArrayList userInfo)
        {
            var userSelectedValue = (int)(long)userInfo[0];
            var userId = userInfo[1].ToString();

            if (userId is null || userSelectedValue is 0)
            {
                return BadRequest();
            }

            object[] paramItems = new object[]
            {
                new SqlParameter("@paramUserId", userId),
                new SqlParameter("@paramSelectedValue", userSelectedValue)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                        ("UPDATE CustomerEquipment SET BeltId = @paramSelectedValue WHERE [ID] = @paramUserId ",
                        paramItems);

            if (items == 0)
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpPost]
        public IActionResult UpdateAccItem([FromBody] Belt arrayList)
        {
            if (arrayList is null)
            {
                return BadRequest();
            }

            var itemId = arrayList.BeltId;
            if (itemId is 0)
            {
                return BadRequest();
            }
            var itemImage = arrayList.Image.ToString();
            var itemName = arrayList.Name.ToString();
            var itemAc = arrayList.AC;
            var itemClass = arrayList.Class.ToString();
            var itemDesc = arrayList.Description.ToString();

            object[] paramItems = new object[]
            {
                new SqlParameter("@paramItemId", itemId),
                new SqlParameter("@paramItemImage", itemImage),
                new SqlParameter("@paramItemName", itemName),
                new SqlParameter("@paramItemAc",itemAc),
                new SqlParameter("@paramItemClass", itemClass),
                new SqlParameter("@paramItemDesc",itemDesc)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                        ("UPDATE Belt SET Image = @paramItemImage, Name = @paramItemName, AC = @paramItemAc, " +
                         "Class = @paramItemClass, Description = @paramItemDesc " +
                         "WHERE BeltId = @paramItemId", paramItems);

            if(items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(itemName);

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
