using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class ContactDAO
    {

        StoreDbContext db = null;
        public ContactDAO()
        {
            db = new StoreDbContext();
        }

      
        public bool Update(Contact entity)
        {
            try
            {
                var contact = db.Contacts.Find(entity.ID);
                contact.Content = entity.Content;
                contact.Status = entity.Status;
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
                var contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }




            public List<Contact> ListALL()
        {

            return db.Contacts.ToList();
        }
        public IEnumerable<Contact> ListAllPage( int pagenum, int pagesize)
        {
            IQueryable<Contact> model = db.Contacts;
           
            return model.OrderByDescending(x => x.ID).ToPagedList(pagenum, pagesize);
        }
        public Contact GetID(long id)
        {
            return db.Contacts.Find(id);
        }
    }
}