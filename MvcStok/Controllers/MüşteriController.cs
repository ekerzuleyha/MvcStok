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

        //burda bir parametre aracılığıyla değerleri gönderip kontrol edeceğiz.
        public ActionResult MüşteriListesi(string p)
        {
            // d yi müsteri tablosundan çek ve d ye ata select d d ye ata demek
            var degerler = from d in db.TBL_MUSTERİ select d;

            //string olan p boş veya null değilse bunu yap
            if (!string.IsNullOrEmpty(p))
            {
                //değerlere müşteri adında p geçenleri ekle
                degerler = degerler.Where(m => m.müsteriad.Contains(p));
            }

            return View(degerler.ToList());

            //var values = db.TBL_MUSTERİ.ToList(); 
            //return View(values);
        }


        [HttpGet]
        public ActionResult YeniMüşteri() 
        {
            return View();
        
        }

        [HttpPost]
        public ActionResult YeniMüşteri(TBL_MUSTERİ musteri)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMüşteri");
            }
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

        public ActionResult MüşteriGetir(int id)
        {
            var value = db.TBL_MUSTERİ.Find(id);
            return View("MüşteriGetir",value);
        }

        public ActionResult Güncelle(TBL_MUSTERİ p1) 
        {
            var value = db.TBL_MUSTERİ.Find(p1.müsteriıd);
            value.müsteriad = p1.müsteriad;
            value.müsterisoyad = p1.müsterisoyad;
            db.SaveChanges();
            return RedirectToAction("MüşteriListesi");
        }
    }
}