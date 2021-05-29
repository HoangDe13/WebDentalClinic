﻿using System;
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
   /*     [HttpPost]
        public ActionResult MedicalExamination(int id, CHITIETPHIEUKHAM ctPK)
        {
            database.Entry(ctPK).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("MedicalExaminationList");
        }*/
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



    }
}