using CommonDatabase.Models.Equipment;
using Microsoft.AspNetCore.Mvc;
using MyGameSite.Interfaces;

namespace MyGameSite.Controllers
{
    public class EquipmentController : Controller
    {
        private IGenericRepository<Helmet> _helmetRepo;
        private IGenericRepository<TShirt> _tshirtRepo;
        private IGenericRepository<Armor> _armorRepo;
        private IGenericRepository<Cape> _capeRepo;
        private IGenericRepository<Globe> _globeRepo;
        private IGenericRepository<Boots> _bootsRepo;
        private IGenericRepository<Guard> _guardRepo;

        public EquipmentController(IGenericRepository<Helmet> helmetRepo, 
                                   IGenericRepository<TShirt> tshirtRepo, 
                                   IGenericRepository<Armor> armorRepo, 
                                   IGenericRepository<Cape> capeRepo, 
                                   IGenericRepository<Globe> globeRepo, 
                                   IGenericRepository<Boots> bootsRepo, 
                                   IGenericRepository<Guard> guardRepo)
        {
            _helmetRepo = helmetRepo;
            _tshirtRepo = tshirtRepo;
            _armorRepo = armorRepo;
            _capeRepo = capeRepo;
            _globeRepo = globeRepo;
            _bootsRepo = bootsRepo;
            _guardRepo = guardRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Helmet()
        {
            var result = _helmetRepo.GetAll(nameof(Helmet)).Result;

            return View(result);
        }

        public IActionResult TShirt()
        {
            var result = _tshirtRepo.GetAll(nameof(TShirt)).Result;

            return View(result);
        }

        public IActionResult Armor()
        {
            var result = _armorRepo.GetAll(nameof(Armor)).Result;

            return View(result);
        }

        public IActionResult Cape()
        {
            var result = _capeRepo.GetAll(nameof(Cape)).Result;

            return View(result);
        }

        public IActionResult Globe()
        {
            var result = _globeRepo.GetAll(nameof(Globe)).Result;

            return View(result);
        }

        public IActionResult Boots()
        {
            var result = _bootsRepo.GetAll(nameof(Boots)).Result;

            return View(result);
        }

        public IActionResult Guard()
        {
            var result = _guardRepo.GetAll(nameof(Guard)).Result;

            return View(result);
        }


    }
}
