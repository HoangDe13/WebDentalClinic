using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;
using System.Net.Http;

namespace WebDentalClinic.Controllers
{
    public class BaoCaoController : Controller
    {
        // GET: BaoCao
        WebPhongKhamNhaKhoaEntities db = new WebPhongKhamNhaKhoaEntities();
        public ActionResult BaoCaoDoanhThu()
        {
            var list = db.HOADONs.ToList();
            return View(list);
        }
       /* [HttpGet]
        public ActionResult BaoCaoDoanhThu(DateTime stat, DateTime end)
        {
            var links = db.HOADONs.ToList();
           
            if (!String.IsNullOrEmpty(stat.ToString())&& !String.IsNullOrEmpty(end.ToString())) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                 links = db.HOADONs.Where(s => s.NgayLap >= stat && s.NgayLap <= end).ToList();
            } //lọc theo chuỗi tìm kiếm
            return View(links);
        }*/
    }
}