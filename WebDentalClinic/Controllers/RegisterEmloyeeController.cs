using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class RegisterEmloyeeController : Controller
    {
        // GET: RegisterEmloyee
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        public ActionResult Create()
        {
            NHANVIEN nv = new NHANVIEN();   
            return View();
        }
        public ActionResult Index()
        {
            return View(database.NHANVIENs.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NHANVIEN Nv)
        {
            if (ModelState.IsValid)
            {
                var check = database.NHANVIENs.FirstOrDefault(s => s.SoDienThoai == Nv.SoDienThoai);
                if (check == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.NHANVIENs.Add(Nv);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Số Điện Thoại Đã Tồn Tại";
                    return View();
                }


            }
            return View();


        }
        
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(NHANVIEN nv)
        {

            var check = database.NHANVIENs.Where(s => s.SoDienThoai == nv.SoDienThoai && s.MatKhau == nv.MatKhau).FirstOrDefault();
            if (check == null)
            { //add session

                ViewBag.error = "Login failed";
                return Content(" sai thông tin đăng nhập");
            }
            else
            {
                var ss = nv.MaChucVu.Equals(1);


                if (ss == true)

                {
                    return RedirectToAction("Index","RegisterEmloyee");
                }
                else if (ss ==false)
                {
                    return RedirectToAction("Index", "RegisterEmloyee");
                }
               return Content("Sai thông tin đăng nhập");
            }

         
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



    }
}