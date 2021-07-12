using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context db = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = db.Faturalars.ToList();
            return View(liste);
        }
    }
}