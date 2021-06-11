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
            int Tong = 0;
            var list = db.HOADONs.ToList();
            foreach(var l in list)
            {
                Tong += int.Parse(l.TongTien.ToString());
            }
            
            string TongGia = Tong.ToString();
            ViewBag.Tong = TongGia;
            return View(list);
        }
        [HttpGet]
        public ActionResult BaoCaoDoanhThu(DateTime? startdate, DateTime? enddate)
        {
            var links = from l in db.HOADONs // lấy toàn bộ liên kết
                        select l;
            int Tong = 0;
            if (startdate != null && enddate != null) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
               /* Tong = 0;*/
                var list=db.HOADONs.Where(x => x.NgayLap>=startdate && x.NgayLap <= enddate).ToList();
                foreach(var i in list)
                {
                    Tong += int.Parse(i.TongTien.ToString());
                }
                Convert.ToDecimal(Tong).ToString();
                string TongGia = Tong.ToString("#,##0");
                ViewBag.Tong = TongGia;
                return View(list);
            }
            return View(links);
        }
        public ActionResult ChiTietBaoCaoDoanhThu(int id)
        {
            var list = db.CHITIETPHIEUKHAMs.Where(s=>s.MaPhieuKham==id).ToList();
            return View(list);
        }
    }
}