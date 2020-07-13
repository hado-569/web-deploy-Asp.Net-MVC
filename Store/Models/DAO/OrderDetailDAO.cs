using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class OrderDetailDAO
    {
        StoreDbContext db = null;
        public OrderDetailDAO()
        {
            db = new StoreDbContext();
        }
        public bool Insert(OrderDetail entity)
        {
            try
            {
                db.OrderDetails.Add(entity);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

    }
}