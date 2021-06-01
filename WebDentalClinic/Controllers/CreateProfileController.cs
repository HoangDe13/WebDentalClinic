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
        WebPhongKhamNhaKhoaEntities database = new WebPhongKhamNhaKhoaEntities();
        public ActionResult Index()
        {
            
            return View(database.BENHNHANs.ToList());
        }
        public ActionResult Details(int id)
        {
            return View(database.BENHNHANs.Where(s => s.MaBenhNhan == id).FirstOrDefault());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult UpdateProfile()
        {
            BENHNHAN bn  = new BENHNHAN();
            return View(bn);
        }
        public ActionResult Edit(int id)
        {
            return View(database.BENHNHANs.Where(s => s.MaBenhNhan == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, BENHNHAN cate)
        {
            database.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BENHNHAN Nv)
        {
            
                var check = database.BENHNHANs.FirstOrDefault(s => s.SoDienThoai == Nv.SoDienThoai);
                if (check == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.BENHNHANs.Add(Nv);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Số Điện Thoại Đã Tồn Tại";
                    return View();
                }




        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BENHNHAN BN)
        {
            var check = database.BENHNHANs.Where(s => s.MaBenhNhan == BN.MaBenhNhan ).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Không có thông tin";
                return View();
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                
                Session["MaBenhNhan"] = check.MaBenhNhan;
                
                return RedirectToAction("LichSuKham", "CreateProfile");
            }

        }
        [HttpGet]
        public ActionResult Index(string searchString)
        {
            var links = from l in database.BENHNHANs // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.SoDienThoai.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(links);
        }
        public ActionResult LichSuKham(int id)

        {
            var listPK = database.PHIEUKHAMs.OrderByDescending(x => x.MaBenhNhan).Where(x => x.MaBenhNhan == id);
            return View(listPK);
        }
        public ActionResult ChiTietphieukham(int id)
        {
           
            var listPK = database.CHITIETPHIEUKHAMs.OrderByDescending(x => x.MaDichVu).Where(x => x.MaPhieuKham == id);
            return View(listPK);
        }
        public ActionResult CreatePhieuKham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePhieuKham(PHIEUKHAM pk)
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
    }
}