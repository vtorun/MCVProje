﻿using BusinessLayer.Concrete;
using BusinessLayer.Hashing;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MCVProje.Controllers
{
    public class AdminLoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //Context context = new Context();
            // var adminuserinfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            var adminuserinfo = adminManager.GetByAdmin(admin.AdminUserName, admin.AdminPassword);
            if (adminuserinfo != null)
            {
                adminuserinfo.AdminUserName = Cryptology.Decryption(adminuserinfo.AdminUserName);
                adminuserinfo.AdminPassword = Cryptology.Decryption(adminuserinfo.AdminPassword);
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["WriterMail"] = "admin@gmail.com";
                //Session["AdminUserName"] = Cryptology.Decryption(adminuserinfo.AdminUserName);
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

