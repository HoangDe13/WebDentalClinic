//------------------------------------------------------------------------------
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
    
    public partial class CHITIETLICHHEN
    {
        public string MaChiTietLichHen { get; set; }
        public string MaNhanVien { get; set; }
        public string MaDichVu { get; set; }
        public string GhiChu { get; set; }
        public string MaLichHen { get; set; }
    
        public virtual DICHVU DICHVU { get; set; }
        public virtual LICHHEN LICHHEN { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}