using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KShop.Web.Areas.admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập vào user name")]
        public string userName { set; get; }
        [Required(ErrorMessage = "Mời nhập vào Password")]
        public string passWord { set; get; }
        public bool remember  { set; get; }

    }
}