//------------------------------------------------------------------------------
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
    
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            this.chitietdons = new HashSet<chitietdon>();
        }
    
        public string Masanpham { get; set; }
        public string Maloaisanpham { get; set; }
        public string Tensanpham { get; set; }
        public string Thongtin { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public string Hinhchinh { get; set; }
        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public string Hinh4 { get; set; }
        public Nullable<int> Gia { get; set; }
        public Nullable<int> Tinhtrang { get; set; }
        public string thuoctinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdon> chitietdons { get; set; }
        public virtual Loaisanpham Loaisanpham { get; set; }
    }
}
