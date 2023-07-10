using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactValues = contactManager.GetListContact();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult MessageListMenu()
        {
            //string userEmail = (string)Session["AdminUserName"];
            ViewBag.iletisim = contactManager.GetListContact().Count();
            ViewBag.Giden = messageManager.GetListSendbox((string)Session["WriterMail"]).Count();
            ViewBag.Gelen = messageManager.GetListInbox((string)Session["WriterMail"]).Count();
            ViewBag.OkunmayanMesaj = messageManager.MessageNoRead((string)Session["WriterMail"]).Count();
            return PartialView();
        }
    }
}