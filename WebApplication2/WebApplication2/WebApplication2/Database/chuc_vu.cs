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
    
    public partial class chuc_vu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public chuc_vu()
        {
            this.nhan_viens = new HashSet<nhan_viens>();
        }
    
        public int stt { get; set; }
        public string id_chuc_vu { get; set; }
        public string ten_chuc_vu { get; set; }
        public decimal luong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhan_viens> nhan_viens { get; set; }
    }
}
