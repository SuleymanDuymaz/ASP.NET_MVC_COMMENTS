using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Concrete;
using DataAccess.Concrete;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var adminresult = context.Admins.FirstOrDefault(p => p.AdminUserName == admin.AdminUserName &&
            p.AdminPassword == admin.AdminPassword);
            if (adminresult != null)
            {
                FormsAuthentication.SetAuthCookie(adminresult.AdminUserName, false);
                Session["AdminUserName"] = adminresult.AdminUserName;
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            Context context = new Context();
            var writerresult = context.Writers.FirstOrDefault(p => p.WriterMail == writer.WriterMail &&
              writer.WriterPassword == p.WriterPassword);
            if (writerresult!=null)
            {
                FormsAuthentication.SetAuthCookie(writerresult.WriterMail, false);
                Session["WriterMail"] = writerresult.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Headings","Default");
        }

    }
}