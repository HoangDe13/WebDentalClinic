using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class CreateProfileController : Controller
    {
        // GET: CreateProfile
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        public ActionResult Index()
        {
            return View(database.BENHNHANs.ToList());
        }
        public ActionResult Details(int id)
        {
            return View(database.BENHNHANs.Where(s => s.MaBenhNhan == id).FirstOrDefault());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult UpdateProfile()
        {
            BENHNHAN bn  = new BENHNHAN();
            return View(bn);
        }
        public ActionResult Edit(int id)
        {
            return View(database
                .BENHNHANs.Where(s => s.MaBenhNhan == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, BENHNHAN dv)
        {
            database.Entry(dv).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BENHNHAN Nv)
        {
            if (ModelState.IsValid)
            {
                var check = database.BENHNHANs.FirstOrDefault(s => s.SoDienThoai == Nv.SoDienThoai);
                if (check == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.BENHNHANs.Add(Nv);
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
    }
}