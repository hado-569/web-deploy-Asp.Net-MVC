using Store.Commons;
using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString ,int page =1 ,int pagesize =10 )
        {
            var dao = new UserDAO();
            var model = dao.ListAllPage(searchString ,page,pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                var encryptedMD5Pass = Encryptior.MD5Hash(user.PassWord);
                user.PassWord = encryptedMD5Pass;

                long id = dao.Insert(user);
                if (id>0)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index","User");

                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ! ");
                }
           
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.PassWord))
                {
                    var encryptedMD5Pass = Encryptior.MD5Hash(user.PassWord);
                    user.PassWord = encryptedMD5Pass;
                }


                bool result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật mới thành công", "success");
                    return RedirectToAction("Index", "User");

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
            new UserDAO().Delete(id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index","User");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);

            return Json(new {
                status = result

            });

        }

    }
}