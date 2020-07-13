using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class TagDAO
    {
        StoreDbContext db = null;
        public TagDAO()
        {
            db = new StoreDbContext();
        }

        public string Insert(Tag entity)
        {
            db.Tags.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public List<Tag> ListALL()
        {

            return db.Tags.ToList();
        }

        public IEnumerable<Tag> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<Tag> model = db.Tags;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(pagenum, pagesize);
        }
    }
}