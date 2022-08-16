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
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Content
       
        public ActionResult Index()
        {
            return View();
        }
        Context context = new Context();
        [AllowAnonymous]
        public ActionResult GetAllContent(string param)
        {
           
            
            //var values = context.Contents.ToList();
            var values = from x in context.Contents select x;
            if (!string.IsNullOrEmpty(param))
            {
                values = values.Where(y => y.ContentValue.Contains(param));
            }
            
                return View(values.ToList());
           
            
                
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetListByHeadingId(id);
            return View(contentvalues);

        }
    }
}