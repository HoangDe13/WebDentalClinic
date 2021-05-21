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

    public partial class BENHNHAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BENHNHAN()
        {
            this.PHIEUKHAMs = new HashSet<PHIEUKHAM>();
        }
        [Display(Name = "Mã Bệnh Nhân")]
        public int MaBenhNhan { get; set; }
        [Required(ErrorMessage = "Vui lòng điền thông tin")]
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Vui lòng điền thông tin")]
        [Display(Name = "Giới Tính")]
        public Nullable<int> GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng điền thông tin")]
        [Display(Name = "Năm Sinh")]
        public Nullable<int> NamSinh { get; set; }
        [Required(ErrorMessage = "Vui lòng điền thông tin")]
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }
        [Required(ErrorMessage = "Vui lòng điền thông tin")]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Vui lòng điền thông tin")]
        [Display(Name = "Mật Khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
        [Display(Name ="Xác Nhận Mật Khẩu")]
        [Required(ErrorMessage = "Nhập Lại Mật Khẩu")]
        [Compare("MatKhau", ErrorMessage = "Sai mật Khẩu, Vui Lòng Nhập Lại")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Confirmpwd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUKHAM> PHIEUKHAMs { get; set; }
        public List<BENHNHAN> listBN { get; set; }
    }
}
