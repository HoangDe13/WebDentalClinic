using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;
using System.Security.Cryptography;
using System.Text;

namespace WebDentalClinic.Controllers
{
    public class HomeController : Controller
    {
        private DB_Entities_TAIKHOANBENHNHAN _dbTKBN = new DB_Entities_TAIKHOANBENHNHAN();
        private DB_Entities_BENHNHAN _dbBN = new DB_Entities_BENHNHAN();
        public ActionResult Index()
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
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(BENHNHAN _benhNhan, TAIKHOANBENHNHAN _taiKhoanBenhnhan)
        {
            if (ModelState.IsValid)
            {
                var check = _dbBN.benhNhan.FirstOrDefault(s => s.SoDienThoai == _benhNhan.SoDienThoai);
                var check2 = _dbTKBN.taiKhoanBenhNhan.FirstOrDefault(s => s.TenTaiKhoan == _taiKhoanBenhnhan.TenTaiKhoan);
                if (check == null && check2 == null)
                {
                    _taiKhoanBenhnhan.MatKhau = GetMD5(_taiKhoanBenhnhan.MatKhau);
                    _dbBN.Configuration.ValidateOnSaveEnabled = false;
                    _dbBN.benhNhan.Add(_benhNhan);
                    _dbBN.SaveChanges();
                    _dbTKBN.Configuration.ValidateOnSaveEnabled = false;
                    _dbTKBN.taiKhoanBenhNhan.Add(_taiKhoanBenhnhan);
                    _dbTKBN.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Tài khoản đã tồn tại";
                    return View();
                }
            }
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
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


    }
}