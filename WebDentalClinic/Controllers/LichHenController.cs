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
        public ActionResult CreateLichHen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLichHen(LICHHEN lh)
        {
            try
            {
                lh.MaLichHen = 0;
                String.Format("0:yyyy/mm/dd", lh.NgayHen);
                lh.TinhTrang = "CXN";
                db.LICHHENs.Add(lh);
                db.SaveChanges();
                return RedirectToAction("DatLichThanhCong","LichHen");
            }
            catch
            {
                return Content("Đăng kí lịch hẹn thất bại");
            }

        }
        public ActionResult SelectBacSi()
        {
            NHANVIEN ct = new NHANVIEN();
            ct.listNV = db.NHANVIENs.ToList<NHANVIEN>();
            return PartialView(ct);
        }
        public ActionResult DatLichThanhCong()
        {
            return View();
        }
    }
}
