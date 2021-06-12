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
    public class ServiceController : Controller
    {
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        // GET: Service
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in database.DICHVUs
                         select l).OrderBy(x => x.MaDichVu).ToList();

            //Lay het trong lich hen trong DB
            List<DICHVU> listPK = new List<DICHVU>();
            foreach (var x in database.DICHVUs)
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
        public ActionResult Index(string searchString, int? page)
        {

            var links = from l in database.DICHVUs // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.TenDichVu.ToString().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.

            //Lay het trong lich hen trong DB
            List<DICHVU> listPK = new List<DICHVU>();
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


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DICHVU dv )
        {
            try
            {
                database.DICHVUs.Add(dv);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int id)
        {
            return View(database.DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database
                .DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, DICHVU dv)
        {
            database.Entry(dv).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                DICHVU dv = database.DICHVUs.Where(s => s.MaDichVu == id).FirstOrDefault();
                database.DICHVUs.Remove(dv);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" Dịch Vụ Đang Được Sử Dụng, Không thể xóa !!!");
            }
            }
       /* [HttpPost]
        public ActionResult Delete( DICHVU dv)
        {
            try
            {
               
                database.DICHVUs.Remove(dv);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" this data is using in other table , error Delete");
            }
        }
    */
        public PartialViewResult CategoryPartial()
        {
            return PartialView(database.DICHVUs.ToList());
        }
        //[HttpGet]
        //public ActionResult Index(string searchString)
        //{
        //    var links = from l in database.DICHVUs // lấy toàn bộ liên kết
        //                select l;

        //    if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
        //    {
        //        links = links.Where(s => s.TenDichVu.ToString().Contains(searchString)); //lọc theo chuỗi tìm kiếm
        //    }
        //    return View(links);
        //}
    }
}