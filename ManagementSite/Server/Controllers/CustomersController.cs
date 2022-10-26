using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;
        private readonly IGenericRepository<Belt> _beltRepo;

        public CustomersController(CommonDbContext commonDbContext, IGenericRepository<Belt> beltRepo)
        {
            _commonDbContext = commonDbContext;
            _beltRepo = beltRepo;
        }


        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var result = _commonDbContext.Customers.ToList();
            Task.Delay(5000);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCustomersInGameInfo([FromQuery] string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }
            var result = _commonDbContext.CustomerInGameInfo.Where(u => u.ID == userId).ToList();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCustomerEquipment([FromQuery] string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var user = _commonDbContext.CustomerEquipment.Where(u => u.ID == userId);

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                var response = user.Include(i => i.TotalWeapons).Include(i => i.TShirt)
                                   .Include(i => i.Armor).Include(i => i.Cape).Include(i => i.Helmet)
                                   .Include(i => i.Neckless).Include(i => i.Ring1).Include(i => i.Ring2)
                                   .Include(i => i.Belt).Include(i => i.Boots).Include(i => i.EarRing)
                                   .Include(i => i.Guard).Include(i => i.Globe).ToList();

                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult UpdateCustomerEquipment([FromBody] ArrayList userInfo)
        {

            // 일단 파라미터를 들고 오는거 됌!
            // 
            var userSelectedValue = (int)(long)userInfo[0];
            var userId = userInfo[1].ToString();

            var user = _commonDbContext.CustomerEquipment.Where(x => x.ID == userId).Select(x => x.Belt);
            
            if (user!=null)
            {
                var userBeltId = user.Select(x => x.BeltId).FirstOrDefault() ?? 0;
                userBeltId = userSelectedValue;
                                
                //var userBelt = user.Belt.BeltId == null ? null : user.Belt.BeltId;
                
                //var users = user.Select(x => x.BeltId);
                //var userBeltId = users == null ? user.Select(x=>x.BeltId) : 0;
                
                //userBeltId = userBeltId!=null ? userBeltId.Value : 0;
                //userBeltId = userSelectedValue;

                //user.Belt.BeltId = userBeltId != null ? userBeltId : 0;
                _commonDbContext.CustomerEquipment.Update((CustomerEquipment)user);
                _commonDbContext.SaveChanges();
                return Ok(user);
            }

            //_commonDbContext.Belt.Update(user);

            // 1. userId와 바꿀 값을 들고 온다.      -------v
            // 2. CustomerEquipment의 Id를 비교하고 -------v
            // 3. CustomerEquipment의 프로퍼티를 정의해주고 -------v <<<<<< null 에러
            // 3. 해당 ID의 belt id를 update해준다.

            return Ok();
        }




    }
}
