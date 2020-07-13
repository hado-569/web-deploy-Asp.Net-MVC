using Store.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListALL();
            return PartialView(model);
        }
        public ActionResult ProductDetail(long productid)
        {
            var model = new ProductDAO().ViewDetail(productid);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(model.CategoryID.Value);
            ViewBag.RelatedProduct = new ProductDAO().ListRelatedProduct(productid,5);
            return View(model);
        }
        public ActionResult Category(long cateid)
        {
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(cateid);
            var model = new ProductDAO().ListProductByCategoryID(cateid);
            return View(model);
        }

        public ActionResult AllProduct()
        {
            var model = new ProductDAO().ListALL();
            ViewBag.ListnewProduct = new ProductDAO().ListNewProduct(1);
            return View(model);
        }

        public JsonResult ListName (string q)
        {
            var data = new ProductDAO().Listname(q);

            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);

            
        }

        public ActionResult Search(string keyword)
        {
            var model = new ProductDAO().Search(keyword);
            ViewBag.ListnewProduct = new ProductDAO().ListNewProduct(1);
            ViewBag.Search = new ProductDAO().Search(keyword);
            return View(model);
        }
    }
}