﻿using haberPortali1.Models;
using haberPortali1.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace haberPortali1.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class HaberTuruController : Controller
    {
        private readonly IHaberTuruRepository _haberTuruRepository;

        public HaberTuruController(IHaberTuruRepository context)
        {
            _haberTuruRepository = context;
        }

        public IActionResult Index()
        {
            List<HaberTuru> objHaberTuruList = _haberTuruRepository.GetAll().ToList();    
            return View(objHaberTuruList);
        }

        public IActionResult Ekle() 
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Ekle(HaberTuru haberTuru)
        {
            if(ModelState.IsValid)
            {
            _haberTuruRepository.Ekle(haberTuru);
            _haberTuruRepository.Kaydet();
                TempData["basarili"] = "Yeni Haber Türü Başarıyla Oluşturuldu";
            return RedirectToAction("Index","HaberTuru");
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            HaberTuru? haberTuruVt = _haberTuruRepository.Get(u=>u.Id==id);
            if (haberTuruVt == null)
            {
                return NotFound();
            }
            return View(haberTuruVt);
        }

        [HttpPost]
        public IActionResult Guncelle(HaberTuru haberTuru)
        {
            if (ModelState.IsValid)
            {
                _haberTuruRepository.Guncelle(haberTuru);
                _haberTuruRepository.Kaydet();
                TempData["basarili"] = "Haber Türü Başarıyla Güncellendi";
                return RedirectToAction("Index", "HaberTuru");
            }
            return View();
        }
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HaberTuru? haberTuruVt = _haberTuruRepository.Get(u => u.Id == id);
            if (haberTuruVt == null)
            {
                return NotFound();
            }
            return View(haberTuruVt);
        }


        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            HaberTuru? haberTuru = _haberTuruRepository.Get(u => u.Id == id);
            if (haberTuru == null)
            {
                return NotFound();
            }
            _haberTuruRepository.Sil(haberTuru);
            _haberTuruRepository.Kaydet();
            TempData["basarili"] = "Haber Türü Başarıyla Silindi";
            return RedirectToAction("Index", "HaberTuru");
        }

    }
}
