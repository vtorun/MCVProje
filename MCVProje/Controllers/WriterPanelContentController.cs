using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        HeadingManager contentManager = new HeadingManager(new EfHeadingDal());
        Context context = new Context();
        public ActionResult MyContent(string mail)
        {
            mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            var contentValues = contentManager.GetListHeadingByWriter();
            return View(contentValues);
        }
    }
}