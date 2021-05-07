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
    }
}