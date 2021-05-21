using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {

            var degerler = db.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler cariler)
        {
            cariler.Durum = true;
            db.Carilers.Add(cariler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var bul = db.Carilers.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var bul = db.Carilers.Find(id);
            return View("CariGetir", bul);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var bul = db.Carilers.Find(cariler.CariId);
            bul.CariAd = cariler.CariAd;
            bul.CariSoyad = cariler.CariSoyad;
            bul.CariSehir = cariler.CariSehir;
            bul.CariMail = cariler.CariMail;
            db.SaveChanges();
            return RedirectToAction("Incex");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = db.SatisHarakets.Where(x => x.CariId == id).ToList();
            var cr = db.Carilers.Where(x => x.CariId == id).Select(x => x.CariAd + " " + x.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}