using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingList = headingManager.GetListHeading();
            return View(headingList);
        }

        public PartialViewResult Index()
        {
            var contentList = contentManager.GetListContent();
            return PartialView(contentList);
        }
    }
}