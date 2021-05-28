using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebDentalClinic.Models;

namespace WebDentalClinic.Controllers
{

    public class CustomerController : Controller
    {
        WebPhongKhamNhaKhoaEntities db = new WebPhongKhamNhaKhoaEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {

            int id = (int)Session["MaBenhNhan"];
            var benhnhan = db.BENHNHANs.Where(s => s.MaBenhNhan == id).FirstOrDefault();
            return View(benhnhan);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IntroDental()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IntroInfrastructure()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IntroDoctor()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Service()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CreateLichHen()
        {
            int idbenhnhan = (int)Session["MaBenhNhan"];
            Session["BenhNhanLichHen"] = db.BENHNHANs.Where(s => s.MaBenhNhan == idbenhnhan).FirstOrDefault();
            return View();
        }
        public ActionResult ChangePassword()
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
                return RedirectToAction("DatLichThanhCongCus", "Customer");
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
            ct.listNV = db.NHANVIENs.ToList<NHANVIEN>();
            return PartialView(ct);
        }
        public ActionResult DatLichThanhCongCus()
        {
            return View();
        }
        public ActionResult LichSuKham()

        {
            int maBN = (int)Session["MaBenhNhan"];
            var listPK = db.PHIEUKHAMs.OrderByDescending(x => x.MaBenhNhan).Where(x => x.MaBenhNhan == maBN);
            return View(listPK);
        }
        public ActionResult ChiTietphieukham(int id)
        {
            //int a = pk.MaPhieuKham;
            //return View(db.CHITIETPHIEUKHAMs.Where(s => s.MaChiTietPhieuKham == a).FirstOrDefault());

            var listPK = db.CHITIETPHIEUKHAMs.OrderByDescending(x => x.MaDichVu).Where(x => x.MaPhieuKham == id);
            return View(listPK);
        }
        public ActionResult EditProfile()
        {
            int maBN = (int)Session["MaBenhNhan"];
            var idBN = db.BENHNHANs.Where(s => s.MaBenhNhan == maBN).FirstOrDefault();
            return View(idBN);
        }
        [HttpPost]
        public ActionResult EditProfile(BENHNHAN std)
        {
            try
            {

            
            db.Entry(std).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Confirmpwd", "Vui lòng kiểm tra mật khẩu");
                return View(std);
            }
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult ChangePass(int id,string pass)
        {
            ChangePW c = new ChangePW();
            c.Id = id;
            
            return View(c);
        }
      [HttpPost]
       public ActionResult ChangePass(ChangePW cp)
        {
            int id = cp.Id;
            var BenhNhan = db.BENHNHANs.Where(s => s.MaBenhNhan == id).FirstOrDefault();
            if(BenhNhan.MatKhau==cp.PasswordOld)
            {
                    
                    BenhNhan.MatKhau = cp.PasswordNew;
                    BenhNhan.Confirmpwd = BenhNhan.MatKhau;
                    db.Entry(BenhNhan).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("passwordOld", "Vui lòng kiểm tra mật khẩu");
                return View(cp);
            }
        }
        


   }
}