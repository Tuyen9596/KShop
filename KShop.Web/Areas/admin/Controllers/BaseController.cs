using Model.EF;
using System.Web.Mvc;

namespace KShop.Web.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (User)Session["User_Login"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Index", Areas = "Areas" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}