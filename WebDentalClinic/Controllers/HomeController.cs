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
        private DB_Entities_TAIKHOANBENHNHAN _db = new DB_Entities_TAIKHOANBENHNHAN();
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
        public ActionResult Account()
        {

            if (Session["MaBenhNhan"] != null)
            {

                return View();
            }
            else
            {
                TempData["testmsg"] = "<script>alert('Vui lòng đăng nhập');</script>";
                return RedirectToAction("Index");

            }
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your register page.";

            return View();
        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TAIKHOANBENHNHAN _benhNhan)
        {
            if (ModelState.IsValid)
            {
                var check = _db.taiKhoanBenhNhan.FirstOrDefault(s => s.TenTaiKhoan == _benhNhan.TenTaiKhoan);
                if (check == null)
                {
                    _benhNhan.MatKhau = GetMD5(_benhNhan.MatKhau);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.taiKhoanBenhNhan.Add(_benhNhan);
                    _db.SaveChanges();
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
        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string tenTaiKhoan, string matKhau)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(matKhau);
                var data = _db.taiKhoanBenhNhan.Where(s => s.TenTaiKhoan.Equals(tenTaiKhoan) && s.MatKhau.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["TenTaiKhoan"] = data.FirstOrDefault().TenTaiKhoan;
                    Session["MaBenhNhan"] = data.FirstOrDefault().MaBenhNhan;
                    return RedirectToAction("Account");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
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
