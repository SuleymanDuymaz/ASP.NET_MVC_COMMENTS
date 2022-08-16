using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminresult=adminManager.GetList();
            return View(adminresult);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueadmin = (from p in adminManager.GetList()


                                                  select new SelectListItem
                                                  {
                                                      Text = p.AdminRole,
                                                      Value = p.AdminID.ToString()
                                                  }
                                               ).ToList();
            ViewBag.valueadmin = valueadmin;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return View();
        }
    }
}