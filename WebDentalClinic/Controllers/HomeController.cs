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
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(BENHNHAN _benhNhan)
        {
            var f_password = GetMD5(_benhNhan.MatKhau);
            var check = database.BENHNHANs.Where(s => s.SoDienThoai == _benhNhan.SoDienThoai && s.MatKhau.Equals(f_password)).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai info";
                return Content("Sai Thông Tin Đăng Nhập");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["SoDienThoai"] = _benhNhan.SoDienThoai;
                Session["MaBenhNhan"] = check.MaBenhNhan;
                Session["HoTen"] = check.HoTen;
                Session["BENHNHAN"] = check;
                return RedirectToAction("Account");
            }

        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(BENHNHAN _benhNhan)
        {
            if (ModelState.IsValid)
            {
                var check = database.BENHNHANs.FirstOrDefault(s => s.SoDienThoai == _benhNhan.SoDienThoai);
                if (check == null)
                {
                    _benhNhan.MatKhau = GetMD5(_benhNhan.MatKhau);
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.BENHNHANs.Add(_benhNhan);
                    database.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Số điện thoại đã tồn tại";
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
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



    }
}