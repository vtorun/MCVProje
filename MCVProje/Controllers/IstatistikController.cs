using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
            WriterManager writerManager = new WriterManager(new EfWriterDal());
            ViewBag.CategoryCount = categoryManager.GetListCategory().Count();
            ViewBag.YazilimCount = headingManager.GetListHeading().Where(x => x.CategoryId == 10).Count();
            ViewBag.AInWriter = writerManager.GetListWriter().Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();
            ViewBag.Sorgu1 = categoryManager.GetListCategory().Where(x => x.CategoryId == (headingManager.GetListHeading().GroupBy(h => h.CategoryId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            ViewBag.Sorgu2 = categoryManager.GetListCategory().Where(x => x.CategoryStatus == true).Count() - categoryManager.GetListCategory().Where(x => x.CategoryStatus == false).Count();
            return View();

        }
    }
}