using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace MCVProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        public ActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult MyHeading()
        {
            var values = headingManager.GetListHeadingByWriter();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHeading()
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
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            heading.WriterId = 2;
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