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
            //yeni kategori ekleme işlemi sırasında eğer modelin durumunda doğrulama işlemi yapılmadıysa, yeni kategori ekleme view ini geri döndür.
            //doğrulanma işlemi yapılmadıysa ,doğrulama işlemi yapılmadıysa
            if (!ModelState.IsValid) 
            {
                return View("YeniKategori");
            }

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

        public ActionResult Güncelle(TBL_KATEGORİLER p1)
        {
            var value = db.TBL_KATEGORİLER.Find(p1.kategoriıd);
            value.kategoriad = p1.kategoriad;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
   

    }
}