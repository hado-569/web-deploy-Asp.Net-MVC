using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new ProductCategoryDAO();
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
        public ActionResult Create(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDAO();
                var id = dao.Insert(model);
                if (id > 0)
                {

                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");
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
            var proCate =new ProductCategoryDAO().ViewDetail(id);
            return View(proCate);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory proCate)
        { 
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDAO();

                bool result = dao.Update(proCate);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");

                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công ! ");
                }

            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(long id )
        {
             new ProductCategoryDAO().Delete(id);
            SetAlert("Xóa Thành Công ! ","success");
            return RedirectToAction("Index","ProductCategory");
        }
    }
}