using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new MenuDAO();
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
        public ActionResult Create(Menu model)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDAO();
                var id = dao.Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ! ");
                }
            }
           

            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menu = new MenuDAO().GetID(id);
            return View(menu);
        }
        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDAO();

                bool result = dao.Update(menu);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "Menu");

                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công ! ");
                }

            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new MenuDAO().Delete(id);
            SetAlert("Xóa thành công ","success");
            return RedirectToAction("Index","Menu"); 
        }

    }
}