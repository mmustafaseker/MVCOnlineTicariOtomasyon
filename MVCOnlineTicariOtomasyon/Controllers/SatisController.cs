using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.SatisHarakets.ToList();
            return View(degerler);
        }
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in db.Uruns.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.UrunAd,
                                           Value = x.UrunId.ToString()
                                       }).ToList();
            List<SelectListItem> deger2 = (from x in db.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();

            ViewBag.urun = deger1;
            ViewBag.cari = deger2;
            ViewBag.personel = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHaraket satis)
        {
            satis.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarakets.Add(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in db.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();

            ViewBag.urun = deger1;
            ViewBag.cari = deger2;
            ViewBag.personel = deger3;
            var deger = db.SatisHarakets.Find(id);
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGuncelle(SatisHaraket p)
        {
            var deger = db.SatisHarakets.Find(p.SatisId);
            deger.CariId = p.CariId;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.PersonelId = p.PersonelId;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.UrunId = p.UrunId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var dgr = db.SatisHarakets.Where(x => x.SatisId == id).ToList();
            return View(dgr);

        }

    }
}