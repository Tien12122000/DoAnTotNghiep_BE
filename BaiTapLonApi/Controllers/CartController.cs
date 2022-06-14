using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.BLL;
using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Ultils;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ITuiXachBLL _tui;
        IKhachHangBLL _khachHangBLL;
        IDonHangBLL _donHangBLL;
        IGiohangBLL _giohangBLL;
        IUserBLL _userBLL;
        IChiTietDonHangBLL _chiTietDonHangBLL;
        IChiTietGioHangBLL _chiTietGioHangBLL;



        public CartController(ITuiXachBLL tui, IKhachHangBLL khachHangBLL,
            IDonHangBLL  donHangBLL,
            IUserBLL  userBLL, IChiTietDonHangBLL chiTietDonHangBLL,
            IChiTietGioHangBLL chiTietGioHangBLL, IGiohangBLL giohangBLL)
        {
            _tui = tui;
            _khachHangBLL = khachHangBLL;
            _donHangBLL = donHangBLL;
            _userBLL = userBLL;
            _chiTietDonHangBLL = chiTietDonHangBLL;
            _chiTietGioHangBLL = chiTietGioHangBLL;
            _giohangBLL = giohangBLL;


        }
        [Route("Add-to-cart/{idSanPham}")]
        public CartModel GetSalteProd(int idSanPham)
        {
            CartModel cart = new CartModel();
            TuiXach tui = _tui.GetTuiByID(idSanPham);
            SaleProduct saleProduct = new SaleProduct();
            saleProduct.Dongia = double.Parse(tui.Gia.ToString());
            saleProduct.MaSanPham = tui.MaTuiXach;
            saleProduct.Tui = tui;
            saleProduct.Soluong = 1;

            cart.Products = new List<SaleProduct>();
            cart.Tongsoluong1 = 1;
            cart.TongTien1 = double.Parse(tui.Gia.ToString());
            cart.Products.Add(saleProduct);
            return cart;
        }
        [Route("Create-Sale-Prod/{id}")]
        public SaleProduct createSaleProd(int id)
        {
            TuiXach tui = _tui.GetTuiByID(id);
            SaleProduct saleProduct = new SaleProduct();
            saleProduct.Dongia = double.Parse(tui.Gia.ToString());
            saleProduct.MaSanPham = tui.MaTuiXach;
            saleProduct.Tui = tui;
            saleProduct.Soluong = 1;
            return saleProduct;
        }


        [NonAction]
        public bool checkExsits(int id, CartModel cart)
        {
            if (cart.Products.Count == 0 || cart.Products == null)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < cart.Products.Count; i++)
                {
                    if(cart.Products[i].MaSanPham == id)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        [HttpPost]
        [Route("CheckOut")]
        public IActionResult CheckOut([FromBody] TempBill tempBill)
        {
            // kiểm tra xem email đã tồn tại trong danh sách khách hàng hay chưa
            //nếu email không tồn tại
            try
            {
                if (checkEmailExsits(tempBill.Email) == false)
                {
                    // tạo mới các đối tượng khách hàng, đơn hàng, giỏ hàng, user
                    KhachHang khachHang = new KhachHang();

                    DonHang donHang = new DonHang();
                    GioHang gioHang = new GioHang();

                    khachHang.TenKhachHang = tempBill.Ten;
                    khachHang.SoDienThoai = tempBill.Phone;
                    khachHang.Email = tempBill.Email;
                    khachHang.DiaChi = tempBill.Address;
                    //insert vào bảng khách hàng
                    _khachHangBLL.addKhachHang(khachHang.TenKhachHang, khachHang.SoDienThoai, khachHang.Email, khachHang.DiaChi);


                    int ma = 0;
                    int madon = 0;
                    int magiohang = 0;

                    List<KhachHang> li = _khachHangBLL.getAllKhachHang();
                    //tìm mã lớn nhất sau khi insert vào bảng khách hàng
                    for (int i = 0; i < li.Count; i++)
                    {
                        if (li[i].MaKhachHang > ma)
                        {
                            ma = li[i].MaKhachHang;
                        }
                    }
                    User user = new User();
                    user.TenDangNhap = tempBill.Email;
                    user.MatKhau = tempBill.Pass;
                    //insert vào bảng User
                    _userBLL.addUser(user.TenDangNhap, user.MatKhau);
                    donHang.MaKhachHang = ma;
                    donHang.MaNhaVien = 1;
                    donHang.NgayDatHang = DateTime.Now.ToShortTimeString();
                    donHang.DiaChiGiaoHang = tempBill.Address;
                    donHang.SoDienThoai = tempBill.Phone;
                    donHang.TrangThaiDonHang = "Chưa hoàn thành";
                    donHang.TongTien = tempBill.Tongtien;
                    donHang.GhiChu = tempBill.Note;
                    donHang.tenKhachHang = tempBill.Ten;
                    //insert vào bảng đơn hàng
                    _donHangBLL.addDonHang(donHang.MaKhachHang.ToString(), donHang.MaNhaVien.ToString()
                        , donHang.NgayDatHang.ToString(), donHang.DiaChiGiaoHang,
                        donHang.SoDienThoai, donHang.TrangThaiDonHang, donHang.TongTien.ToString(), donHang.GhiChu, donHang.tenKhachHang);
                    List<DonHang> donHangs = _donHangBLL.getAllDonHang();
                    for (int i = 0; i < donHangs.Count; i++)
                    {
                        if (donHangs[i].MaDonHang > madon)
                        {
                            madon = donHangs[i].MaDonHang;
                        }
                    }

                    gioHang.NgayMua = DateTime.Now.ToShortTimeString();
                    gioHang.TongTien = tempBill.Tongtien;
                    gioHang.MaKhachHang = ma;
                    //insert vào bảng giỏ hàng
                    _giohangBLL.addGioHang(gioHang.MaKhachHang.ToString(), gioHang.NgayMua, gioHang.TongTien.ToString());
                    List<GioHang> gioHangs = _giohangBLL.getAllGioHang();


                    //lấy ra mã giỏ hàng vừa thêm vào bảng đơn hàng và làm khóa ngoại cho bảng chi tiết giỏ hàng
                    for (int i = 0; i < gioHangs.Count; i++)
                    {
                        if (gioHangs[i].MaGioHang > magiohang)
                        {
                            magiohang = gioHangs[i].MaGioHang;
                        }
                    }
                    for (int i = 0; i < tempBill.Products.Count; i++)
                    {
                        //tạo mới chi tiết đơn hàng và gán giá trị cho các thuộc tính
                        ChiTietDonHang chiTietDonHang = new ChiTietDonHang();
                        chiTietDonHang.MaDonHang = madon;
                        chiTietDonHang.MaTuiXach = tempBill.Products[i].MaSanPham;
                        chiTietDonHang.SoLuong = tempBill.Products[i].Soluong;
                        chiTietDonHang.DonGia = tempBill.Products[i].Dongia;

                        //insert vào bảng chi tiết đơn hàng

                        _chiTietDonHangBLL.addChiTietDonHang(chiTietDonHang.MaDonHang.ToString(),
                            chiTietDonHang.MaTuiXach.ToString(), chiTietDonHang.SoLuong.ToString(),
                            chiTietDonHang.DonGia.ToString());



                        //tạo mới chi tiết giỏ hàng và gán các thuộc tính cho đối tượng vừa tạo
                        ChiTietGioHang chiTietGioHang = new ChiTietGioHang();
                        chiTietGioHang.MaGioHang = magiohang;
                        chiTietGioHang.MaTuiXach = tempBill.Products[i].MaSanPham;
                        chiTietGioHang.DonGia = tempBill.Products[i].Dongia;
                        chiTietGioHang.soluong = tempBill.Products[i].Soluong;
                        //insert vào bàng chi tiết giỏ hàng
                        _chiTietGioHangBLL.addChiTietGioHang(magiohang.ToString(), chiTietGioHang.MaTuiXach.ToString()
                            , chiTietGioHang.DonGia.ToString(),
                            chiTietGioHang.soluong.ToString());
                    }

                    
                }
                // nếu email đã có trong bảng khách hàng
                else if (checkEmailExsits(tempBill.Email) == true)
                {
                    //khởi tạo đơn hàng và giỏ hàng
                    DonHang donHang = new DonHang();
                    GioHang gioHang = new GioHang();
                    int madon = 0;
                    int magiohang = 0;
                    int makhanghang = 0;
                    // lấy ra mã hóa đơn vừa insert vào
                    List<KhachHang> li = _khachHangBLL.getAllKhachHang();
                    for (int i = 0; i < li.Count; i++)
                    {
                        if (li[i].Email == tempBill.Email)
                        {
                            makhanghang = li[i].MaKhachHang;
                        }
                    }

                    // cập nhật lại mật khẩu tài khoản của khách hàng trong bảng user
                    _userBLL.updateUsers(tempBill.Email, tempBill.Pass);
                    donHang.MaKhachHang = makhanghang;
                    donHang.MaNhaVien = 1;
                    donHang.NgayDatHang = DateTime.Now.ToShortTimeString();
                    donHang.DiaChiGiaoHang = tempBill.Address;
                    donHang.SoDienThoai = tempBill.Phone;
                    donHang.TrangThaiDonHang = "Unfinished";
                    donHang.TongTien = tempBill.Tongtien;
                    donHang.GhiChu = tempBill.Note;
                    donHang.tenKhachHang = tempBill.Ten;
                    //insert vào bảng đơn hàng
                    _donHangBLL.addDonHang(donHang.MaKhachHang.ToString(), donHang.MaNhaVien.ToString()
                        , donHang.NgayDatHang.ToString(), donHang.DiaChiGiaoHang,
                        donHang.SoDienThoai, donHang.TrangThaiDonHang, donHang.TongTien.ToString(), donHang.GhiChu, donHang.tenKhachHang);
                    List<DonHang> donHangs = _donHangBLL.getAllDonHang();
                    //lấy ra mã đơn hàng vừa thêm vào bảng đơn hàng và làm khóa ngoại cho bảng chi tiết đơn hàng
                    for (int i = 0; i < donHangs.Count; i++)
                    {
                        if (donHangs[i].MaDonHang > madon)
                        {
                            madon = donHangs[i].MaDonHang;
                        }
                    }

                    gioHang.NgayMua = DateTime.Now.ToShortTimeString();
                    gioHang.TongTien = tempBill.Tongtien;
                    gioHang.MaKhachHang = makhanghang;
                    //insert vào bảng giỏ hàng
                    _giohangBLL.addGioHang(gioHang.MaKhachHang.ToString(), gioHang.NgayMua, gioHang.TongTien.ToString());
                    List<GioHang> gioHangs = _giohangBLL.getAllGioHang();
                    //lấy ra mã giỏ hàng vừa thêm vào bảng đơn hàng và làm khóa ngoại cho bảng chi tiết giỏ hàng
                    for (int i = 0; i < gioHangs.Count; i++)
                    {
                        if (gioHangs[i].MaGioHang > magiohang)
                        {
                            magiohang = gioHangs[i].MaGioHang;
                        }
                    }
                    for (int i = 0; i < tempBill.Products.Count; i++)
                    {
                        //tạo mới chi tiết đơn hàng và gán giá trị cho các thuộc tính
                        ChiTietDonHang chiTietDonHang = new ChiTietDonHang();
                        chiTietDonHang.MaDonHang = madon;
                        chiTietDonHang.MaTuiXach = tempBill.Products[i].MaSanPham;
                        chiTietDonHang.SoLuong = tempBill.Products[i].Soluong;
                        chiTietDonHang.DonGia = tempBill.Products[i].Dongia;
                        //insert vào bảng chi tiết đơn hàng
                        _chiTietDonHangBLL.addChiTietDonHang(chiTietDonHang.MaDonHang.ToString(),
                            chiTietDonHang.MaTuiXach.ToString(), chiTietDonHang.SoLuong.ToString(),
                            chiTietDonHang.DonGia.ToString());



                        //tạo mới chi tiết giỏ hàng và gán các thuộc tính cho đối tượng vừa tạo
                        ChiTietGioHang chiTietGioHang = new ChiTietGioHang();
                        chiTietGioHang.MaGioHang = magiohang;
                        chiTietGioHang.MaTuiXach = tempBill.Products[i].MaSanPham;
                        chiTietGioHang.DonGia = tempBill.Products[i].Dongia;
                        chiTietGioHang.soluong = tempBill.Products[i].Soluong;
                        //insert vào bàng chi tiết giỏ hàng
                        _chiTietGioHangBLL.addChiTietGioHang(magiohang.ToString(), chiTietGioHang.MaTuiXach.ToString()
                            , chiTietGioHang.DonGia.ToString(),
                            chiTietGioHang.soluong.ToString());
                    }
                    //return Ok();
                }
                try
                {
                    MailUtils.SendMailGoogleSmtp(tempBill.Email).Wait();
                    return Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest();
                    throw;
                }
                //return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }

        }
        [NonAction]
        public bool checkEmailExsits(string email)
        {
            bool ok = false;
            List<KhachHang> li = _khachHangBLL.getAllKhachHang();
            for (int i = 0; i < li.Count; i++)
            {
                if (li[i].Email == email)
                {
                    ok = true;
                }
            }
            return ok;
        }
    }
}
