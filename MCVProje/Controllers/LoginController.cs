﻿using BusinessLayer.Concrete;
using BusinessLayer.Hashing;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MCVProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var adminuserinfo = writerManager.GetByWriter(writer.WriterMail, writer.WriterPassword);
            if (adminuserinfo != null)
            {
                //adminuserinfo.WriterMail = Cryptology.Decryption(adminuserinfo.WriterMail);
                //adminuserinfo.WriterPassword = Cryptology.Decryption(adminuserinfo.WriterPassword);
                FormsAuthentication.SetAuthCookie(adminuserinfo.WriterMail, false);
                Session["AdminUserName"] = adminuserinfo.WriterPassword;
                //Session["AdminUserName"] = Cryptology.Decryption(adminuserinfo.AdminUserName);
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }

        }
    }
}