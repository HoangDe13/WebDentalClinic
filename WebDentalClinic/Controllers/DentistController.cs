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


        public ActionResult EditPhieuKham(int id)
        {

            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        public ActionResult EditChiTiet(int id)
        {

            return View(database.CHITIETPHIEUKHAMs.Where(s => s.MaChiTietPhieuKham == id).FirstOrDefault());
        }
        public ActionResult AddChiTiet()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPhieuKham(int id, PHIEUKHAM pk)
        {
            var check = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
            if (check != null)
            {
                database.Configuration.ValidateOnSaveEnabled = true;
                check.TinhTrang = pk.TinhTrang;
                check.NgayTaiKham = pk.NgayTaiKham;
                database.SaveChanges();
                return RedirectToAction("MedicalExaminationList");
            }
            else
            {
                ViewBag.ErrorInfo = "Sai mã bệnh nhân";
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditChiTiet( CHITIETPHIEUKHAM ctPK)
        {
            database.Entry(ctPK).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("MedicalExaminationList");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddChiTiet(CHITIETPHIEUKHAM ctPK)
        {
            try
            {
                database.CHITIETPHIEUKHAMs.Add(ctPK);
                database.SaveChanges();
                return RedirectToAction("MedicalExaminationList");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult DeleteChiTiet(int id)
        {
            return View(database.CHITIETPHIEUKHAMs.Where(s => s.MaChiTietPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeleteChiTiet(int id, CHITIETPHIEUKHAM ctPK)
        {
            try
            {
                ctPK = database.CHITIETPHIEUKHAMs.Where(s => s.MaChiTietPhieuKham == id).FirstOrDefault();
                database.CHITIETPHIEUKHAMs.Remove(ctPK);
                database.SaveChanges();
                return RedirectToAction("MedicalExaminationList");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }
        public ActionResult MedicalExaminationListHistory(PHIEUKHAM pk)
        {
                                       
                return View(database.PHIEUKHAMs.Where(s => s.TinhTrang == "Đã khám").ToList());                          
        }

        public ActionResult MedicalExaminationList(PHIEUKHAM pk)
        {
            return View(database.PHIEUKHAMs.Where(s => s.TinhTrang == "Chưa khám").ToList());
        }
        public ActionResult MedicalExamination(int id)
        {
            return View(database.CHITIETPHIEUKHAMs.Where(s => s.MaPhieuKham == id).ToList()); ;
        }
        public ActionResult MedicalExaminationHistory(int id)
        {
            return View(database.CHITIETPHIEUKHAMs.Where(s => s.MaPhieuKham == id).ToList()); ;
        }

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

        public ActionResult TaoHoaDon(int id)
        {
            return View(database.HOADONs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }

        public ActionResult TinhTongTien()
        {
            var session = HttpContext.Session.GetEnumerator();
            return View();
        }

        //[HttpPost]
        //public ActionResult TinhTongTien(HoaDonViewModel hoaDonViewModel)
        //{


        //    return View();
        //}
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
        public ActionResult SelectDichVu(DICHVU pk)
        {

            pk.listDV = database.DICHVUs.ToList<DICHVU>();
            return PartialView(pk);
        }

        public ActionResult ChiTietHoaDon(int id)
        {
            return View(database.HOADONs.Where(s => s.MaHoaDon == id).FirstOrDefault());
        }

        [HttpGet]
        public ActionResult MedicalExaminationListHistory(string searchString)
        {

            var links = from l in database.PHIEUKHAMs // lấy toàn bộ liên kết
                        select l;
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.BENHNHAN.HoTen.ToString().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(links);
            /*ViewBag.MaPhieuKham = id;*/
          /*  return View(database.CHITIETPHIEUKHAMs.Where(s => s.MaPhieuKham == id).ToList()); ;*/
        }
        [HttpGet]
        public ActionResult HoaDon(string searchString)
        {
            var links = from l in database.HOADONs // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {

                links = links.Where(s => s.NgayLap.Value.ToString() == searchString); //lọc theo chuỗi tìm kiếm
            }
            return View(links);
        }
        //[HttpPost]
        //public ActionResult ChiTietHoaDon(HOADON hd)
        //{
        //    try
        //    {
        //        database.HOADONs.Add(hd);
        //        database.SaveChanges();
        //        return RedirectToAction("HoaDon");
        //    }
        //    catch
        //    {
        //        return Content("Error Create New");
        //    }
        //}


          
        

    }
}