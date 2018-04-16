using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using PagedList;

namespace KShop.Web.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: admin/Product
        ProductDao dao = new ProductDao();
        public ActionResult Index(string sTuKhoa, int? page)
        {
            int pagesize = 4;
            int pagenumber = page ?? 1;
            ViewBag.TuKhoa = sTuKhoa;

            return View(dao.GetAll().ToPagedList(pagenumber, pagesize)); ;
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
           
            var product = dao.GetSingleById(id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }
        public ActionResult Update(int id)
        {
            return View();
        }
        public ActionResult searchProductPartial(string sTuKhoa)
        {

            ViewBag.TuKhoa = sTuKhoa;
            //Tìm kiêm theo tên sp
            var dao = new ProductDao();
            var lst = dao.searchProduct(sTuKhoa);
            return PartialView(lst);
        }
        public ActionResult GetList()
        {
            return Json(
                dao.GetListName().Select(x=>x.Name).ToList(),
                JsonRequestBehavior.AllowGet
                );
        }

    }
}