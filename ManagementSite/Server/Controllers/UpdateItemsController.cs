using CommonDatabase.Models.Accessories;
using Management.Application.Interfaces.CommonDb.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UpdateItemsController : ControllerBase
    {
        private readonly IGenericRepository<Belt> _beltRepo;

        public UpdateItemsController(IGenericRepository<Belt> beltRepo)
        {
            _beltRepo = beltRepo;
        }


        //[HttpPost]
        //public IActionResult UpdateBelt([FromBody] ArrayList arrayList)
        //{
        //    var first = arrayList[0];
        //    var belt = _beltRepo.Update(first);
        //}


    }
}
