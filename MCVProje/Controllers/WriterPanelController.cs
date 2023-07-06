using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        LoginManager loginManager = new LoginManager(new EfWriterDal());
        Context context = new Context();
        Writer writerIdInfo;
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string email)
        {
            email = (string)Session["WriterMail"];
            //writerIdInfo = context.Writers.Where(x => x.WriterMail == email).Select(y => y.WriterId).FirstOrDefault();
            writerIdInfo = loginManager.GetByWriter(email);
            var values = headingManager.GetListHeadingByWriter(writerIdInfo.WriterId);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetListCategory()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryValue = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            heading.WriterId = loginManager.GetByWriter((string)Session["WriterMail"]).WriterId;
            heading.HeadingStatus = false;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetListCategory()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryValue = valueCategory;
            var headingValues = headingManager.GetById(id);
            return View(headingValues);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingManager.HeadingRemove(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}