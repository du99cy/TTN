//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class nhan_viens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhan_viens()
        {
            this.dat_hang = new HashSet<dat_hang>();
            this.dat_hang1 = new HashSet<dat_hang>();
            this.don_nhap_hang = new HashSet<don_nhap_hang>();
            this.nhan_viens1 = new HashSet<nhan_viens>();
        }
    
        public int stt { get; set; }
        public string id_nhan_vien { get; set; }
        public string ten_nhan_vien { get; set; }
        public string SDT { get; set; }
        public string dia_chi { get; set; }
        public System.DateTime ngay_vao_lam_viec { get; set; }
        public string id_chuc_vu { get; set; }
        public string id_cua_hang { get; set; }
        public string id_nguoi_quan_li { get; set; }
        public bool is_dang_lam_viec { get; set; }
        public bool is_nghi_viec { get; set; }
    
        public virtual cua_hang cua_hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dat_hang> dat_hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dat_hang> dat_hang1 { get; set; }
        public virtual chuc_vu chuc_vu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<don_nhap_hang> don_nhap_hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhan_viens> nhan_viens1 { get; set; }
        public virtual nhan_viens nhan_viens2 { get; set; }
    }
}
