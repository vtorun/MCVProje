using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCVProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        LoginManager loginManager = new LoginManager(new EfWriterDal());
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            int id = 3;
            var contentValues = contentManager.GetListByWriter(id);
            return View(contentValues);
        }
        public ActionResult HeadingContentByWriter(int id)
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = loginManager.GetByWriter((string)Session["WriterMail"]).WriterId;
            content.ContentStatus = false;
            contentManager.ContentAdd(content);
            return View("MyContent");
        }
    }
}