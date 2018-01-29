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
            ArtWorkController objAkController = new ArtWorkController();
            galleryObject.LstArtWork = objAkController.List();
            galleryObject.Artist = new ArtistController().ShowInfo(1);

            galleryObject.LstArtWorkCategory.Add(objAkController.SearchForCategory(ArtWork.EnumPaintingType.Figures));
            galleryObject.LstArtWorkCategory.Add(objAkController.SearchForCategory(ArtWork.EnumPaintingType.StillLife));
            galleryObject.LstArtWorkCategory.Add(objAkController.SearchForCategory(ArtWork.EnumPaintingType.Landscape));

            TempData["ArtistArt"] = galleryObject.Artist;

            return View("Gallery", galleryObject);
        }



    }
}