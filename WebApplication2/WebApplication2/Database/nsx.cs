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
    
    public partial class nsx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nsx()
        {
            this.don_nhap_hang = new HashSet<don_nhap_hang>();
            this.xes = new HashSet<xe>();
        }
    
        public int stt { get; set; }
        public string id_nsx { get; set; }
        public string ten_nsx { get; set; }
        public string SDT { get; set; }
        public string email { get; set; }
        public string dia_chi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<don_nhap_hang> don_nhap_hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<xe> xes { get; set; }
    }
}
