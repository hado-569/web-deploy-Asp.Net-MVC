using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Admin/Contact
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var dao = new ContactDAO();
            var model = dao.ListAllPage( page, pagesize);
            
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {

            var contact = new ContactDAO().GetID(id) ;
            return View(contact);
        }
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDAO();

                bool result = dao.Update(contact);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "Contact");

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
            new ContactDAO().Delete(id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index", "User");
        }

    }
}