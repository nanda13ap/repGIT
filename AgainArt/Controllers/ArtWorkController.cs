using AgainArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgainArt.Controllers
{
    public class ArtWorkController : Controller
    {
        // GET: ArtWork
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ArtWork objArtWork)
        {
            if (ModelState.IsValid)
            {
                MVCArtistContext db = new MVCArtistContext();
                objArtWork.GeneratedName = objArtWork.OriginalName + "_" + Guid.NewGuid();
                db.ArtWork.Add(objArtWork);
                db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {


            return View();
        }

        public ActionResult List(ArtWork objSearch = null)
        {
            MVCArtistContext db = new MVCArtistContext();
            List<ArtWork> lstArtWork = null;

            if (objSearch == null)
            {
                lstArtWork = db.ArtWork.ToList();
            }
            else
            {
                lstArtWork = db.ArtWork.Where(a => a.OriginalName.Contains(objSearch.OriginalName)).ToList();
            }

            return View();
        }
    }
}