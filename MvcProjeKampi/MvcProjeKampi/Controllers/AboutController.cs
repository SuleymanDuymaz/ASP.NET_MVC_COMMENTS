using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Concrete;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        [Authorize(Roles="A")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAction()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAction(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("AboutPartial");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

    }
}