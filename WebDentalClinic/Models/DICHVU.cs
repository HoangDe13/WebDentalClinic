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
    
    public partial class DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICHVU()
        {
            this.CHITIETLICHHENs = new HashSet<CHITIETLICHHEN>();
            this.CHITIETPHIEUKHAMBENHs = new HashSet<CHITIETPHIEUKHAMBENH>();
        }
    
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string ThongTinDichVu { get; set; }
        public Nullable<int> DonGia { get; set; }
        public string MaLoaiDichVu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETLICHHEN> CHITIETLICHHENs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUKHAMBENH> CHITIETPHIEUKHAMBENHs { get; set; }
        public virtual LOAIDICHVU LOAIDICHVU { get; set; }
    }
}
