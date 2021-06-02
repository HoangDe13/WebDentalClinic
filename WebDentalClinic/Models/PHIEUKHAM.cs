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

    public partial class PHIEUKHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUKHAM()
        {
            this.CHITIETPHIEUKHAMs = new HashSet<CHITIETPHIEUKHAM>();
            this.HOADONs = new HashSet<HOADON>();

        }

        [Key]

        [Display(Name = "Mã Phiếu Khám")]
        public int MaPhieuKham { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tên nhân viên")]
        [Display(Name = "Mã Nhân Viên")]
        public Nullable<int> MaNhanVien { get; set; }
        [Display(Name = "Mã Bệnh Nhân")]
        [Required(ErrorMessage = "Vui lòng điền mã bệnh nhân")]
        public Nullable<int> MaBenhNhan { get; set; }
        [Display(Name = "Ngày Khám")]
        [DataType(DataType.Date)]

        [Required(ErrorMessage = "Vui lòng chọn ngày")]
        public Nullable<System.DateTime> NgayKham { get; set; }
        [Display(Name = "Giờ Khám")]
        [DataType(DataType.Time)]
        public string GioKham { get; set; }
        [Display(Name = "Ngày Tái Khám")]
        [DataType(DataType.Date)]

        public Nullable<System.DateTime> NgayTaiKham { get; set; }
        [Display(Name = "Triệu Chứng")]
        public string MoTaTrieuChung { get; set; }
        [Display(Name = "Tình Trạng")]

        public string TinhTrang { get; set; }

        public virtual BENHNHAN BENHNHAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUKHAM> CHITIETPHIEUKHAMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual CHITIETPHIEUKHAM CHITIETPHIEUKHAM { get; set; }//a


    }
}
