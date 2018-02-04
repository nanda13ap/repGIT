using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgainArt.Models;
namespace AgainArt.Controllers
{
    public class ArtistController : BaseAlertController
    {
        public ActionResult Index()
        {
            MVCArtistContext db = new MVCArtistContext();

            return View("PersonalData", db.Artista.FirstOrDefault());
        }

        public ActionResult PersonalData()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Details(int txtIdSearch)
        {
            MVCArtistContext db = new MVCArtistContext();
            Artist objArtista = db.Artista.FirstOrDefault(a => a.Id == txtIdSearch);

            return View("Index", new Gallery() { Artist = objArtista });
        }

        public Artist ShowInfo(int txtIdSearch)
        {
            MVCArtistContext db = new MVCArtistContext();
            Artist objArtista = db.Artista.FirstOrDefault(a => a.Id == txtIdSearch);
            return objArtista;
        }


        public ActionResult Insert(Gallery galeria)
        {
            MVCArtistContext db = new MVCArtistContext();
            db.Artista.Add(galeria.Artist);
            db.SaveChanges();

            return View("Index");
        }

        [HttpPost]
        public ActionResult ManageInfo(Artist objArtista)
        {
            try
            {
                MVCArtistContext db = new MVCArtistContext();
                Artist dbArtista = db.Artista.FirstOrDefault(a => a.Id == objArtista.Id);

                dbArtista.About = objArtista.About;
                dbArtista.Email = objArtista.Email;
                dbArtista.Name = objArtista.Name;
                dbArtista.LastName = objArtista.LastName;

                db.Entry<Artist>(dbArtista).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                Success(string.Format("The information was successfully saved in the database."), true);
            }
            catch
            {
                Danger("It Looks like something went wrong. Please try again later.");
            }

            return View("PersonalData");
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