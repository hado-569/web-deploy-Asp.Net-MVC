using Store.Areas.Admin.Models;
using Store.Commons;
using Store.Models;
using Store.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptior.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetbyID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ViewBag.ErrorMessage = "tài khoản không tồn tại ! ";
                    //ModelState.AddModelError("", "tài khoản không tồn tại ! ");
                }
                else if (result == -1)
                {
                    ViewBag.ErrorMessage = "tài khoản bị khóa ! ";
                }
                else if (result == -2)
                {
                    ViewBag.ErrorMessage = "Sai mật khẩu ! ";
                }
                else
                {
                    ViewBag.ErrorMessage = "Sai mật khẩu ! ";
                }
            }
            return View("Index");

        }
    }
}