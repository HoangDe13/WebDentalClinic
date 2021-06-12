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
    public class PhieuKhamController : Controller
    {
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        // GET: PhieuKham
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in database.PHIEUKHAMs
                         select l).OrderBy(x => x.MaPhieuKham).ToList();

            //Lay het trong lich hen trong DB
            List<PHIEUKHAM> listPK = new List<PHIEUKHAM>();
            foreach (var x in database.PHIEUKHAMs)
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
        [HttpGet]
        public ActionResult Index(string searchString, string searchDate, int? page)
        {

            var links = from l in database.PHIEUKHAMs // lấy toàn bộ liên kết
                        select l;
            if (!String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(searchDate)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.BENHNHAN.HoTen.ToString().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            else if (String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchDate)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.NgayKham.ToString().Contains(searchDate)); //lọc theo chuỗi tìm kiếm
            }
            else if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchDate))
            {
                links = links.Where(s => s.NgayKham.ToString().Contains(searchDate) && s.BENHNHAN.HoTen.ToString().Contains(searchString));
            }
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.

            //Lay het trong lich hen trong DB
            List<PHIEUKHAM> listPK = new List<PHIEUKHAM>();
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
        public ActionResult IndexBacSi()
        {
            return View(database.PHIEUKHAMs.ToList()); ;
        }
    
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PHIEUKHAM pk)
        {
            try
            {
                database.PHIEUKHAMs.Add(pk);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        [HttpPost]
        public ActionResult Details(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            var link=database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
            
            return View(link);
        }
        [HttpPost]
        public ActionResult Edit( PHIEUKHAM pk)
        {
            if (pk.MaNhanVien == null)
            {
                return Content("Vui lòng chọn bác sĩ");
            }
            else
            {
                database.Entry(pk).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, PHIEUKHAM pk)
        {
            try
            {
                pk = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
                database.PHIEUKHAMs.Remove(pk);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }
        public ActionResult DeleteBacSi(int id)
        {
            return View(database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeleteBacSi(int id, PHIEUKHAM pk)
        {
            try
            {
                pk = database.PHIEUKHAMs.Where(s => s.MaPhieuKham == id).FirstOrDefault();
                database.PHIEUKHAMs.Remove(pk);
                database.SaveChanges();
                return RedirectToAction("IndexBacSi");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }

        public PartialViewResult CategoryPartial()
        {
            return PartialView(database.PHIEUKHAMs.ToList());
        }
   
        public ActionResult SelectBenhNhan()
        {
            BENHNHAN ct = new BENHNHAN();
            ct.listBN = database.BENHNHANs.ToList<BENHNHAN>();
            return PartialView(ct);
        }
        public ActionResult SelectNhanVien()
        {
            NHANVIEN ct = new NHANVIEN();
            ct.listNV = database.NHANVIENs.Where(s=>s.MaChucVu==1).ToList<NHANVIEN>();
            return PartialView(ct);
        }
        public ActionResult LichSuKham()

        {
            int maBN = (int)Session["MaBenhNhan"];
            var listPK = database.PHIEUKHAMs.OrderByDescending(x => x.MaBenhNhan).Where(x => x.MaBenhNhan == maBN);
            return View(listPK);
        }
        public ActionResult DanhSachHoaDon()
        {
            return View(database.HOADONs.ToList());
        }
        public ActionResult CreateHoaDon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateHoaDon(HOADON hd)
        {
            try
            {
                database.HOADONs.Add(hd);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Lối Tạo Hóa Đơn");
            }
        }
        public ActionResult ChiTietPhieuKhamNurse(int id)
        {
            var ChiTiet = database.CHITIETPHIEUKHAMs.Where(s => s.MaPhieuKham == id).ToList();

            return View(ChiTiet);
        }
        
    }
}