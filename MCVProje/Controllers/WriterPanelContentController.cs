using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {
            var contentValues = contentManager.GetListByWriter(3);
            return View(contentValues);
        }
    }
}