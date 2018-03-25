using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDao
    {
        K_TShop db = null;
        public UserDao()
        {
            db = new K_TShop();
        }
        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User Get(string username,string password)
        {
            return db.User.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }
        public int Login(string username,string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == username );
            if (result==null) return 0;
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
    }
}
