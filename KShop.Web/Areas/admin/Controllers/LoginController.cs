using KShop.Web.Areas.admin.Models;
using KShop.Web.Common;
using Model.DAO;
using System.Web.Mvc;

namespace KShop.Web.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(loginModel.userName, Encryptor.MD5Hash(loginModel.passWord));

                if (result == 1)
                {
                    ViewBag.mesage = "";
                    Session.Add("User_Login", dao.Get(loginModel.userName, Encryptor.MD5Hash(loginModel.passWord)));
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ViewBag.mesage="Tài Khoản Không Tồn Tại !!";
                }
                else if (result == -1)
                {
                    ViewBag.mesage = "Tài Khoản Đang Bị Khóa !!";
                }
                else if (result == -2)
                {
                    ViewBag.mesage = "Mật Khẩu Sai !!";
                }
            }
            return View("Index");
        }
    }
}