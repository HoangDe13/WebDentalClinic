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
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.CHITIETLICHHENs = new HashSet<CHITIETLICHHEN>();
            this.PHIEUKHAMBENHs = new HashSet<PHIEUKHAMBENH>();
        }
    
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NamSinh { get; set; }
        public Nullable<int> SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string MaChucVu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETLICHHEN> CHITIETLICHHENs { get; set; }
        public virtual CHUCVU CHUCVU { get; set; }
        public virtual TAIKHOANNHANVIEN TAIKHOANNHANVIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUKHAMBENH> PHIEUKHAMBENHs { get; set; }
    }
}
