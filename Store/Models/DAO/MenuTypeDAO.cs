using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class MenuTypeDAO
    {
        StoreDbContext db = null;
        public MenuTypeDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(MenuType entity)
        {
            db.MenuTypes.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(MenuType entity)
        {
            try
            {
                var mt = db.MenuTypes.Find(entity.ID);
                mt.Name = entity.Name;
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
                var menutype = db.MenuTypes.Find(id);
                db.MenuTypes.Remove(menutype);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;

            }
        }
        public List<MenuType> ListALL()
        {

            return db.MenuTypes.ToList();
        }

        public IEnumerable<MenuType> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<MenuType> model = db.MenuTypes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(pagenum, pagesize);
        }
        public MenuType GetID(long id)
        {
           return  db.MenuTypes.Find(id);
        }
    }
}