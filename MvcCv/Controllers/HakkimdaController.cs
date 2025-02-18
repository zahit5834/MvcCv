﻿using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<Tbl_Hakkinda> repo = new GenericRepository<Tbl_Hakkinda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkında = repo.List();
            return View(hakkında);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkinda p)
        {
            var t = repo.Find(x => x.Id == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Fotograf = p.Fotograf;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}