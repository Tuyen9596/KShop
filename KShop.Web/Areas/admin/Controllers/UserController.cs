using Model.DAO;
using Model.EF;
using System.Web.Mvc;

namespace KShop.Web.Areas.admin.Controllers
{
    public class UserController : Controller
    {
        
        // GET: admin/User
        public ActionResult ListUser()
        {
            var dao = new UserDao();
            return View(dao.GetAll());
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var dao = new UserDao();
            if (ModelState.IsValid)
            {
                long id = dao.Insert(user);
                if (id > 0)
                {
                    ViewBag.message = "__                        Thêm Thành Công";
                    return View();
                   
                }
                else ViewBag.message = "__                        Thêm Lỗi";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Delete(int ID)
        {
            var dao = new UserDao();
            dao.Delete(ID);
            return RedirectToAction("ListUser");
        }
    }
}