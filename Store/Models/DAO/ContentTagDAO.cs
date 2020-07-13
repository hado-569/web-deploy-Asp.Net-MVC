using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class ContentTagDAO
    {
        StoreDbContext db = null;
        public ContentTagDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(ContentTag entity)
        {
            db.ContentTags.Add(entity);
            db.SaveChanges();
            return entity.ContentID;
        }


        public List<ContentTag> ListALL()
        {

            return db.ContentTags.ToList();
        }
        public IEnumerable<ContentTag> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<ContentTag> model = db.ContentTags;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TagID.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ContentID).ToPagedList(pagenum, pagesize);
        }

    }
}