using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class ServiceController : Controller
    {
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        // GET: Service
        public ActionResult Index()
        {
            return View(database.DICHVUs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DICHVU dv )
        {
            try
            {
                database.DICHVUs.Add(dv);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int id)
        {
            return View(database.DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database
                .DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, DICHVU dv)
        {
            database.Entry(dv).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, DICHVU dv)
        {
            try
            {
                dv = database.DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault();
                database.DICHVUs.Remove(dv);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }
    
        public PartialViewResult CategoryPartial()
        {
            return PartialView(database.DICHVUs.ToList());
        }
    }
}