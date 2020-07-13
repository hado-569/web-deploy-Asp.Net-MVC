using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class ContentTagController : BaseController
    {
        // GET: Admin/ContentTag
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new ContentTagDAO();
            var model = dao.ListAllPage(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(ContentTag model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentTagDAO();
                var id = dao.Insert(model);
                if (id > 0)
                {

                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "ContentTag");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ! ");
                }
            }
           

            return View();

        }
    }
}