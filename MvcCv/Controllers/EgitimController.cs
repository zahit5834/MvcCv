using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Tbl_Egitimler> repo = new GenericRepository<Tbl_Egitimler>();

        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitimler e)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(e);

            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            repo.TDelete(repo.TGet(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x => x.Id == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(Tbl_Egitimler e)
        {
            var egitim = repo.Find(x => x.Id == e.Id);
            egitim.Baslik = e.Baslik;
            egitim.AltBaslik = e.AltBaslik;
            egitim.AltBaslik2 = e.AltBaslik2;
            egitim.GNO = e.GNO;
            egitim.Tarih = e.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}