using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KShop.Web
{
    public class UserLogon
    {
        public string userName { set; get; }
        public string passWord { set; get; }
        public bool remember { set; get; }
    }
}