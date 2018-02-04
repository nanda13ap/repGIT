using AgainArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgainArt.Controllers
{
    public class GalleryController : BaseAlertController
    {
        // GET: Gallery
        public ActionResult Index()
        {
            MVCArtistContext db = new MVCArtistContext();

            Gallery galleryObject = new Gallery();
            ArtWorkController objAkController = GetArtistInfo(galleryObject);

            galleryObject.LstArtWorkCategory.Add(objAkController.SearchForCategory(Util.EnumPaintingType.Figures));
            galleryObject.LstArtWorkCategory.Add(objAkController.SearchForCategory(Util.EnumPaintingType.StillLife));
            galleryObject.LstArtWorkCategory.Add(objAkController.SearchForCategory(Util.EnumPaintingType.Landscape));

            TempData["ArtistArt"] = galleryObject.Artist;

            return View("Gallery", galleryObject);
        }

        private static ArtWorkController GetArtistInfo(Gallery galleryObject)
        {
            ArtWorkController objAkController = new ArtWorkController();
            galleryObject.LstArtWork = objAkController.List();
            galleryObject.Artist = new ArtistController().ShowInfo(1);
            return objAkController;
        }
    }
}