using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{
    public class DataSearchController : Controller
    {
        // GET: DataSearch
        public ActionResult Index(DateTime strat,DateTime end)
        {
            IEnumerable<HOADON> empTables = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("");

            return View();
        }
    }
}