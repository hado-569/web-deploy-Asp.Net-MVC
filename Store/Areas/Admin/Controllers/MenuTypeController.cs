using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class MenuTypeController : BaseController
    {
        // GET: Admin/MenuType
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new MenuTypeDAO();
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
        public ActionResult Create(MenuType model)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuTypeDAO();
                var id = dao.Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "MenuType");
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
            var menutype = new MenuTypeDAO().GetID(id);
            return View(menutype);
        }
        [HttpPost]
        public ActionResult Edit(MenuType menutype)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuTypeDAO();
                bool result = dao.Update(menutype);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "MenuType");
                }
                else
                {
                    ModelState.AddModelError("","Xảy ra lỗi");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new MenuTypeDAO().Delete(id);
            SetAlert("Xoa Thanh Cong","success");
            return RedirectToAction("Index","MenuType");
        }

    }
}