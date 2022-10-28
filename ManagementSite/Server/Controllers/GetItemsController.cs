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
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.Weapons;
using CommonDatabase.Models.Customers;

namespace ManagementSite.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public partial class GetItemsController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;

        private readonly IGenericRepository<Belt> _beltRepo;
        private readonly IGenericRepository<EarRing> _earRingRepo;
        private readonly IGenericRepository<Acc> _accRepo;
        private readonly IGenericRepository<Armor> _armorRepo;
        private readonly IGenericRepository<Dagger> _daggerRepo;
        private readonly IGenericRepository<CustomerTotalWeapons> _customerTotalWeaponRepo;
        
        public GetItemsController(CommonDbContext commonDbContext, IGenericRepository<Dagger> daggerRepo,
                                  IGenericRepository<Belt> beltRepo, IGenericRepository<EarRing> earRingRepo,
                                  IGenericRepository<Acc> accRepo, IGenericRepository<Armor> armorRepo,
                                  IGenericRepository<CustomerTotalWeapons> customerTotalWeaponRepo)
        {
            _commonDbContext = commonDbContext;
            _daggerRepo = daggerRepo;
            _beltRepo = beltRepo;
            _earRingRepo = earRingRepo;
            _accRepo = accRepo;
            _armorRepo = armorRepo;
            _customerTotalWeaponRepo = customerTotalWeaponRepo;
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

        public IActionResult GetAllWeapons()
        {
            var result = _customerTotalWeaponRepo.GetAll();

            return Ok(result);
        }




    }
}
