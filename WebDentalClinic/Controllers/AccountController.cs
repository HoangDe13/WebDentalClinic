using System;
using System.Collections.Generic;
using System.Linq;
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
            NHANVIEN tk = new NHANVIEN();
            return View(tk);
        }
        public ActionResult Index()
        {
            return View(database.BENHNHANs.ToList());
        }
    }
}