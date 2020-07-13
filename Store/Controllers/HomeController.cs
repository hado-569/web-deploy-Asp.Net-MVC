using Store.Models;
using Store.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDAO = new ProductDAO();
            ViewBag.Slides = new SlideDAO().ListALL();
            ViewBag.NewProduct = productDAO.ListNewProduct(3);
            ViewBag.FeatureProduct = productDAO.ListFeatureProduct(3);
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {

            var model = new MenuDAO().GetListByID(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {

            var model = new MenuDAO().GetListByID(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDAO().GetFooter();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderRight()
        {
            var cart = Session[Commons.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            
            return PartialView(list);
        }

    }
}