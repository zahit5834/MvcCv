using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Serfitika
        GenericRepository<Tbl_Sertifikalar> repo = new GenericRepository<Tbl_Sertifikalar>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.Id == id);
            ViewBag.SertifikaId = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(Tbl_Sertifikalar t)
        {
            var sertifika = repo.Find(x => x.Id == t.Id);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(Tbl_Sertifikalar s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id) 
        {
            var sertifika = repo.Find(x => x.Id == id);

            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}