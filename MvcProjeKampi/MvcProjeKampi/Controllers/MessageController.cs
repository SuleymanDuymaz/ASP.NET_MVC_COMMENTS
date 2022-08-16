using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using DataAccess.Concrete;
using FluentValidation.Results;
using Business.Validation;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager=new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        Context context = new Context();
        // GET: Message
        public ActionResult Inbox()
        {
            string param = (string)Session["AdminUserName"];
            int writeridinfo = context.Writers.Where(p => p.WriterMail == param).
                Select(x => x.WriterID).FirstOrDefault();
            var messagelist=messageManager.GetListInbox(param);

            return View(messagelist);
        }
        [HttpGet]
        public ActionResult MessageDetails(int id)
        {
            var messagedetailslist = messageManager.GetById(id);
            return View(messagedetailslist);
        }
        public ActionResult SendBox()
        {
            string param = (string)Session["AdminUserName"];
            var sendboxresult = messageManager.GetListSendBox(param);
            return View(sendboxresult);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult validationResult = messageValidator.Validate(message);

            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToLongTimeString().ToString());
                messageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
            
            
        }
    }
}