﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    public class WriterMesajController : Controller
    {
        // GET: WriterMesaj
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            //string userEmail = Session["AdminUserName"].ToString();
            var messageList = messageManager.GetListInbox("admin@gmail.com");
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            //string userEmail = Session["AdminUserName"].ToString();
            var messageList = messageManager.GetListSendbox("admin@gmail.com");
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var readMessage = messageManager.GetById(id);
            //readMessage.MessageRead = true;
            messageManager.MessageUpdate(readMessage);
            var Values = messageManager.GetById(id);
            return View(Values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
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
                message.SenderMail = "admin@gmail.com";//message.sendermail
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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