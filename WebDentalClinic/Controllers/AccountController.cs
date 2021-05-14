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
    public class AccountController : Controller
    {
        // GET: Account
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        public ActionResult Create()
        {
           
            return View();
        }
        public ActionResult Index()
        {
            return View();            
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NHANVIEN Nv)
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
        public ActionResult Login(string SDT, string password)
        {
            if (ModelState.IsValid)
            {

                var data = database.NHANVIENs.Where(s => s.SoDienThoai.Equals(SDT));/* && s.Password.Equals(password)).ToList()*/
                if (data.Count() > 0)
                {
                    //add session
               
                    var PQ1 = database.NHANVIENs.Where(s => s.CHUCVU.Equals(1));
                    var PQ2 = database.NHANVIENs.Where(s => s.CHUCVU.Equals(0));
                    if (PQ1.Count()>0)
                    {
                        return RedirectToAction("Index");
                    }   else if(PQ2.Count()>0)
                    {                       
                    return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.error = "Login failed";
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




    }
}