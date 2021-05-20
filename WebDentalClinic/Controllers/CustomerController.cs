﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    
    public class CustomerController : Controller
    {
        WebPhongKhamNhaKhoaEntities db = new WebPhongKhamNhaKhoaEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IntroDental()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IntroInfrastructure()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IntroDoctor()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Service()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CreateLichHen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLichHen(LICHHEN lh)
        {
            try
            {
                lh.MaLichHen = 0;
                String.Format("0:yyyy/mm/dd", lh.NgayHen);
                lh.TinhTrang = "CXN";
                db.LICHHENs.Add(lh);
                db.SaveChanges();
                return RedirectToAction("DatLichThanhCong", "LichHen");
            }
            catch
            {
                return Content("Đăng kí lịch hẹn thất bại");
            }

        }
        public ActionResult SelectBacSi()
        {
            NHANVIEN ct = new NHANVIEN();
            ct.listNV = db.NHANVIENs.ToList<NHANVIEN>();
            return PartialView(ct);
        }
        public ActionResult DatLichThanhCongCus()
        {
            return View();
        }
        public ActionResult LichSuKham()

        {
            int maBN = (int)Session["MaBenhNhan"];
            var listPK = db.PHIEUKHAMs.OrderByDescending(x => x.MaBenhNhan).Where(x => x.MaBenhNhan == maBN);
            return View(listPK);
        }
        public ActionResult ChiTietphieukham(int id)
        {
            //int a = pk.MaPhieuKham;
            //return View(db.CHITIETPHIEUKHAMs.Where(s => s.MaChiTietPhieuKham == a).FirstOrDefault());

            var listPK = db.CHITIETPHIEUKHAMs.OrderByDescending(x => x.MaDichVu).Where(x => x.MaPhieuKham == id);
            return View(listPK);
        }
        public ActionResult EditProfile()
        {
            int maBN= (int)Session["MaBenhNhan"];
            var idBN = db.BENHNHANs.Where(s => s.MaBenhNhan == maBN).FirstOrDefault();
            return View(idBN);
        }
        [HttpPost]
        public ActionResult EditProfile(BENHNHAN std)
        {

            db.Entry(std).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}