using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class FeedBackController : BaseController
    {
        // GET: Admin/FeedBack
        public ActionResult Index( int page = 1, int pagesize = 10)
        {
            var dao = new FeedbackDAO();
            var model = dao.ListAllPage( page, pagesize);
           
            return View(model);
        }
       
    }
}