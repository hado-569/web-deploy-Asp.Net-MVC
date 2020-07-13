using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class MenuDAO
    {
        StoreDbContext db = null;
        public MenuDAO()
        {
            db = new StoreDbContext();
        }

        public long Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Menu entity)
        {
            try
            {
                var menu = db.Menus.Find(entity.ID);
                menu.Text = entity.Text;
                menu.Link = entity.Link;
                menu.DisplayOrder = entity.DisplayOrder;
                menu.Target = entity.Target;
                menu.Status = entity.Status;
                menu.TypeID = entity.TypeID;

               
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
                var menu = db.Menus.Find(id);
                db.Menus.Remove(menu);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Menu> ListALL()
        {

            return db.Menus.ToList();
        }
        public IEnumerable<Menu> ListAllPage(string searchString, int pagenum, int pagesize)
        {
            IQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString));
            }
            return model.OrderByDescending(x => x.DisplayOrder).ToPagedList(pagenum, pagesize);
        }
        public List<Menu> GetListByID(int groupid)
        {
            return db.Menus.Where(x => x.TypeID == groupid && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
        public Menu GetID(int id)
        {
            return db.Menus.Find(id);
        }
    }
}