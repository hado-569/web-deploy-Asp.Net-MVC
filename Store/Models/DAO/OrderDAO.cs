using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class OrderDAO
    {
        StoreDbContext db = null;
        public OrderDAO()
        {
            db = new StoreDbContext();
        }
       public long  Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}