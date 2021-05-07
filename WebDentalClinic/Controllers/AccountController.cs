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
            TAIKHOANNHANVIEN tk = new TAIKHOANNHANVIEN();
            return View(tk);
        }
        public ActionResult Index()
        {
            return View(database.TAIKHOANBENHNHANs.ToList());
        }
    }
}