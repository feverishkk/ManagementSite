using CommonDatabase.Models.Accessories;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MyGameSite.DapperHelper;
using MyGameSite.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyGameSite.Controllers
{
    public class AccessoryController : Controller
    {
        private IGenericRepository<Belt> _beltRepository;
        private IGenericRepository<EarRing> _earRingRepository;
        private IGenericRepository<Neckless> _necklessRepository;
        private IGenericRepository<Ring1> _ringRepository;

        public AccessoryController(IGenericRepository<Belt> beltRepository, 
                                   IGenericRepository<EarRing> earRingRepository, 
                                   IGenericRepository<Neckless> necklessRepository, 
                                   IGenericRepository<Ring1> ringRepository)
        {
            _beltRepository = beltRepository;
            _earRingRepository = earRingRepository;
            _necklessRepository = necklessRepository;
            _ringRepository = ringRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Belt()
        {
            var result = _beltRepository.GetAll(nameof(Belt)).Result;

            return View(result);
        }

        public IActionResult EarRing()
        {
            var result = _earRingRepository.GetAll(nameof(EarRing)).Result;

            return View(result);
        }

        public IActionResult Neckless()
        {
            var result = _necklessRepository.GetAll(nameof(Neckless)).Result;

            return View(result);
        }

        public IActionResult Ring()
        {
            var result = _ringRepository.GetAll(nameof(Ring1)).Result;

            return View(result);
        }

    }
}
