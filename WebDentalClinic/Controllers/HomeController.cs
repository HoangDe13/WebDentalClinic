using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

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
        public ActionResult Register()
        {
            return View();
        }
        
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(BENHNHAN bn)
        {
            
                var check = database.BENHNHANs.FirstOrDefault(s => s.SoDienThoai == bn.SoDienThoai);

                if (check == null)
                {
                   
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.BENHNHANs.Add(bn);
                    database.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    
                    return Content("Đăng Kí Thất Bại");
                }


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
       
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(BENHNHAN BN)
        {
            
            var check = database.BENHNHANs.Where(s => s.SoDienThoai == BN.SoDienThoai && s.MatKhau == BN.MatKhau).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai info";
                return Content("Sai Thông Tin Đăng Nhập");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["SoDienThoai"] = BN.SoDienThoai;
                Session["MaBenhNhan"] = check.MaBenhNhan;
                Session["HoTen"] = check.HoTen;
                Session["BENHNHAN"] = check;
                return RedirectToAction("Profile", "Customer");
            }

        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        //public static string GetMD5(string str)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = Encoding.UTF8.GetBytes(str);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;

        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x2");

        //    }
        //    return byte2String;
        //}

    }
}