using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class AboutUsController : BaseController
    {
        // GET: Admin/AboutUs
        public ActionResult Index( int page = 1, int pagesize = 10)
        {
            var dao = new AboutUsDAO();
            var model = dao.ListAllPage( page, pagesize);
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new AboutUsDAO().Getid(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(AboutU about)
        {
            if (ModelState.IsValid)
            {

                var dao = new AboutUsDAO();

                bool result = dao.Update(about);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "AboutUs");

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
            new AboutUsDAO().Delete(id);
            SetAlert("Xoá Thành Công ","success");
            return RedirectToAction("Index","AboutUs");
        }
    }
}