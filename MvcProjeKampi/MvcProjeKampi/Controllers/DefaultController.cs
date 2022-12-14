using Business.Concrete;
using DataAccess.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());


        public ActionResult Headings()
        {
            var headinglist=headingManager.GetList();
            return View(headinglist);

        }
       public PartialViewResult Index(int id=0)
        {
            var contenxtlist = contentManager.GetListByHeadingId(id);

            return PartialView(contenxtlist);

        }
    }
}