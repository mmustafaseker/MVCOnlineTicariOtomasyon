using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Personels.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            db.Personels.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var prs = db.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Personel personel)
        {
            var prsn = db.Personels.Find(personel.PersonelId);
            prsn.PersonelAd = personel.PersonelAd;
            prsn.PersonelSoyad = personel.PersonelSoyad;
            prsn.PersonelGorsel = personel.PersonelGorsel;
            prsn.DepartmanId = personel.DepartmanId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelSil(int id)
        {
            var personelId = db.Personels.Find(id);
            personelId.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}