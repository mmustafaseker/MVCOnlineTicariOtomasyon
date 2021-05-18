using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var urunler = db.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            db.Uruns.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urunSil = db.Uruns.Find(id);
            urunSil.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var urundeger = db.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn = db.Uruns.Find(urun.UrunId);
            urn.UrunAd = urun.UrunAd;
            urn.SatisFiyati = urun.SatisFiyati;
            urn.AlisFiyati = urun.AlisFiyati;
            urn.Durum = urun.Durum;
            urn.KategoriId = urun.KategoriId;
            urn.Marka = urun.Marka;
            urn.UrunGorsel = urun.UrunGorsel;
            urn.Stok = urun.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}