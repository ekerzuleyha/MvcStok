using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatışlarController : Controller
    {
        // GET: Satışlar

        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult SatışListesi()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Satısyap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Satısyap(TBL_SATIS p1)
        {
            db.TBL_SATIS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("SatışListesi");
        }
    }
}