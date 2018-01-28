using AgainArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgainArt.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            MVCArtistContext db = new MVCArtistContext();

            Gallery galleryObject = new Gallery();
            galleryObject.LstArtWork = new ArtWorkController().List();

            galleryObject.Artist = new ArtistController().ShowInfo(1);

            TempData["ArtistArt"] = galleryObject.Artist;

            return View("Gallery", galleryObject);
        }

        

    }
}