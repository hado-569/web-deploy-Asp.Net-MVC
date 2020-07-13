using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class SlideDAO
    {
        StoreDbContext db = null;
        public SlideDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
      
        public bool Update (Slide entity)
        {
            try
            {
                var slide = db.Slides.Find(entity.ID);
                slide.Image = entity.Image;
                slide.DisplayOrder = entity.DisplayOrder;
                slide.Link = entity.Link;
                slide.Description = entity.Description;
                slide.CreatedBy = entity.CreatedBy;
                slide.CreatedDate = DateTime.Now;
                slide.ModifileBy = entity.ModifileBy;
                slide.ModifileDate = DateTime.Now;
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
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }




        public List<Slide> ListALL()
        {

            return db.Slides.Where(x => x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public IEnumerable<Slide> ListAllPage(int pagenum, int pagesize)
        {
            IQueryable<Slide> model = db.Slides;
            
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pagenum, pagesize);
        }
        public Slide GetID(long id)
        {
            return db.Slides.Find(id);
        }
    }
}