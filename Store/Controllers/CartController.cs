
using Store.Commons;
using Store.Models;
using Store.Models.DAO;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(long producID, int quantity)
        {
            var product = new ProductDAO().ViewDetail(producID);
            var cart = Session[CartSession];

            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == producID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == producID)
                        {
                            item.Quantity += quantity;

                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }

            }
            else
            {
                //create new object cartitem
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                //
                Session[CartSession] = list;


            }
            return RedirectToAction("Index");
        }


        public JsonResult ClearallProduct()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult OrderItem()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult OrderItem(string name, string email, string address, string phone , string passemail)
        {
            var order = new Order();
            order.Name = name;
            order.Email = email;
            order.Address = address;
            order.Phone = phone;
            order.CreatedDate = DateTime.Now;
            order.PassEmail = passemail;
            try
            {

                var id = new OrderDAO().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDAO = new OrderDetailDAO();
                decimal total = 0 ;
                decimal totalDiscount = 0;
                foreach (var item in cart)
                {
                    var orderdetail = new OrderDetail();
                    orderdetail.ProductID = item.Product.ID;
                    orderdetail.Quantity = item.Quantity;
                    orderdetail.OrderID = id;
                    orderdetail.Pice = item.Product.Price;
                    orderdetail.PromotionPrice = item.Product.PromotionPrice;
                    detailDAO.Insert(orderdetail);
                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                    totalDiscount += (item.Product.PromotionPrice.GetValueOrDefault(0) * item.Quantity);
                }

                if (ModelState.IsValid)
                {
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/assests/client/template/neworder.html"));

                    content = content.Replace("{{Name}}", name);
                    content = content.Replace("{{Email}}", email);
                    content = content.Replace("{{Address}}", address);
                    content = content.Replace("{{Phone}}", phone);
                    content = content.Replace("{{Total}}", total.ToString("N0"));
                    content = content.Replace("{{TotalDiscount}}" , totalDiscount.ToString("N0"));
                    //var sender = ConfigurationManager.AppSettings[""].ToString();
                    var senderMail = new MailAddress(email, "New Order");
                    var receiverEmail = new MailAddress("tonglao686@gmail.com", "Receiver");

                    var pass = passemail;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderMail.Address, pass)


                    };
                    using (var message = new MailMessage(senderMail, receiverEmail) {
                        Subject = "Đơn Hàng Từ HaDoStore",
                        Body = content,
                        
                    }) 
                        {
                            smtp.Send(message);
                        }
                }

                //send mail----
                

                //var toEmail = new MailHelper().GetToEmail();
                //new MailHelper().SendMail(email, "Đơn hàng mới từ HaDoStore", content);
                //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ HaDoStore", content);

            }
            catch (Exception )
            {

                return Redirect("/loi-dat-hang");
            }

            return Redirect("/hoan-thanh");
}

public ActionResult Sucess()
{

    return View();
}

    }
}