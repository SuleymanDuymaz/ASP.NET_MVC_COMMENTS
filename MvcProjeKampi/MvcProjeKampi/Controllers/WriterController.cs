using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Concrete;
using Business.Validation;
using FluentValidation.Results;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var writervaluses = writerManager.GetList();
            return View(writervaluses);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult validationResult = writerValidator.Validate(writer);

            if (validationResult.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = writerManager.GetById(id);
            
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {   

            writerManager.WriterUpdate(writer);


            return RedirectToAction("Index");

            
        }
        [HttpGet]
        public ActionResult DeleteWriter(int id)
        {
            var writervalue = writerManager.GetById(id);
            writerManager.WriterDelete(writervalue);
            return RedirectToAction("Index");
        }

    }
}