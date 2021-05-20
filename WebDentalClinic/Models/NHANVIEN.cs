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

    using System.ComponentModel.DataAnnotations.Schema;


    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.LICHHENs = new HashSet<LICHHEN>();
            this.PHIEUKHAMs = new HashSet<PHIEUKHAM>();
        }


        [Display(Name = "Mã Nhân Viên")]

        public int MaNhanVien { get; set; }
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Giới Tính")]

        public Nullable<int> GioiTinh { get; set; }
        [Display(Name = "Năm Sinh")]
        public Nullable<int> NamSinh { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }
        [Display(Name = "Địa Chỉ")]

        public string DiaChi { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Chức Vụ")]
        public Nullable<int> MaChucVu { get; set; }
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
       
        public virtual CHUCVU CHUCVU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHHEN> LICHHENs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUKHAM> PHIEUKHAMs { get; set; }
        [NotMapped]
        public List<NHANVIEN> listNV { get; set; }
    }
}
