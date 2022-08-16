using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Business.Validation;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();

        // GET: Heading
        
        public ActionResult Index()
        {
            var headingvalues = headingManager.GetList();
            return View(headingvalues);
        }
        [AllowAnonymous]
        public ActionResult HeadingReport()
        {
            var headingvalues = headingManager.GetList();
            return View(headingvalues);
        }
        [HttpGet]

        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from p in categoryManager.GetList()


                                                  select new SelectListItem
                                                  {
                                                      Text=p.CategoryName,
                                                      Value=p.CategoryID.ToString()
                                                  }
                                                ).ToList();

            

            List<SelectListItem> valuewriter = (from p in writerManager.GetList()


                                                  select new SelectListItem
                                                  {
                                                      Text = p.WriterName +" " +p.WriterSurname,
                                                      Value = p.WriterID.ToString()
                                                  }
                                              ).ToList();


            ViewBag.valuecategory = valuecategory;
            ViewBag.valuewriter = valuewriter;

            return View();  
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
           

           
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
                headingManager.HeadingAdd(heading);
                return RedirectToAction("Index");

           
       
            

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
            heading.HeadingStatus = true;

            return RedirectToAction("Index");

           
        }
        public ActionResult DeleteHeading(int id)
        {
            var valueheading = headingManager.GetById(id);
            valueheading.HeadingStatus = false;

            headingManager.HeadingDelete(valueheading);


            return RedirectToAction("Index"); 
        }
        
    }
}