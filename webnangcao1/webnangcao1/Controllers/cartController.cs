using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnangcao1.Models;

namespace webnangcao1.Controllers
{
    public class cartController : Controller
    {
        // GET: cart
        public ActionResult Index()
        {
            List<cart> liscart = (List<cart>)Session["liscart"];
            if (liscart == null)
            {
                liscart = new List<cart>();
            }
            return View(liscart);
        }
        public ActionResult themsanpham(string masanpham)
        {
            //xac dinh san pham se them
            List<cart> liscart = (List<cart>)Session["liscart"];
            if(liscart ==null)
            {
                liscart = new List<cart>();
            }
            cart obj = liscart.FirstOrDefault(x => x.masanpham == masanpham);
            if(obj !=null)
            {
                obj.soluong++;
            }
            else
            {
                shopchangagoidemEntities1 db = new shopchangagoidemEntities1();
                obj = new cart();
                obj.masanpham = masanpham;
                obj.thongtin = db.Sanphams.First( x => x.Masanpham == masanpham);
                obj.soluong = 1;
                liscart.Add(obj);
            }
            Session["liscart"] = liscart;

            return RedirectToAction("Index");
        }
        public ActionResult capnhatgio(string masanpham, FormCollection f)
        {
            shopchangagoidemEntities1 db = new shopchangagoidemEntities1();
            //Kiểm tra masp
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masanpham == masanpham);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            //Lấy giỏ hàng ra từ session
            List<cart> liscart = (List<cart>)Session["liscart"];
            cart obj = liscart.FirstOrDefault(x => x.masanpham == masanpham);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (obj != null)
            {
                obj.soluong = int.Parse(f["txtsoluong"].ToString());

            }
            return RedirectToAction("index");
        }
        public ActionResult XoaGioHang(string masanpham)
        {
            //Kiểm tra masp
            shopchangagoidemEntities1 db = new shopchangagoidemEntities1();
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masanpham == masanpham);
            //Lấy giỏ hàng ra từ session
            List<cart> liscart = (List<cart>)Session["liscart"];
            cart obj = liscart.SingleOrDefault(x => x.thongtin.Masanpham == masanpham);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (obj != null)
            {
                liscart.RemoveAll(n => n.thongtin.Masanpham == masanpham);

            }
            if (liscart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
                        if (Session["Use"] == null || Session["Use"].ToString() == "")
            {
                return RedirectToAction("Index", "dangnhap");
            }
            //Kiểm tra giỏ hàng
            if (Session["liscart"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            shopchangagoidemEntities1 db = new shopchangagoidemEntities1();
            donhang dh = new donhang();
            taikhoan kh = (taikhoan)Session["Use"];
            List<cart> liscart = (List<cart>)Session["liscart"];
            dh.Tentaikhoan = kh.Tentaikhoan;
            dh.ngaydat = DateTime.Now;
            db.donhangs.Add(dh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in liscart)
            {
                chitietdon ctd = new chitietdon();
                ctd.Madonhang = dh.Madonhang;
                ctd.Masanpham = item.thongtin.Masanpham;
                ctd.soluong = item.soluong;
                ctd.thanhtien = item.soluong * item.thongtin.Gia;
                db.chitietdons.Add(ctd);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}