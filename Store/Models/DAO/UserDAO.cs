using PagedList;
using Store.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.DAO
{
    public class UserDAO
    {
        StoreDbContext db = null;
        public UserDAO()
        {
            db = new StoreDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.PassWord))
                {
                    user.PassWord = entity.PassWord;
                }
                user.Address = entity.Address;
                user.Phone = entity.Phone;
                user.Email = entity.Email;
                user.Status = entity.Status;
                user.ModifileBy = entity.ModifileBy;
                user.ModifileDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool  Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }


        public User ViewDetail(int id)
        {

            return db.Users.Find(id);
        }


        public IEnumerable<User> ListAllPage(string searchString ,int pagenum , int pagesize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x=> x.UserName.Contains(searchString)||x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pagenum,pagesize);
        }
        public User GetbyID(string username )
        {
            return db.Users.SingleOrDefault(x=> x.UserName == username );
        }

        public bool ChangeStatus (long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status ;
        }
        public int Login(string userName ,string passWord)
        {
            var result = db.Users.SingleOrDefault(x=>x.UserName == userName );
            if (result ==null )
            {
                return 0;
            }
            else
            {
                if (result.Status==false)
                {
                    return -1;
                }
                else
                {
                    if (result.PassWord==passWord)
                    {
                        return 1;
                    }
                    return -2;
                }
            }
        }
    }
}