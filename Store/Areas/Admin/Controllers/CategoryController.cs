using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new CategoryDAO();
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
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                var id = dao.Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm mới danh mục thành công","success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ! ");
                }
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new CategoryDAO();
            var content = dao.GetByID(id);

          
            return View(content);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                bool result = dao.Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thành công ", "success");
                    return RedirectToAction("Index", "Category");

                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công ! ");
                }
            }
          
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new CategoryDAO().Delete(id);
            SetAlert("Xóa thành công ", "success");
            return RedirectToAction("Index", "Category");

        }
    }
}