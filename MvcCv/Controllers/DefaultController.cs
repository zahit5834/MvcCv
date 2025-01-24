using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkinda.ToList();
            return View(degerler);
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

    }
}