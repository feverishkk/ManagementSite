using CommonDatabase.Models.Weapons;
using Microsoft.AspNetCore.Mvc;
using MyGameSite.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyGameSite.Controllers
{
    public class WeaponController : Controller
    {
        private IGenericRepository<Dagger> _daggerRepository;
        private IGenericRepository<OneHandBow> _oneHandBowRepository;
        private IGenericRepository<OneHandStick> _oneHandStickRepository;
        private IGenericRepository<OneHandSword> _oneHandSwordRepository;
        private IGenericRepository<TwoHandBow> _twoHandBowRepository;
        private IGenericRepository<TwoHandStick> _twoHandStickRepository;
        private IGenericRepository<TwoHandSword> _twoHandSwordRepository;

        public WeaponController(IGenericRepository<OneHandBow> oneHandBowRepository, 
                                IGenericRepository<OneHandStick> oneHandStickRepository, 
                                IGenericRepository<OneHandSword> oneHandSwordRepository, 
                                IGenericRepository<Dagger> daggerRepository, 
                                IGenericRepository<TwoHandBow> twoHandBowRepository, 
                                IGenericRepository<TwoHandStick> twoHandStickRepository, 
                                IGenericRepository<TwoHandSword> twoHandSwordRepository)
        {
            _oneHandBowRepository = oneHandBowRepository;
            _oneHandStickRepository = oneHandStickRepository;
            _oneHandSwordRepository = oneHandSwordRepository;
            _daggerRepository = daggerRepository;
            _twoHandBowRepository = twoHandBowRepository;
            _twoHandStickRepository = twoHandStickRepository;
            _twoHandSwordRepository = twoHandSwordRepository;
        }

        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult Dagger()
        {
            var result = _daggerRepository.GetAll(nameof(Dagger)).Result;
            return View(result);
        }

        public IActionResult OneHandSword()
        {
            var result = _oneHandSwordRepository.GetAll(nameof(OneHandSword)).Result;
            return View(result);
        }
        public IActionResult TwoHandSword()
        {
            var result = _twoHandSwordRepository.GetAll(nameof(TwoHandSword)).Result;
            return View(result);
        }

        public IActionResult Bow()
        {
            var result = _oneHandBowRepository.GetAll(nameof(OneHandBow)).Result;
            var result2 = _twoHandBowRepository.GetAll(nameof(TwoHandBow)).Result;

            ViewBag.Result = result;
            ViewBag.Result2 = result2;
            return View();
        }
        public IActionResult Stick()
        {
            var result = _oneHandStickRepository.GetAll(nameof(OneHandStick)).Result;
            var result2 = _twoHandStickRepository.GetAll(nameof(TwoHandStick)).Result;

            ViewBag.Result = result;
            ViewBag.Result2 = result2;

            return View();
        }
       

    }
}
