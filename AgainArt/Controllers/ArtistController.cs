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
            Artist objArtist = new ArtistController().ShowInfo(1);
            TempData["ArtistArt"] = objArtist;

            return View("PersonalData", objArtist);
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
            ClearAll();

            try
            {
                MVCArtistContext db = new MVCArtistContext();
                Artist dbArtista = db.Artista.FirstOrDefault(a => a.Id == objArtista.Id);

                dbArtista.About = objArtista.About;
                dbArtista.Email = objArtista.Email;
                dbArtista.Name = objArtista.Name;
                dbArtista.LastName = objArtista.LastName;
                dbArtista.TelephoneNumber = objArtista.TelephoneNumber;

                db.Entry<Artist>(dbArtista).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                Success(string.Format("The information was successfully saved in the database."), true);
            }
            catch
            {
                Danger("It looks like something went wrong. Please try again later.");
            }

            return RedirectToAction("Index");
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