using CommonDatabase.Models.Accessories;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UpdateItemsController : ControllerBase
    {
        private readonly IGenericRepository<Belt> _beltRepo;
        private readonly CommonDbContext _commonDbContext;

        public UpdateItemsController(IGenericRepository<Belt> beltRepo, CommonDbContext commonDbContext)
        {
            _beltRepo = beltRepo;
            _commonDbContext = commonDbContext;
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









    }
}
