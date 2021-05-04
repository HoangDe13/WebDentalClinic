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
        WebPhongKhamNhaKhoaEntities data = new WebPhongKhamNhaKhoaEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdateProfile()
        {
            BENHNHAN bn  = new BENHNHAN();
            return View(bn);
        }
    }
}