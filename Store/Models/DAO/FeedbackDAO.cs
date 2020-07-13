using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class FeedbackDAO
    {
        StoreDbContext db = null;
        public FeedbackDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(FeedBack entity)
        {
            db.FeedBacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public List<FeedBack> ListALL()
        {

            return db.FeedBacks.ToList();
        }
        public IEnumerable<FeedBack> ListAllPage( int pagenum, int pagesize)
        {
            IQueryable<FeedBack> model = db.FeedBacks;
           
            return model.OrderByDescending(x => x.ID).ToPagedList(pagenum, pagesize);
        }
    }
}