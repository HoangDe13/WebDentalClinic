using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;
using PagedList;
using PagedList.Mvc;

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
        
        public ActionResult Confirm(int id)
        {
            var lh = db.LICHHENs.Where(s => s.MaLichHen == id).FirstOrDefault();
           
            lh.TinhTrang = "DXN";
            db.Entry(lh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListLichHen", "ListLichHen");
        }
        public ActionResult Edit(int id)
        {
            var lichhen = db.LICHHENs.Where(s => s.MaLichHen == id).FirstOrDefault();
            return View(lichhen);
        }
        [HttpPost]
        public ActionResult Edit(LICHHEN lh)
        {
            try
            {
                db.Entry(lh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListLichHen", "ListLichHen");
            }
            catch
            {
                ModelState.AddModelError("NgayHen", "Vui Lòng Chọn Sau Ngày Hôm Nay ");
                return View(lh);
            }
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
                return RedirectToAction("DatLichThanhCong", "ListLichHen");
            }
            catch
            {
                ModelState.AddModelError("NgayHen", "Vui Lòng Chọn Sau Ngày Hôm Nay ");
                return View(lh);
            }

        }
        public ActionResult SelectBacSi()
        {
            NHANVIEN ct = new NHANVIEN();
            ct.listNV = db.NHANVIENs.Where(s=>s.MaChucVu==1).ToList<NHANVIEN>();
            return PartialView(ct);
        }
        public ActionResult DatLichThanhCong()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ListLichhen(string searchString)
        {
            var links = from l in db.LICHHENs // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {

                links = links.Where(s => s.NgayHen.ToString()==searchString); //lọc theo chuỗi tìm kiếm
            }
            return View(links);
        }

    }
}