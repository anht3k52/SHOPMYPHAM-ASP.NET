﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webnangcao1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Loaisanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loaisanpham()
        {
            this.Sanphams = new HashSet<Sanpham>();
        }
        [Required(ErrorMessage = "Mã loại sản phẩm bắt buộc phải nhập")]
        [DisplayName("Mã Loại sản phẩm")]
        public string Maloaisanpham { get; set; }
        [Required(ErrorMessage = "Tên loại sản phẩm bắt buộc phải nhập")]
        [DisplayName("Tên loại sản phẩm")]
        public string Tenloaisanpham { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}