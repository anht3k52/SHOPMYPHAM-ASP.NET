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

    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            this.chitietdons = new HashSet<chitietdon>();
        }
        [Required(ErrorMessage = "Mã sản phẩm bắt buộc phải nhập")]
        [DisplayName("Mã sản phẩm")]
        public string Masanpham { get; set; }
        [DisplayName("Loại sản phẩm")]
        public string Maloaisanpham { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm bắt buộc phải nhập")]
        [DisplayName("Tên sản phẩm")]
        public string Tensanpham { get; set; }
        [DisplayName("Thông tin")]
        public string Thongtin { get; set; }
        [DisplayName("Ngày")]
        [DataType(DataType.Date, ErrorMessage ="Dữ liệu không đúng định dạng")]
        public Nullable<System.DateTime> Ngay { get; set; }
        [DisplayName("Hình đại điện chính")]
        public string Hinhchinh { get; set; }
        [DisplayName("Hình số 1")]
        public string Hinh1 { get; set; }
        [DisplayName("Hình số 2")]
        public string Hinh2 { get; set; }
        [DisplayName("Hình số 3")]
        public string Hinh3 { get; set; }
        [DisplayName("Hình số 4")]
        public string Hinh4 { get; set; }
        [Required(ErrorMessage = "Giá sản phẩm bắt buộc phải nhập")]
        [DisplayName("Giá sản phẩm")]
        public Nullable<int> Gia { get; set; }
        [Required(ErrorMessage = "Trạng thái sản phẩm bắt buộc phải nhập")]
        [DisplayName("Trạng thái sản phẩm")]
        public Nullable<int> Tinhtrang { get; set; }
        [DisplayName("Thuộc tính")]
        public string thuoctinh { get; set; }
    
        public virtual Loaisanpham Loaisanpham { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdon> chitietdons { get; set; }
    }
}
