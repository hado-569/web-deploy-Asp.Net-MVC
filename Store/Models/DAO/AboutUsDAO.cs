using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class AboutUsDAO
    {
        StoreDbContext db = null;
        public AboutUsDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(AboutU entity)
        {
            db.AboutUs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(AboutU entity)
        {
            try
            {
                var about = db.AboutUs.Find(entity.ID);
                about.Name = entity.Name;
                
                about.Description = entity.Description;
                about.Detail = entity.Detail;
                
                about.CreatedBy = entity.CreatedBy;
                
                about.ModifileBy = entity.ModifileBy;
                about.ModifileDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var about = db.AboutUs.Find(id);
                db.AboutUs.Remove(about);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }



        public List<AboutU> ListALL()
        {

            return db.AboutUs.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<AboutU> ListAllPage( int pagenum, int pagesize)
        {
            IQueryable<AboutU> model = db.AboutUs;
           
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pagenum, pagesize);
        }
        public AboutU GetAboutDescription()
        {
            return db.AboutUs.SingleOrDefault(x => x.Status == true);
        }
        public AboutU Getid(long id)
        {

            return db.AboutUs.Find(id);
        }
    }
}