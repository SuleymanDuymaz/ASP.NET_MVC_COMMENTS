using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Concrete;
using DataAccess.Concrete;
using FluentValidation.Results;
using Business.Validation;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
      

        // GET: WriterPanelMessage
        public ActionResult Inbox() 
        {
            string param = (string)Session["WriterMail"];
           
            var messagelist = messageManager.GetListInbox(param);


            return View(messagelist);
        }
        [HttpGet]
        public ActionResult MessageDetails(int id)
        {
            var messagedetailslist = messageManager.GetById(id);
            return View(messagedetailslist);

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
            string param = (string)Session["WriterMail"];
            ValidationResult validationResult = messageValidator.Validate(message);

            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToLongTimeString().ToString());
                message.SenderMail = param;

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
        public ActionResult SendBox()
        {
            string param = (string)Session["WriterMail"];
            var sendboxresult = messageManager.GetListSendBox(param);
            return View(sendboxresult);
        }



        public ActionResult MessagePartial()
        {
            return PartialView();
        }
    }
}