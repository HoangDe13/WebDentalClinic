using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class PhieuKhamController : Controller
    {
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        // GET: PhieuKham
        public ActionResult Index()
        {
            return View(database.PHIEUKHAMs.ToList()); ;
        }
        public ActionResult IndexBacSi()
        {
            return View(database.PHIEUKHAMs.ToList()); ;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PHIEUKHAM pk)
        {
            try
            {
                database.PHIEUKHAMs.Add(pk);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        [HttpPost]
        public ActionResult Details(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, PHIEUKHAM pk)
        {
            database.Entry(pk).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, PHIEUKHAM pk)
        {
            try
            {
                pk = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
                database.PHIEUKHAMs.Remove(pk);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }
        public ActionResult DeleteBacSi(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeleteBacSi(int id, PHIEUKHAM pk)
        {
            try
            {
                pk = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
                database.PHIEUKHAMs.Remove(pk);
                database.SaveChanges();
                return RedirectToAction("IndexBacSi");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }

        public PartialViewResult CategoryPartial()
        {
            return PartialView(database.PHIEUKHAMs.ToList());
        }
   
        public ActionResult SelectBenhNhan()
        {
            BENHNHAN ct = new BENHNHAN();
            ct.listBN = database.BENHNHANs.ToList<BENHNHAN>();
            return PartialView(ct);
        }
        public ActionResult SelectNhanVien()
        {
            NHANVIEN ct = new NHANVIEN();
            ct.listNV = database.NHANVIENs.ToList<NHANVIEN>();
            return PartialView(ct);
        }
    }
}