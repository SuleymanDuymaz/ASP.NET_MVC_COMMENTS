using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            var contactlist=contactManager.GetList();
            return View(contactlist);
        }
        public ActionResult ContactDetails(int id)
        {
            var contactvvalue=contactManager.GetById(id);
            return View(contactvvalue);
        }
        public ActionResult ContactPartial()
        {
            return PartialView();
        }
    }
}