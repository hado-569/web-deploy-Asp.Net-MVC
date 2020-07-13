using Store.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ContentNewsController : Controller
    {
        // GET: ContentNews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            var model = new ContentDAO().ListAllNews();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult CategoryofNews()
        {
            var model = new CategoryDAO().ListALL();
            return PartialView(model);
        }

        public ActionResult NewsByCategory(long id)
        {
            ViewBag.CategoryN = new CategoryDAO().GetByID(id);
            var model = new ContentDAO().ListNewsByCate(id);
            return View(model);
        }
        public ActionResult NewsDetail(long newsid)
        {
            var model = new ContentDAO().GetByID(newsid);
            ViewBag.CategoryN = new CategoryDAO().GetByID(model.CategoryID.Value);
            return View(model);
        }
    }
}