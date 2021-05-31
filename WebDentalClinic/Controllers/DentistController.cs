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
        public ActionResult AddChiTiet(/*int id*/)
        {

            /*  return View(database.CHITIETPHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());*/
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPhieuKham(int id, PHIEUKHAM pk)
        {
            /* database.Entry(pk).State = System.Data.Entity.EntityState.Modified;
             database.Configuration.ValidateOnSaveEnabled = false;

             database.SaveChanges();
             return RedirectToAction("MedicalExaminationList");*/

            var check = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
            if (check != null)
            {
                /*database.Entry(pk).State = System.Data.Entity.EntityState.Modified;*/
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
        public ActionResult EditChiTiet(CHITIETPHIEUKHAM ctPK)
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
        public ActionResult MedicalExaminationHistory()
        {

            return View(database.PHIEUKHAMs.ToList());

        }

        public ActionResult MedicalExaminationList()
        {
            return View(database.PHIEUKHAMs.ToList()); ;
        }
        public ActionResult MedicalExamination(int id)
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

        //public ActionResult TinhTongTien(int id)
        //{
        //    return View(database.HOADONs.Where(s=>s.MaPhieuKham==id).FirstOrDefault());
        //}



        [HttpPost]
        //public ActionResult TinhTongTien(FormCollection collect)
        //{

        //    int tongTien = int.Parse(collect["@Model.Sum(x => x.CHITIETPHIEUKHAM.SoLuong * x.CHITIETPHIEUKHAM.DICHVU.DonGia)"]);

        //    ViewBag.Sum = tongTien.ToString();

        //    return View(tongTien);
        //}

        public ActionResult TinhTongTien(int soLuong, int donGia)
        {

            int tongTien = soLuong * donGia;

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
                // chưa lấy được giá trị đơn giá, số lượng
                int donGia = hd.PHIEUKHAM.CHITIETPHIEUKHAM.DICHVU.DonGia.Value;
                int soLuong = hd.PHIEUKHAM.CHITIETPHIEUKHAM.SoLuong.Value;

                TinhTongTien(donGia,soLuong);
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
            return View(database.HOADONs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult ChiTietHoaDon(HOADON hd)
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

        //public ActionResult LuuTrangThai(HOADON ctPK)
        //{
        //    try
        //    {
        //        database.HOADONs.Add(ctPK);
        //        database.SaveChanges();
        //        return RedirectToAction("HoaDon");
        //    }
        //    catch
        //    {
        //        return Content("Lưu không thành công!!!");
        //    }
        //}

    }
}