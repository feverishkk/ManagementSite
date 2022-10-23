using CommonDatabase.Models;
using Management.Application.Dto.CommonDb.Customers;
using Management.Application.Interfaces;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using CommonDatabase.Models.Customers;
using Newtonsoft.Json;
using System.Text.Json;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;

        public CustomersController(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
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
            var result = _commonDbContext.CustomerInGameInfo.Where(u => u.ID == userId).ToList();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCustomerEquipment([FromQuery] string userId)
        {
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
    }
}
