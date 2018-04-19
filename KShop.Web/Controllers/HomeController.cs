using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Facebook;
using System.Configuration;

namespace KShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        // GET: Home
        ProductCategoryDao daoProductCategory = new ProductCategoryDao();
        ProductDao daoProduct = new ProductDao();
        [HttpGet]
        public ActionResult Index()
        {
                       return View(daoProduct.GetAll());
        }
        [ChildActionOnly]
        public ActionResult _MenuPartial()
        {
            var lst = daoProductCategory.GetAll();
            return PartialView(lst);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri =RedirectUri.AbsoluteUri,
                response_type="code",
                scope="email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
    }
}