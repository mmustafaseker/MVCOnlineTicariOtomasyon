using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            db.Departmans.Add(departman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var silinecekId = db.Departmans.Find(id);
            silinecekId.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmanGetir(int id)
        {
            var guncellenecekId = db.Departmans.Find(id);
            return View("DepartmanGetir", guncellenecekId);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dept = db.Departmans.Find(departman.DepartmanId);
            dept.DepartmanAd = departman.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = db.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = db.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var dgr = db.SatisHarakets.Where(x => x.PersonelId == id).ToList();
            var per = db.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = per;
            return View(dgr);
        }
    }
}