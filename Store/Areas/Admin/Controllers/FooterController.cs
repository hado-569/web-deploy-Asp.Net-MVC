using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        // GET: Admin/Footer
        public ActionResult Index( int page = 1, int pagesize = 10)
        {
            var dao = new FooterDAO();
            var model = dao.ListAllPage( page, pagesize);
            
            return View(model);
        }
        

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var footer = new FooterDAO().ViewDetail(id);
            return View(footer);
        }
        [HttpPost]
        public ActionResult Edit(Footer footer)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDAO();

                bool result = dao.Update(footer);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "Footer");

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
            new FooterDAO().Delete(id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index", "User");
        }
    }
}