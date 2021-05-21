﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDentalClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class LICHHEN
    {
        [Display(Name = "Mã Lịch Hẹn")]
        public int MaLichHen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Họ và Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(10)]
        [Phone]
        public string SoDienThoai { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Hẹn")]
        
        [Required(ErrorMessage = "Vui lòng chọn ngày")]
        public Nullable<System.DateTime> NgayHen { get; set; }
        [Display(Name = "Giờ Hẹn")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Vui lòng chọn giờ")]
        public string GioHen { get; set; }
        [Display(Name ="Tình Trạng")]
        public string TinhTrang { get; set; }
        [Display(Name = "Bác Sĩ")]
        public Nullable<int> MaNhanVien { get; set; }
        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
    
}
