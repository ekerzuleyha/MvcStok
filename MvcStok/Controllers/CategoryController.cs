using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORİLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORİLER p1) 
        {
            db.TBL_KATEGORİLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var value = db.TBL_KATEGORİLER.Find(id);
            db.TBL_KATEGORİLER.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBL_KATEGORİLER.Find(id);
            //kategori bilgilerinin olduğu view i döndürsün , neyi getiricek kategoriyi(kategoriden gelecek değerlerle bu viewi bize döndürsün)
            return View("KategoriGetir",kategori);

        }

        public ActionResult Güncelle(int id)
        {
            var value = db.TBL_KATEGORİLER.Find();
            return View();
        }
   

    }
}