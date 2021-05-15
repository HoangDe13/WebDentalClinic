using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class ListLichHenController : Controller
    {
        // GET: ListLichHen
        WebPhongKhamNhaKhoaEntities db = new WebPhongKhamNhaKhoaEntities();
        public ActionResult ListLichHen()
        {
            return View();
        }
      
    }
}