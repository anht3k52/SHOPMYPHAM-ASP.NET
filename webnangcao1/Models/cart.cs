using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webnangcao1.Models
{
    public class cart
    {
        public string masanpham { get; set; }
        public int soluong { get; set; }
        public Sanpham thongtin { get; set; }
    }
}