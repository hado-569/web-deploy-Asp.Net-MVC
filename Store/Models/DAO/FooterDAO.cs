using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class FooterDAO
    {
        StoreDbContext db = null;
        public FooterDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(Footer entity)
        {
            db.Footers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Footer entity)
        {
            try
            {
                var footer = db.Footers.Find(entity.ID);
                footer.Content = entity.Content;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var footer = db.Footers.Find(id);
                db.Footers.Remove(footer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }








        public List<Footer> ListALL()
        {

            return db.Footers.ToList();
        }

        public IEnumerable<Footer> ListAllPage( int pagenum, int pagesize)
        {
            IQueryable<Footer> model = db.Footers;
            
            return model.OrderByDescending(x => x.ID).ToPagedList(pagenum, pagesize);
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x=>x.Status==true);
        }
        public Footer ViewDetail(int footerid)
        {
            return db.Footers.Find(footerid);
        }
    }
}