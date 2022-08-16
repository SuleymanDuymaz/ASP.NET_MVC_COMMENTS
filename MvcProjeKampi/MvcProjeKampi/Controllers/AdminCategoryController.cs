    using Business.Concrete;
using Business.Validation;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        
        public ActionResult GetCategoryList()
        {
            var categoryList = categoryManager.GetList();


            return View(categoryList);
        }


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);

            if (validationResult.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            category.CategoryStatus = true;
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = categoryManager.GetById(id);
            categoryManager.CategoryDelete(categoryvalue);

            return RedirectToAction("GetCategoryList");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = categoryManager.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("GetCategoryList");
        }
        

    }
}