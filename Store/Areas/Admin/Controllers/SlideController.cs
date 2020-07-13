using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index( int page = 1, int pagesize = 10)
        {
            var dao = new SlideDAO();
            var model = dao.ListAllPage( page, pagesize);
            
            return View(model);
        }
    [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
    [HttpPost]
    public ActionResult Create(Slide model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();
                var id = dao.Insert(model);
                if (id>0)
                {
                    SetAlert("Thêm mới thành công","success");
                    return RedirectToAction("Index","Slide");
                }else
                {
                    ModelState.AddModelError("","Xảy ra lỗi trong quá trình thêm mới ");
                }

            }
            return View();
        }
    [HttpGet]
    public ActionResult Edit(long id)
        {
            var slide = new SlideDAO().GetID(id);
            return View(slide);
        }

        [HttpPost]
        public ActionResult Edit(Slide slide) {

            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();
                


                bool result = dao.Update(slide);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "Slide");

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
            new SlideDAO().Delete(id);
            SetAlert("Xóa Thành Công ","success");

            return RedirectToAction("Index","Slide");
        }

    }
}