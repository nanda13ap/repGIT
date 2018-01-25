using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgainArt.Models;
namespace AgainArt.Controllers
{
    public class ArtistController : Controller
    {
        public ActionResult Index()
        {
            //MVCArtistContext db = new MVCArtistContext();
            //db.Artista.Add(new Artist() { Id = 2, Nome = "Rubens", About = "Legal" });
            //db.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult Details(int txtIdSearch)
        {
            MVCArtistContext db = new MVCArtistContext();
            Artist objArtista = db.Artista.FirstOrDefault(a => a.Id == txtIdSearch);

            return View("Index", new Gallery() { Artist = objArtista });
        }


        public ActionResult Insert(Gallery galeria)
        {
            MVCArtistContext db = new MVCArtistContext();
            db.Artista.Add(galeria.Artist);
            db.SaveChanges();

            return View("Index");
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}