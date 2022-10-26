using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;

        public ChartController(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }

        [HttpGet]
        public IActionResult GetUserClassChart()
        {
            var result = _commonDbContext.CustomerInGameInfo.OrderBy(u=>u.UserClass)
                                      .Select(u => u.UserClass).Take(100000).Distinct().ToList();
            
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUserGenderChart()
        {
            var data = _commonDbContext.Customers.OrderBy(u => u.Gender).Select(u => u.Gender)
                                                 .Distinct().Take(100000).ToList();

            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetWhoIsTheHighPaidCash()
        {
            // 나중에 좀 고쳐야 함..
            // 아님 빼던가
            var result = _commonDbContext.Customers.OrderByDescending(u => u.PaidCash).Select(u=>u.PaidCash)
                                         .Take(10).ToList();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetActiveUsers()
        {
            // 0 : NonActive
            // 1 : Active
            // 2 : NonActive soon
            var result = _commonDbContext.Customers.OrderBy(x=>x.Gender).Select(x => x.IsActive)
                                                   .Take(100000).Distinct().ToList();

            return Ok(result);
        }


    }
}
