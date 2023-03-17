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

    public partial class taikhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taikhoan()
        {
            this.donhangs = new HashSet<donhang>();
        }
        [Required(ErrorMessage ="Tên tài khoản bắt buộc phải nhập")]
        [DisplayName("Tên tài khoản")]
        public string Tentaikhoan { get; set; }
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [DisplayName("Mật khẩu")]
        public string Matkhau { get; set; }
        [DisplayName("Tên đầy đủ")]
        public string fullname { get; set; }
        [DisplayName("Quyền")]
        public string quyen { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Số điện thoại")]
        public Nullable<int> sdt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donhang> donhangs { get; set; }
    }
}
