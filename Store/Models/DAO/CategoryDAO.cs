using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class CategoryDAO
    {
        StoreDbContext db = null;
        public CategoryDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Category entity)
        {
            try
            {
                var cate = db.Categories.Find(entity.ID);
                cate.Name = entity.Name;
                cate.Metatitle = entity.Metatitle;
                cate.ParentID = entity.ParentID;
                cate.DisplayOrder = entity.DisplayOrder;
                cate.SEOtitle = entity.SEOtitle;
                cate.CreatedDate = entity.CreatedDate;
                cate.CreatedBy = entity.CreatedBy;
                cate.ModifileBy = entity.ModifileBy;
                cate.ModifileDate = DateTime.Now;
                cate.MetaDescription = entity.MetaDescription;
                cate.MetaKeyWords = entity.MetaKeyWords;
                cate.Status = entity.Status;
                cate.ShowOnHome = entity.ShowOnHome;
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
                var cate = db.Categories.Find(id);
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Category> ListALL()
        {

            return db.Categories.Where(x=>x.Status==true).ToList();
        }
        public IEnumerable<Category> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) );
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pagenum, pagesize);
        }
        public Category GetByID(long id)
        {
            return db.Categories.Find(id);
        }
       
    }
}