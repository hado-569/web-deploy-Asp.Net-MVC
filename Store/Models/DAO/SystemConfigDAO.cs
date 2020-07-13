using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class SystemConfigDAO
    {
        StoreDbContext db = null;
        public SystemConfigDAO()
        {
            db = new StoreDbContext();
        }

        public string Insert(SystemConfig entity)
        {
            db.SystemConfigs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public List<SystemConfig> ListALL()
        {

            return db.SystemConfigs.Where(x => x.Status == true).ToList();
        }
    }
}