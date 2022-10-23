using CommonDatabase.Models;
using Management.Application.Interfaces;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var result = _commonDbContext.CustomerInGameInfo.Where(u=>u.ID == userId).ToList();
            return Ok(result);
        }

    }
}
