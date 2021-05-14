using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class DentistController : Controller
    {
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();

        // GET: Dentist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult MedicalExamination(int id)
        {
            
            ViewBag.Message = "Your  page.";

            return View(database.PHIEUKHAMs.ToList());
        }

        public ActionResult MedicalExaminationList()
        {
            var DatetimeList = from a in database.LICHHENs where a.NgayHen == DateTime.Now select a;
            
            ViewBag.Message = "Your  page.";

            return View(database.LICHHENs.ToList());
        }

        public ActionResult Logout()
        {
            ViewBag.Message = "Your logout page.";

            return RedirectToAction("Index", "Home");
        }

        public ActionResult InvoiceHistory()
        {
            ViewBag.Message = "Your Invoice History Page.";
            return View();
        }


        public ActionResult Invoice()
        {
            ViewBag.Message = "Your Invoice History Page.";
            return View();
        }





    }
}