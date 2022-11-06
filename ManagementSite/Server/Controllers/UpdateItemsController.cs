using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
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
            var model = userInfo[2].ToString();

            if (userId is null || userSelectedValue is 0)
            {
                return BadRequest();
            }

            object[] paramItems = new object[]
            {
                new SqlParameter("@paramUserId", userId),
                new SqlParameter("@paramSelectedValue", userSelectedValue),
                new SqlParameter("@paramModel", model),
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw
                        ($"UPDATE CustomerEquipment SET {model}Id = @paramSelectedValue WHERE [ID] = @paramUserId ",
                        paramItems);

            if (items == 0)
            {
                return BadRequest();
            }

            GetLogInfo(userSelectedValue);

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateCustomerWeapon(ArrayList userInfo)
        {
            var userSelection = (int)(long)userInfo[0];
            var userId = userInfo[1].ToString();

            if(userId is null || userSelection is 0)
            {
                return BadRequest();
            }

            object[] parameItems = new object[]
            {
                new SqlParameter("@paramUserSelection", userSelection),
                new SqlParameter("@paramUserId", userId),
            };

            int item = _commonDbContext.Database.ExecuteSqlRaw(
                "UPDATE CustomerEquipment SET TotalWeaponId = @paramUserSelection " +
                "WHERE [ID] = @paramUserId ", parameItems);

            if (item is 0)
                return BadRequest();

            GetLogInfo(userSelection);

            return Ok();
        }

        /// <summary>
        /// Items목록에서 벨트, 갑옷, 한손검의 정보를 변경하는 기능.
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult UpdateBelt([FromBody] Belt belt)
        {
            if (belt is null || belt.BeltId is 0)
            {
                return BadRequest();
            }

            var itemId = belt.BeltId;
            var itemImage = belt.Image.ToString();
            var itemName = belt.Name.ToString();
            var itemAc = belt.AC;
            var itemClass = belt.Class.ToString();
            var itemDesc = belt.Description.ToString();

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

            GetLogInfo(belt.BeltId);

            return Ok();

        }

        [HttpPost]
        public IActionResult UpdateArmor([FromBody] Armor armor)
        {
            if(armor is null || armor.ArmorId is 0)
            {
                return BadRequest();
            }
            
            var itemId = armor.ArmorId;
            var itemName = armor.Name.ToString();
            var itemImage = armor.Image.ToString();
            var itemAc = armor.AC;
            var itemClass = armor.Class.ToString();
            var itemDesc = armor.Description.ToString();

            object[] paramItems = new object[]
            {
                new SqlParameter("@paramId", itemId),
                new SqlParameter("@paramName", itemName),
                new SqlParameter("@paramImage", itemImage),
                new SqlParameter("@paramAc", itemAc),
                new SqlParameter("@paramClass", itemClass),
                new SqlParameter("@paramDesc", itemDesc)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw(
                "UPDATE Armor SET Name = @paramName, Image = @paramImage, Ac = @paramAc, " +
                "Class = @paramClass, Description = @paramDesc " +
                "WHERE ArmorId = @paramId", paramItems);

            if(items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(armor.ArmorId);

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateOneHandSword([FromBody] OneHandSword oneHandSword)
        {
            if(oneHandSword is null || oneHandSword.OneHandSwordId is 0)
            {
                return BadRequest();
            }

            var itemId = oneHandSword.OneHandSwordId;
            var itemName = oneHandSword.Name.ToString();
            var itemImage = oneHandSword.Image.ToString();
            var itemDamage1 = oneHandSword.Damage1;
            var itemDamage2 = oneHandSword.Damage2;
            var itemClass = oneHandSword.Class.ToString();
            var itemDesc = oneHandSword.Description.ToString();

            object[] parameters = new object[]
            {
                new SqlParameter("paramId", itemId),
                new SqlParameter("paramName", itemName),
                new SqlParameter("paramImage", itemImage),
                new SqlParameter("paramDamage1", itemDamage1),
                new SqlParameter("paramDamage2", itemDamage2),
                new SqlParameter("paramClass",itemClass),
                new SqlParameter("paramDesc", itemDesc)
            };

            int items = _commonDbContext.Database.ExecuteSqlRaw(
                        "UPDATE OneHandSword SET Name = @paramName, Image = @paramImage, " +
                        "Damage1 = @paramDamage1, Damage2 = @paramDamage2, " +
                        "Class = @paramClass, Description = @paramDesc " +
                        "WHERE OneHandSwordId = @paramId", parameters);
            if(items is 0)
            {
                return BadRequest();
            }

            GetLogInfo(oneHandSword.OneHandSwordId);

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
                // 아래 UserName은 무언가를 적용한 사람이다.
                // Targeting이 되는 유저가 아님!!
                UserName = _httpContextAccessor.HttpContext.User.Identity.Name,
                Target = Target.ToString(),
                RemoteIpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                StatusCode = context.HttpContext.Response.StatusCode.ToString(),
            };

            Serilog.Log.Information("{@logResult}", logResult);
        }





    }
}
