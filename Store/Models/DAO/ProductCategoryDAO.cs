using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class ProductCategoryDAO
    {
        StoreDbContext db = null;
        public ProductCategoryDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(ProductCategory entity)
        {
            try
            {
                var prodCate = db.ProductCategories.Find(entity.ID);
                prodCate.Name = entity.Name;
                prodCate.Metatitle = entity.Metatitle;
                prodCate.ParentID = entity.ParentID;
                prodCate.DisplayOrder = entity.DisplayOrder;
                prodCate.SEOtitle = entity.SEOtitle;
                prodCate.CreatedBy = entity.CreatedBy;
                prodCate.CreatedDate = entity.CreatedDate;
                prodCate.ModifileBy = entity.ModifileBy;
                prodCate.ModifileDate = DateTime.Now;
                prodCate.MetaDescription = entity.MetaDescription;
                prodCate.MetaKeyWords = entity.MetaKeyWords;
                prodCate.Status = entity.Status;
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
                var prodCate = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(prodCate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public List<ProductCategory> ListALL()
        {

            return db.ProductCategories.Where(x=>x.Status==true).OrderBy(x=> x.DisplayOrder).ToList();
        }

        public IEnumerable<ProductCategory> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pagenum, pagesize);
        }

        public ProductCategory ViewDetail(long cateID)
        {
            return db.ProductCategories.Find(cateID);
        }

    }
}