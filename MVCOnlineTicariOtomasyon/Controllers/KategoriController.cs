using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            db.Kategoris.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var silId = db.Kategoris.Find(id);
            db.Kategoris.Remove(silId);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGuncelle(int id)
        {
            var guncellenecekId = db.Kategoris.Find(id);
            return View("KategoriGuncelle", guncellenecekId); 
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktgr = db.Kategoris.Find(kategori.KategoriId);
            ktgr.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}