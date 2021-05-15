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
        public int MaPhieuKham { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public Nullable<int> MaBenhNhan { get; set; }
        public Nullable<System.DateTime> NgayKham { get; set; }
        public string GioKham { get; set; }
        public Nullable<System.DateTime> NgayTaiKham { get; set; }
        public string MoTaTrieuChung { get; set; }
        public string TinhTrang { get; set; }
    
        public virtual BENHNHAN BENHNHAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUKHAM> CHITIETPHIEUKHAMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual CHITIETPHIEUKHAM CHITIETPHIEUKHAM2 { get; set; }//a

        
    }
}
