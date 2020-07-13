using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class ContentDAO
    {
        StoreDbContext db = null;
        public ContentDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Content entity)
        {
            try
            {
                var contents = db.Contents.Find(entity.ID);
                contents.Name = entity.Name;
                contents.Description = entity.Description;
                contents.Images = entity.Images;
                contents.Detail = entity.Detail;
                contents.ModifileBy = entity.ModifileBy;
                contents.ModifileDate = entity.ModifileDate;
                contents.Status = entity.Status;
                contents.MetaDescription = entity.MetaDescription;
                contents.ShowOnHome = entity.ShowOnHome;
                contents.MetaKeyWords = entity.MetaKeyWords;

                contents.Metatile = entity.Metatile;
                contents.CategoryID = entity.CategoryID;
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
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Content GetByID(long id )
        {

            return db.Contents.Find(id);
        }

        public IEnumerable<Content> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pagenum, pagesize);
        }
        public List<Content> ListAllNews()
        {
            return db.Contents.Where(x => x.Status == true).OrderByDescending(x=>x.CreatedDate).ToList();
        }
        public List<Content> ListNewsByCate(long idcateNews)
        {
            return db.Contents.Where(x => x.CategoryID == idcateNews).OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}