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

    public partial class HOADON
    {
        [Display(Name ="Mã Hóa Đơn")]
        public int MaHoaDon { get; set; }
        [Display(Name ="Ngày Lập")]
        public Nullable<System.DateTime> NgayLap { get; set; }
        [Display(Name ="Mã Phiếu Khám")]
        public Nullable<int> MaPhieuKham { get; set; }
        [Display(Name ="Tổng Tiền")]
        public Nullable<int> TongTien { get; set; }
        public virtual PHIEUKHAM PHIEUKHAM { get; set; }
    }
}
