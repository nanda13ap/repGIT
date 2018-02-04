using AgainArt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using static AgainArt.Models.ArtWork;
using static AgainArt.Models.Util;
using System.Diagnostics;

namespace AgainArt.Controllers
{
    public class ArtWorkController : BaseAlertController
    {
        // GET: ArtWork
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(HttpPostedFileBase file, string txtArtDescription)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string savedFileName = string.Empty;
                    string savedThumbFile = string.Empty;

                    try
                    {
                        ArtWork objArtWork = new ArtWork();
                        //objArtWork.FileURL = file.FileName;
                        objArtWork.OriginalName = file.FileName;
                        objArtWork.IdArtista = 1;// na mao o codigo do artista
                        objArtWork.GeneratedName = Path.GetFileNameWithoutExtension(objArtWork.OriginalName) + "_" + Guid.NewGuid() + Path.GetExtension(objArtWork.OriginalName);
                        objArtWork.ImageData = new byte[file.ContentLength];
                        objArtWork.Description = txtArtDescription;
                        objArtWork.ContentType = file.ContentType;



                        //Save image to file
                        //var filename = image.FileName;
                        var filePathOriginal = Server.MapPath(Url.Content("~/Content/ArtWorkImages/Original"));
                        var filePathThumbnail = Server.MapPath(Url.Content("~/Content/ArtWorkImages/Thumbnail"));

                        savedFileName = Path.Combine(filePathOriginal, objArtWork.GeneratedName);
                        savedThumbFile = Path.Combine(filePathThumbnail, objArtWork.GeneratedName);

                        file.SaveAs(savedFileName);
                        objArtWork.FileURL = String.Format("~/Content/ArtWorkImages/Original/{0}", objArtWork.GeneratedName);



                        //Read image back from file and create thumbnail from it
                        var imageFile = savedFileName; //Path.Combine(Server.MapPath("~/Content/ArtWorkImages/Original"), objArtWork.GeneratedName);
                        using (var srcImage = Image.FromFile(imageFile))
                        using (var newImage = new Bitmap(100, 100))
                        using (var graphics = Graphics.FromImage(newImage))
                        using (var stream = new MemoryStream())
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100));
                            newImage.Save(stream, ImageFormat.Png);
                            objArtWork.ThumbNailURL = String.Format("~/Content/ArtWorkImages/ThumbNail/{0}", objArtWork.GeneratedName);
                            //HttpPostedFileBase oi = newImage;
                            newImage.Save(savedThumbFile);
                            //var thumbNew = File(stream.ToArray(), "image/png");

                            //artwork.ArtworkThumbnail = thumbNew.FileContents;


                        }

                        MVCArtistContext db = new MVCArtistContext();
                        objArtWork.Artista = db.Artista.FirstOrDefault(a => a.Id == 1);// VER NO SERVIDOR SE ELE CONSEGUE PESQUISAR O ARTISTA = 1
                        //////E NAO SEI MAIS
                        db.ArtWork.Add(objArtWork);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + " " + ex.Source + "" + ex.StackTrace + String.Format(" Caminho Original:{0} e caminho ThumbNail {1} ", savedFileName, savedThumbFile));


                    }
                }
            }

            return View("Index");

        }


        public ActionResult AddArt(HttpPostedFileBase file, ArtWork objArt)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            //if (ModelState.IsValid)
            //{
            if (file != null)
            {
                string savedFileName = string.Empty;
                string savedThumbFile = string.Empty;

                try
                {
                    ArtWork objArtWork = new ArtWork();
                    //objArtWork.FileURL = file.FileName;
                    objArtWork.OriginalName = file.FileName;
                    objArtWork.IdArtista = 1;// na mao o codigo do artista
                    objArtWork.GeneratedName = Path.GetFileNameWithoutExtension(objArtWork.OriginalName) + "_" + Guid.NewGuid() + Path.GetExtension(objArtWork.OriginalName);
                    objArtWork.ImageData = new byte[file.ContentLength];
                    objArtWork.Description = objArt.Description;
                    objArtWork.PaintingEnum = objArt.PaintingEnum;
                    objArtWork.PaintingType = (int)objArt.PaintingEnum;
                    objArtWork.ContentType = file.ContentType;

                    //Save image to file
                    var filePathOriginal = Server.MapPath(Url.Content("~/Content/ArtWorkImages/Original"));
                    var filePathThumbnail = Server.MapPath(Url.Content("~/Content/ArtWorkImages/Thumbnail"));

                    savedFileName = Path.Combine(filePathOriginal, objArtWork.GeneratedName);
                    savedThumbFile = Path.Combine(filePathThumbnail, objArtWork.GeneratedName);

                    file.SaveAs(savedFileName);

                    objArtWork.FileURL = String.Format("~/Content/ArtWorkImages/Original/{0}", objArtWork.GeneratedName);

                    //Read image back from file and create thumbnail from it
                    GenerateThumbSaveonServer(savedFileName, savedThumbFile, objArtWork);

                    InsertArtOnDataBase(objArtWork);

                    Success(string.Format("The information was successfully saved in the database."), true);
                }
                catch (Exception ex)
                {
                    DeleteFile(savedFileName, savedThumbFile);
                    Danger("It Looks like something went wrong. Please try again later." + ex.StackTrace);


                }
            }
            else
            {
                Warning("Please, select a file before proceeding.", true);
            }
            //}

            return View("IncludeArt");

        }

        private static void GenerateThumbSaveonServer(string savedFileName, string savedThumbFile, ArtWork objArtWork)
        {
            var imageFile = savedFileName; //Path.Combine(Server.MapPath("~/Content/ArtWorkImages/Original"), objArtWork.GeneratedName);
            using (var srcImage = Image.FromFile(imageFile))
            using (var newImage = new Bitmap(100, 100))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100));
                newImage.Save(stream, ImageFormat.Png);
                objArtWork.ThumbNailURL = String.Format("~/Content/ArtWorkImages/ThumbNail/{0}", objArtWork.GeneratedName);
                //HttpPostedFileBase oi = newImage;
                newImage.Save(savedThumbFile);
                //var thumbNew = File(stream.ToArray(), "image/png");

                //artwork.ArtworkThumbnail = thumbNew.FileContents;


            }
        }

        private static void InsertArtOnDataBase(ArtWork objArtWork)
        {
            MVCArtistContext db = new MVCArtistContext();
            objArtWork.Artista = db.Artista.FirstOrDefault(a => a.Id == 1);

            db.ArtWork.Add(objArtWork);
            db.SaveChanges();
        }

        private static void DeleteFile(string savedFileName, string savedThumbFile)
        {
            if (System.IO.File.Exists(savedFileName))
            {
                System.IO.File.Delete(savedFileName);
            }

            if (System.IO.File.Exists(savedThumbFile))
            {
                System.IO.File.Delete(savedFileName);

            }
        }

        public ActionResult List(ArtWork objSearch = null)
        {
            MVCArtistContext db = new MVCArtistContext();
            List<ArtWork> lstArtWork = null;

            if (objSearch == null || string.IsNullOrEmpty(objSearch.Description))
            {
                lstArtWork = db.ArtWork.ToList();
            }
            else
            {
                lstArtWork = db.ArtWork.Where(a => a.OriginalName.Contains(objSearch.OriginalName)).ToList();
            }

            return View("index", new Gallery() { LstArtWork = lstArtWork });
        }

        public List<ArtWork> List()
        {
            MVCArtistContext db = new MVCArtistContext();
            List<ArtWork> lstArtWork = null;

            lstArtWork = db.ArtWork.ToList();

            return lstArtWork;
        }

        public ArtWork SearchForCategory(EnumPaintingType type)
        {
            MVCArtistContext db = new MVCArtistContext();
            ArtWork objArtWork = null;

            int ptype = Convert.ToInt32(type);
            objArtWork = db.ArtWork.FirstOrDefault(a => a.PaintingType == ptype);

            return objArtWork;
        }

        public ActionResult IncludeArt()
        {
            return View("IncludeArt"); // FAZER DROP DOWN LIST COM PAINTING TYPE FIGURES
        }

        public ActionResult RemoveArt()
        {
            return View("RemoveArt", List());

        }

        [HttpPost]
        public ActionResult RemoveArt(ArtWork objArt)
        {
            return View("RemoveArt", new Gallery() { LstArtWork = List() });
        }

    }
}