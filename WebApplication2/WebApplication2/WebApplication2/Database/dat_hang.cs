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
    
    public partial class dat_hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dat_hang()
        {
            this.chi_tiet_don_dat_hang = new HashSet<chi_tiet_don_dat_hang>();
        }
    
        public int stt { get; set; }
        public string id_don_dat_hang { get; set; }
        public string id_khach_hang { get; set; }
        public System.DateTime ngay_dat_hang { get; set; }
        public Nullable<System.DateTime> ngay_giao_hang { get; set; }
        public decimal tien_ship { get; set; }
        public decimal so_tien_khach_duoc_giam { get; set; }
        public string id_nhan_vien_ban_hang { get; set; }
        public string id_nhan_vien_giao_hang { get; set; }
        public string id_cua_hang { get; set; }
        public decimal tong_tien { get; set; }
        public bool is_dang_giao_hang { get; set; }
        public bool is_da_giao_hang { get; set; }
        public bool is_huy_don_hang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chi_tiet_don_dat_hang> chi_tiet_don_dat_hang { get; set; }
        public virtual cua_hang cua_hang { get; set; }
        public virtual khach_hang khach_hang { get; set; }
        public virtual nhan_viens nhan_viens { get; set; }
        public virtual nhan_viens nhan_viens1 { get; set; }
    }
}
