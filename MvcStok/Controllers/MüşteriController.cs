using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MüşteriController : Controller
    {

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult MüşteriListesi()
        {
            var values = db.TBL_MUSTERİ.ToList(); 
            return View(values);
        }


        [HttpGet]
        public ActionResult YeniMüşteri() 
        {
            return View();
        
        }

        [HttpPost]
        public ActionResult YeniMüşteri(TBL_MUSTERİ musteri)
        {
            db.TBL_MUSTERİ.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("MüşteriListesi");

        }

        public ActionResult Sil(int id)
        {
            var silinecekdeğer = db.TBL_MUSTERİ.Find(id);
            db.TBL_MUSTERİ.Remove(silinecekdeğer);
            db.SaveChanges();
            return RedirectToAction("MüşteriListesi");
        }
    }
}