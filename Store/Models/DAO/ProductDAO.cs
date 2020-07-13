using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class ProductDAO
    {
        StoreDbContext db = null;
        public ProductDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update (Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.Description = entity.Description;
                product.Images = entity.Images;
                product.MoreImg = entity.MoreImg;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.Metatile = entity.Metatile;
                product.Quanlity = entity.Quanlity;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.Code = entity.Code;
                product.Warranty = entity.Warranty;
                product.CreatedBy = entity.CreatedBy;
                product.CreatedDate = entity.CreatedDate;
                product.MetaDescription = entity.MetaDescription;
                product.MetaKeyWords = entity.MetaKeyWords;
                product.Status = entity.Status;
                product.ShowOnHome = entity.ShowOnHome;
                product.ModifileBy = entity.ModifileBy;
                product.ModifileDate = DateTime.Now;
                product.ViewCount = entity.ViewCount;
                product.IncludeVAT = entity.IncludeVAT;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }


        
        public List<Product> ListALL()
        {

            return db.Products.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Product> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pagenum, pagesize);
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x=>x.PromotionPrice<x.Price && x.PromotionPrice!= 0 ).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListRelatedProduct(long productID,int amount)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.ID != productID && x.CategoryID == product.CategoryID).OrderByDescending(x => x.CreatedDate).Take(amount).ToList();
        }
        public List<Product> ListProductByCategoryID(long categoryid)
        {
            return db.Products.Where(x => x.CategoryID==categoryid).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<string> Listname(string keyword) {

            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }


        public Product ViewDetail(long productID)
        {
            return db.Products.Find(productID);
        }
        public List<Product> Search(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).ToList();
        }

    }
}