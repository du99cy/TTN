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
    
    public partial class chi_tiet_don_dat_hang
    {
        public string id_don_dat_hang { get; set; }
        public int id_muc { get; set; }
        public string id_xe { get; set; }
        public byte so_luong { get; set; }
        public decimal gia_ban { get; set; }
        public decimal giam_gia { get; set; }
    
        public virtual dat_hang dat_hang { get; set; }
        public virtual xe xe { get; set; }
    }
}