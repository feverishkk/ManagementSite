using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.TotalItems;
using ManagementDbContext.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Management.Application.Interfaces.CommonDb.GenericRepository;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GetItemsController : ControllerBase
    {
        private readonly IGenericRepository<Belt> _beltRepo;
        private readonly IGenericRepository<EarRing> _earRingRepo;
        private readonly IGenericRepository<Acc> _accRepo;
        private readonly CommonDbContext _commonDbContext;

        public GetItemsController(IGenericRepository<Belt> beltRepo, IGenericRepository<EarRing> earRingRepo,
                                  IGenericRepository<Acc> accRepo, CommonDbContext commonDbContext)
        {
            _beltRepo = beltRepo;
            _earRingRepo = earRingRepo;
            _accRepo = accRepo;
            _commonDbContext = commonDbContext;
        }

        [HttpGet]
        public IActionResult GetBelt()
        {
            var belts = _beltRepo.GetAll();

            return Ok(belts);
        }

        [HttpGet]
        public IActionResult GetEarRings()
        {
            var earRings = _earRingRepo.GetAll();

            return Ok(earRings);
        }


        //[HttpGet]
        //public IActionResult GetAcc()
        //{
        //    var acc = _commonDbContext.Acc?.Include(a => a.Belt)?.Include(a => a.Neckless)
        //                                  ?.Include(a => a.EarRing)?.Include(a => a.Ring1)
        //                                  ?.Include(a => a.Ring2)?.DefaultIfEmpty().ToList()
        //                                  ?? new List<Acc>().DefaultIfEmpty();
        //    if (acc != null)
        //    {
        //        return Ok(acc);
        //    }

        //    return BadRequest();
        //}


    }
}
