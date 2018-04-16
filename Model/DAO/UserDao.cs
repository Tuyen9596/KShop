using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class UserDao
    {
        private K_TShop db = null;

        public UserDao()
        {
            db = new K_TShop();
        }

        public bool Insert(User entity)
        {
            try
            {
                db.User.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public User Get(string username, string password)
        {
            return db.User.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        public User Get(int id)
        {
            return db.User.SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<User> GetAll( )
        {
           return db.User.OrderBy(x=>x.UserName);
        }
        public IEnumerable<User> searchUser(string stringSearch)
        {
            if (stringSearch == null)
            {
                return db.User.ToList();
            }
            else return db.User.Where(x => x.Name.Contains(stringSearch)).OrderBy(x=>x.Name);
        }

        public int Login(string username, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == username);
            if (result == null) return 0;
            else
            {
                if (result.Status == false) return -1;
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else return -2;
                }
            }
        }

        public bool Delete(int id)
        {
            var entity = db.User.SingleOrDefault(x => x.ID == id);
            if (entity == null) return false;
            else
            {
                db.User.Remove(entity);
                db.SaveChangesAsync();
                return true;
            }
        }

        public bool Update(User user)
        {
            if (user != null)
            {
                var userRoot = db.User.SingleOrDefault(x => x.ID == user.ID);
                if (userRoot != null)
                {
                    userRoot.Password = user.Password==null?null:user.Password;
                    userRoot.Email = user.Email;
                    userRoot.Phone = user.Phone;
                    userRoot.Address = user.Address;
                    db.SaveChanges();
                }
                return true;
            }
            return false;
        }
        public bool ChangeStatus(long id)
        {
            var user = db.User.SingleOrDefault(x=>x.ID==id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
    }
}