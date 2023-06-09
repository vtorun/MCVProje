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
            var contactValues = contactManager.GetListContact().Count();
            ViewBag.iletisim = contactValues;
            ViewBag.Giden = messageManager.GetListSendbox("admin@gmail.com").Count();
            ViewBag.Gelen = messageManager.GetListInbox("admin@gmail.com").Count();
            ViewBag.OkunmayanMesaj = messageManager.MessageNoRead("admin@gmail.com").Count();
            return PartialView();
        }
    }
}