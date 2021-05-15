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


        public ActionResult ListLichhen()
        {
            return View(db.LICHHENs.ToList());
        }
        
        public ActionResult Edit(int id)
        {
            var lh = db.LICHHENs.Where(s => s.MaLichHen == id).FirstOrDefault();
            lh.TinhTrang = "DXN";
            db.Entry(lh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListLichHen", "ListLichHen");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var cate = db.LICHHENs.Where(s => s.MaLichHen == id).FirstOrDefault();
                db.LICHHENs.Remove(cate);
                db.SaveChanges();
                return RedirectToAction("ListLichHen", "ListLichHen");
            }
            catch
            {
                return Content("Error Delete");
            }
        }
        public ActionResult CreateLichHenYTA()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLichHenYTA(LICHHEN lh)
        {
            try
            {
                lh.MaLichHen = 0;
                String.Format("0:yyyy/mm/dd", lh.NgayHen);
                lh.TinhTrang = "CXN";
                db.LICHHENs.Add(lh);
                db.SaveChanges();
                return RedirectToAction("DatLichThanhCong", "LichHen");
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
        public ActionResult DatLichThanhCongYta()
        {
            return View();
        }

    }
}