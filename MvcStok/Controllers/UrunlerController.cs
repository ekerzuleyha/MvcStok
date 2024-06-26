﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult ÜrünListesi(string a)
        {
            //var values = from c in db.TBL_URUNLER select c;

            //if (!string.IsNullOrEmpty(a))
            //{
            //    values = values.Where(m=>m.ürünadı.Contains(a));
            //}

            //return View(values.ToList());


            var value = db.TBL_URUNLER.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult YeniÜrün()
        {
            //listeden öğe seç anlamına gelen yapı= kategori tablosunun listesini çek ve i ye ata 
            //bu listeyi seç (selectlistitem)
            //seçilen listenin text değeri i den gelen ad
            //value =i nin kategori id si
            // i de tbl kategoriden gelen değerleri ad ve id ye eşitlememizi sağlıyor
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriıd.ToString(),

                                             }).ToList();
            ViewBag.deger = degerler;                                           
            return View();

        }

        [HttpPost]
        public ActionResult YeniÜrün(TBL_URUNLER urun)
        {

            //kategoriyi dropdowndan seçip ekliycez.
            var kategori = db.TBL_KATEGORİLER.Where(m=>m.kategoriıd == urun.TBL_KATEGORİLER.kategoriıd).FirstOrDefault();
            urun.TBL_KATEGORİLER = kategori;
            db.TBL_URUNLER.Add(urun);
            db.SaveChanges();
            return RedirectToAction("ÜrünListesi");

        }

        public ActionResult Sil(int id)
        {
            var value = db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ÜrünListesi");
        }

        public ActionResult UrunGetir(int id)
        {
            var value = db.TBL_URUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBL_KATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriıd.ToString(),

                                             }).ToList();
            ViewBag.deger = degerler;

            return View("UrunGetir", value);
        }

        public ActionResult Guncelle(TBL_URUNLER p1)
        {
            var value = db.TBL_URUNLER.Find(p1.ürünıd);
            value.ürünadı = p1.ürünadı;
            value.marka = p1.marka;
            value.stok = p1.stok;
            //value.ürünkategorisi = p1.ürünkategorisi;
            var kategori = db.TBL_KATEGORİLER.Where(m => m.kategoriıd == p1.TBL_KATEGORİLER.kategoriıd).FirstOrDefault();
            value.ürünkategorisi = kategori.kategoriıd;
            value.fiyat = p1.fiyat;
            db.SaveChanges();
            return RedirectToAction("ÜrünListesi");
        }

    }
}