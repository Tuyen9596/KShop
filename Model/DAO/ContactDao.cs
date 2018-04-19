using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class ContactDao
    {
        private K_TShop db = null;

        public ContactDao()
        {
            db = new K_TShop();
        }
        public Contact Get()
        {
            return db.Contact.Single();
        }
    }
}
