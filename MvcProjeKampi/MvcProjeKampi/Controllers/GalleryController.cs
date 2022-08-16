using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageManager imageManager = new ImageManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var imageresult = imageManager.GetList();
            return View(imageresult);
        }
    }
}