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
    /// 아이템을 가져온다.
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class GetItemsController : ControllerBase
    {
        private readonly IGenericRepository<Belt> _beltRepo;
        private readonly IGenericRepository<EarRing> _earRingRepo;
        private readonly IGenericRepository<Neckless> _necklessRepo;
        private readonly IGenericRepository<Ring1> _ring1Repo;
        private readonly IGenericRepository<Ring2> _ring2Repo;

        private readonly IGenericRepository<Armor> _armorRepo;
        private readonly IGenericRepository<Boots> _bootsRepo;
        private readonly IGenericRepository<Cape> _capeRepo;
        private readonly IGenericRepository<Globe> _globeRepo;
        private readonly IGenericRepository<Guard> _guardRepo;
        private readonly IGenericRepository<Helmet> _helmetRepo;
        private readonly IGenericRepository<TShirt> _tshirtRepo;

        private readonly IGenericRepository<OneHandSword> _oneHandSwordRepo;
        private readonly IGenericRepository<TotalWeapons> _totalWeaponRepo;
        private readonly IGenericRepository<TotalEquipment> _totalEquipmentRepo;
        private readonly IGenericRepository<TotalAccessories> _totalAccRepo;

        public GetItemsController(IGenericRepository<OneHandSword> oneHandSwordRepo, IGenericRepository<Ring2> ring2Repo,
                                  IGenericRepository<Belt> beltRepo, IGenericRepository<EarRing> earRingRepo,
                                  IGenericRepository<Armor> armorRepo, IGenericRepository<Neckless> necklessRepo,
                                  IGenericRepository<TotalWeapons> totalWeaponRepo, IGenericRepository<TotalEquipment> equipmentRepo,
                                  IGenericRepository<TotalAccessories> totalAccRepo, IGenericRepository<Ring1> ring1Repo, 
                                  IGenericRepository<Boots> bootsRepo, IGenericRepository<Cape> capeRepo, 
                                  IGenericRepository<Globe> globeRepo, IGenericRepository<Guard> guardRepo, 
                                  IGenericRepository<Helmet> helmetRepo, IGenericRepository<TShirt> tshirtRepo)
        {
            _oneHandSwordRepo = oneHandSwordRepo;
            _beltRepo = beltRepo;
            _earRingRepo = earRingRepo;
            _armorRepo = armorRepo;
            _totalWeaponRepo = totalWeaponRepo;
            _totalEquipmentRepo = equipmentRepo;
            _totalAccRepo = totalAccRepo;
            _necklessRepo = necklessRepo;
            _ring1Repo = ring1Repo;
            _ring2Repo = ring2Repo;
            _bootsRepo = bootsRepo;
            _capeRepo = capeRepo;
            _globeRepo = globeRepo;
            _guardRepo = guardRepo;
            _helmetRepo = helmetRepo;
            _tshirtRepo = tshirtRepo;
        }


        [HttpGet]
        public IActionResult GetBelt()
        {
            var belts = _beltRepo.GetAll();

            return Ok(belts);
        }

        [HttpGet]
        public IActionResult GetNeckless()
        {
            var result = _necklessRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetEarRing()
        {
            var result = _earRingRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetRing1()
        {
            var result = _ring1Repo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetRing2()
        {
            var result = _ring2Repo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetBoots()
        {
            var result = _bootsRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCape()
        {
            var result = _capeRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGlobe()
        {
            var result = _globeRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGuard()
        {
            var result = _guardRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetHelmet()
        {
            var result = _helmetRepo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetTShirt()
        {
            var result = _tshirtRepo.GetAll();
            return Ok(result);
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
