using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace KShop.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductCategoryDao dao = new ProductCategoryDao();
        public ActionResult Index()
        {
           
            return View();
        }
        [ChildActionOnly]
        public ActionResult _MenuPartial()
        {
            var lst = dao.GetAll();
            return PartialView(lst);
        }
    }
}