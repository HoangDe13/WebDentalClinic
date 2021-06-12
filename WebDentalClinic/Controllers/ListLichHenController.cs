using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDentalClinic.Models;
using PagedList;


namespace WebDentalClinic.Controllers
{
    public class ListLichHenController : Controller
    {
        // GET: ListLichHen
        WebPhongKhamNhaKhoaEntities db = new WebPhongKhamNhaKhoaEntities();

        
        public ActionResult ListLichhen(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in db.LICHHENs
                         select l).OrderBy(x => x.MaLichHen).ToList();

            //Lay het trong lich hen trong DB
            List<LICHHEN> listLichHen = new List<LICHHEN>();
            foreach(var x in db.LICHHENs)
            {
                listLichHen.Add(x);
            }

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 10;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(listLichHen.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ListLichhen(string searchString, int? page)
        {

            var links = from l in db.LICHHENs // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {

                links = links.Where(s => s.NgayHen.ToString() == searchString); //lọc theo chuỗi tìm kiếm
            }
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.

            //Lay het trong lich hen trong DB
            List<LICHHEN> listPK = new List<LICHHEN>();
            foreach (var x in links)
            {
                listPK.Add(x);
            }
            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 10;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            // 5. Trả về các Link được phân trang theo kích thước và số trang.

            return View(listPK.ToPagedList(pageNumber, pageSize));
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
        //[HttpGet]
        //public ActionResult ListLichhen(string searchString)
        //{
        //    var links = from l in db.LICHHENs // lấy toàn bộ liên kết
        //                select l;

        //    if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
        //    {

        //        links = links.Where(s => s.NgayHen.ToString() == searchString); //lọc theo chuỗi tìm kiếm
        //    }
        //    return View(links);
        //}

    }
}