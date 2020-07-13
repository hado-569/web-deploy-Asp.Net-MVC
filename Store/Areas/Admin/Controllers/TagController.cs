using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        // GET: Admin/Tag
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new TagDAO();
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
        public ActionResult Create(Tag model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TagDAO();
                var id = dao.Insert(model);
                if (id != null)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "Tag");
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