using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Galeri
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        [Authorize(Roles = "A")]
        public ActionResult GalleryIndex()
        {
            var imageFiles = imageFileManager.GetAll();
            return View(imageFiles);
        }
    }
}