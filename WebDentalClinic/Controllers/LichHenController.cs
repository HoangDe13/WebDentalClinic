using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class LichHenController : Controller
    {
       
        // GET: LichHen
        WebPhongKhamNhaKhoaEntities db = new WebPhongKhamNhaKhoaEntities();
        public ActionResult Index()
        {
            return View();
        }
     
        }
    }
