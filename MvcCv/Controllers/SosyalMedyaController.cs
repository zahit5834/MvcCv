using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<Tbl_SosyalMedya> repo = new GenericRepository<Tbl_SosyalMedya>();
        public ActionResult Index()
        {
            var sosyalmedya = repo.List();
            
            return View(sosyalmedya);
        }
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(Tbl_SosyalMedya s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x =>  x.Id == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(Tbl_SosyalMedya p)
        {
            var hesap = repo.Find(x => x.Id == p.Id);
            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.icon = p.icon;
            hesap.Durum = true;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.Id == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        
    }
}