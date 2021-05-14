using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult CheckLich(LICHHEN lh)
        {
            
            return View(db.LICHHENs.ToList());

        }

        public ActionResult Delete(int id)
        {
            return View(db.LICHHENs.Where(s => s.MaLichHen == id).FirstOrDefault());

        }

        [HttpPost]
        public ActionResult Delete(int id, LICHHEN lh)
        {
            try
            {
                lh = db.LICHHENs.Where(s => s.MaLichHen == id).FirstOrDefault();
                db.LICHHENs.Remove(lh);
                db.SaveChanges();
                return RedirectToAction("CheckLich");
            }
            catch
            {
                return Content("Error Delete");
            }
        }
        public ActionResult Edit(int id)
        {
            return View(db.LICHHENs.Where(s => s.MaLichHen == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, LICHHEN cate)
        {
            cate.TinhTrang = "DXN";
            db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update_Check(LICHHEN lh)
        {
            //Check check = Session["Check"] as Check;
            //int id_lich = int.Parse(form["idLich"]);
            //string _check = (form["checkl"].ToString());
            //check.Update_lich(id_lich, _check);
            //return RedirectToAction("CheckLich", "LichHen");

            lh.TinhTrang = "DXN";
            db.Entry(lh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public Check GetCheck()
        //{
        //    Check check = Session["Check"] as Check;
        //    if(check==null || Session["Check"]==null)
        //    {
        //        check = new Check();
        //        Session["Check"] = check;
        //    }
        //    return check;
        //}
    }
}
