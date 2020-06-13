using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyAjax.Models;

namespace UdemyAjax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
           
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listele()
        {
            Thread.Sleep(10000);
            var jsonKullanicilar = JsonConvert.SerializeObject(KullaniciIslem.GetirHepsi());
            return Json(jsonKullanicilar);
        }

        [HttpPost]
        public IActionResult Ekle(Kullanici kullanici)
        {
            KullaniciIslem.Ekle(kullanici);
            var jsonKullanici = JsonConvert.SerializeObject(kullanici);
            return Json(jsonKullanici);
        }

        public IActionResult GetirIdile(int kullaniciId)
        {
            var bulunanKullanici = KullaniciIslem.GetirIdile(kullaniciId);
            var jsonKullanici = JsonConvert.SerializeObject(bulunanKullanici);
            return Json(jsonKullanici);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    
    }
}
