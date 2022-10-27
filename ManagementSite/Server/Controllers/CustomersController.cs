﻿using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            var userSelectedValue = (int)(long)userInfo[0];
            var userId = userInfo[1].ToString();

            if(userId is null || userSelectedValue is 0)
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

            if(items == 0)
            {
                return BadRequest();
            }

            return Ok();
        }




    }
}
