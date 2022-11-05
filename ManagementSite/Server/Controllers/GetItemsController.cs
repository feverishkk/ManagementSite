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
    /// <summary>
    /// 개별 아이템을 가져온다.
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public partial class GetItemsController : ControllerBase
    {
        private readonly CommonDbContext _commonDbContext;

        private readonly IGenericRepository<Belt> _beltRepo;
        private readonly IGenericRepository<EarRing> _earRingRepo;
        private readonly IGenericRepository<Acc> _accRepo;
        private readonly IGenericRepository<Armor> _armorRepo;
        private readonly IGenericRepository<OneHandSword> _oneHandSwordRepo;
        private readonly IGenericRepository<TotalWeapons> _totalWeaponRepo;
        private readonly IGenericRepository<TotalEquipment> _totalEquipmentRepo;
        private readonly IGenericRepository<TotalAccessories> _totalAccRepo;
        
        public GetItemsController(CommonDbContext commonDbContext, IGenericRepository<OneHandSword> oneHandSwordRepo,
                                  IGenericRepository<Belt> beltRepo, IGenericRepository<EarRing> earRingRepo,
                                  IGenericRepository<Acc> accRepo, IGenericRepository<Armor> armorRepo,
                                  IGenericRepository<TotalWeapons> totalWeaponRepo, IGenericRepository<TotalEquipment> equipmentRepo,
                                  IGenericRepository<TotalAccessories> totalAccRepo)
        {
            _commonDbContext = commonDbContext;
            _oneHandSwordRepo = oneHandSwordRepo;
            _beltRepo = beltRepo;
            _earRingRepo = earRingRepo;
            _accRepo = accRepo;
            _armorRepo = armorRepo;
            _totalWeaponRepo = totalWeaponRepo;
            _totalEquipmentRepo = equipmentRepo;
            _totalAccRepo = totalAccRepo;
        }
        

        [HttpGet]
        public IActionResult GetBelt()
        {
            var belts = _beltRepo.GetAll();

            return Ok(belts);
        }

        [HttpGet]
        public IActionResult GetArmor()
        {
            var result = _armorRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetOneHandSword()
        {
            var result = _oneHandSwordRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllWeapons()
        {
            var result = _totalWeaponRepo.GetAll();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllEquipment()
        {
            var result = _totalEquipmentRepo.GetAll();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllAcc()
        {
            var result = _totalAccRepo.GetAll();

            return Ok(result);
        }
    }
}
