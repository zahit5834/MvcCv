﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCv001Entities db = new DbCv001Entities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkinda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.Tbl_SosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.Tbl_Egitimler.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yetenekler()
        {
            var yetenekler = db.Tbl_Yetenekler.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobiler()
        {
            var hobiler = db.Tbl_Hobiler.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.Tbl_Sertifikalar.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Tbl_Iletisim i)
        {
            i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Iletisim.Add(i);
            db.SaveChanges();
            return PartialView();
        }

    }
}