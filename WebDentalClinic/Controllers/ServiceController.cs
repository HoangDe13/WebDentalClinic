using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class ServiceController : Controller
    {
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        // GET: Service
        public ActionResult Index()
        {
            return View(database.DICHVUs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DICHVU dv )
        {
            try
            {
                database.DICHVUs.Add(dv);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int id)
        {
            return View(database.DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database
                .DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, DICHVU dv)
        {
            database.Entry(dv).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                DICHVU dv = database.DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault();
                database.DICHVUs.Remove(dv);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" Dịch Vụ Đang Được Sử Dụng, Không thể xóa !!!");
            }
            }
       /* [HttpPost]
        public ActionResult Delete( DICHVU dv)
        {
            try
            {
               
                database.DICHVUs.Remove(dv);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }
    */
        public PartialViewResult CategoryPartial()
        {
            return PartialView(database.DICHVUs.ToList());
        }
        [HttpGet]
        public ActionResult Index(string searchString)
        {
            var links = from l in database.DICHVUs // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.TenDichVu.ToString().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(links);
        }
    }
}