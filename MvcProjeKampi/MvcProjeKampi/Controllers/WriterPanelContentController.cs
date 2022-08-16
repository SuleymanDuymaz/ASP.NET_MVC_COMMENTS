using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;


namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string param)
        {
            Context context = new Context();


            param = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(p => p.WriterMail == param)
                .Select(x => x.WriterID).FirstOrDefault();

            var contentvalues = contentManager.GetListByWriter(writeridinfo);
            
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
           string mail = (string)Session["WriterMail"];
            int idinfo = context.Writers.Where(p => p.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            content.WriterID = idinfo;

             contentManager.ContentAdd(content);


            return RedirectToAction("MyContent");
        }
    }
}