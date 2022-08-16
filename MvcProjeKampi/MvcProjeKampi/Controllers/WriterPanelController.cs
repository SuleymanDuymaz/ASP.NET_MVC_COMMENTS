using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using DataAccess.Concrete;
using PagedList.Mvc;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager=new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();

        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string param= (string)Session["WriterMail"];
             id = context.Writers.Where(p => p.WriterMail == param)
                .Select(x => x.WriterID).FirstOrDefault();
            var writervalue = writerManager.GetById(id);
            ViewBag.d = id;

            return View(writervalue);   
           
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {

            writerManager.WriterUpdate(writer);


            return RedirectToAction("MyHeading");


        }
        [HttpGet]
        public ActionResult MyHeading(string param, int page = 1)
        {
            

            param = (string)Session["WriterMail"];
            int writeridinfo = context.Writers.Where(p => p.WriterMail == param).
                Select(x => x.WriterID).FirstOrDefault();

          
            var headingresult = headingManager.GetListByWriter(writeridinfo).ToPagedList(page,10);
            return View(headingresult);
        }
        public ActionResult AllHeading(int page=1)
        {

            var allheadingresult = headingManager.GetList().ToPagedList(page,10);
            return View(allheadingresult);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            
            List<SelectListItem> valuecategory = (from p in categoryManager.GetList()


                                                  select new SelectListItem
                                                  {
                                                      Text = p.CategoryName,
                                                      Value = p.CategoryID.ToString()
                                                  }
                                              ).ToList();
            ViewBag.valuecategory = valuecategory;

            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string deger = (string)Session["WriterMail"];
            int writeridinfo = context.Writers.Where(p => p.WriterMail == deger).
                Select(x => x.WriterID).FirstOrDefault();


            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            heading.WriterID = writeridinfo;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);


            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valuecategory = (from p in categoryManager.GetList()


                                                  select new SelectListItem
                                                  {
                                                      Text = p.CategoryName,
                                                      Value = p.CategoryID.ToString()
                                                  }
                                               ).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = headingManager.GetById(id);

            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");


        }
        public ActionResult DeleteHeading(int id)
        {
            var valueheading = headingManager.GetById(id);
            valueheading.HeadingStatus = false; 

            headingManager.HeadingDelete(valueheading);


            return RedirectToAction("MyHeading");
        }


    }
}