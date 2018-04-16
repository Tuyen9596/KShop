using KShop.Web.Common;
using Model.DAO;
using Model.EF;
using PagedList;
using System.Web.Mvc;

namespace KShop.Web.Areas.admin.Controllers
{
    public class UserController :Controller
    {
        // GET: admin/User
        public ActionResult ListUser(string sTuKhoa, int? page)
        {
            var dao = new UserDao();
            int pagesize = 4;
            int pagenumber = page ?? 1;
            ViewBag.TuKhoa = sTuKhoa;

            return View(dao.GetAll().ToPagedList(pagenumber, pagesize)); ;
        }
        public ActionResult searchUserPartial(string sTuKhoa)
        {

            ViewBag.TuKhoa = sTuKhoa;
            //Tìm kiêm theo tên sp
            var dao = new UserDao();
            var lst = dao.searchUser(sTuKhoa);
            return PartialView(lst);
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            
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
        [HttpGet]
        public ActionResult Update(int ID)
        {
            var dao = new UserDao();
            var user = dao.Get(ID);
            if(user==null)
            {
                return HttpNotFound();
            }else
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(User model)
        {
            model.Password = Encryptor.MD5Hash(model.Password);
                
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.Update(model))
                 return View(model);
            }
            return View();        
        }
       // [OverrideAuthentication]
        //public ActionResult ChangeStatus(long id)
        //{
        //    var result = new UserDao().ChangeStatus(id);
        //    return RedirectToAction("ListUser");
        //}
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new {
                status=result
            });
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (user != null)
            {
                var dao = new UserDao();
                user.Password = Encryptor.MD5Hash(user.Password);
                if (dao.Insert(user))
                {
                    SetAlert("Insert Success", "success");
                    return RedirectToAction("ListUser");
                }
                else
                {
                    SetAlert("Insert Error!! Check Again Infomation", "error");
                    return View();
                }
           
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

    }
}