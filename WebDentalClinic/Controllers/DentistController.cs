using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class DentistController : Controller
    {
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();

        // GET: Dentist
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult MedicalExamination(int id)
        {

            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult MedicalExamination(int id, PHIEUKHAM pk, CHITIETPHIEUKHAM ctPK)
        {
            database.Entry(pk).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("MedicalExaminationList");
        }
        public ActionResult MedicalExaminationHistory()
        {

            return View(database.PHIEUKHAMs.ToList());

        }

        public ActionResult MedicalExaminationList()
        {
           /* var DatetimeList = from a in database.PHIEUKHAMs where a.NgayKham == DateTime.Now select a;
            id.MaPhieuKham = 1;
            ViewBag.Message = "Your  page.";*/

            return View(database.PHIEUKHAMs.ToList()); ;
        }
/*        [HttpGet]
        public ActionResult MedicalExaminationList(string searchString, PHIEUKHAM pk, int id)
        {
           
            var links = from l in database.BENHNHANs // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.HoTen.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(links);
        }*/

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }



        public ActionResult HoaDon()
        {
            return View(database.HOADONs.ToList());
        }

        public ActionResult TaoHoaDon()
        {
            return View();
        }

        public ActionResult TinhTongTien(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult TinhTongTien(int id, PHIEUKHAM pk, PHIEUKHAM maPK)
        {
            //maPK = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
            int tongTien = 0;
            pk = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();

            return View(tongTien);
        }
        public ActionResult XemDichVu(int id, PHIEUKHAM pk)
        {

            return View(database.PHIEUKHAMs.ToList());
        }

        [HttpPost]
        public ActionResult TaoHoaDon(HOADON hd)
        {
            try
            {
                database.HOADONs.Add(hd);
                database.SaveChanges();
                return RedirectToAction("HoaDon");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        [HttpPost]

        public ActionResult XoaHoaDon(int id)
        {
            return View(database.HOADONs.Where(s => s.MaHoaDon == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaHoaDon(int id, HOADON hd)
        {
            try
            {
                hd = database.HOADONs.Where(s => s.MaHoaDon == id).FirstOrDefault();
                database.HOADONs.Remove(hd);
                database.SaveChanges();
                return RedirectToAction("HoaDon");
            }
            catch
            {
                return Content(" This data is using in other table , error Delete");
            }
        }
        public ActionResult SelectDichVu(PHIEUKHAM pk)
        {

           pk.listDV = database.PHIEUKHAMs.ToList<PHIEUKHAM>();
            return PartialView(pk);
        }

        public ActionResult ChiTietHoaDon()
        {
            return View();
        }



    }
}