using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Store.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new ContentDAO();
            var model = dao.ListAllPage(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create ()
        {

            Setviewbag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDAO();
                long id = dao.Insert(model);

                if (id > 0)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "Content");

                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ! ");
                }


            }
            Setviewbag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDAO();
            var content = dao.GetByID(id);

            Setviewbag(content.CategoryID);
            return View(content);
        }
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDAO();
                bool result = dao.Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thành công ","success");
                    return RedirectToAction("Index", "Content");

                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công ! ");
                }
            }
            Setviewbag(model.ID);
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ContentDAO().Delete(id) ;
            SetAlert("Xóa thành công ","success");
            return RedirectToAction("Index","Content");

        }
        public void Setviewbag(long? seclectID=null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListALL(),"ID","Name", seclectID);
        }


    }
}