using DoAnTotNghiep.BLL;
using DoAnTotNghiep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangControllerr : ControllerBase
    {
        IDonHangBLL _donHangBLL;
        public DonHangControllerr(IDonHangBLL donHangBLL)
        {
            _donHangBLL = donHangBLL;
        }

        [Route("Get-all-Donhang")]
        public List<DonHang> GetallDonhang()
        {
            return _donHangBLL.getAllDonHang();
        }
        [HttpGet("Get-Donhang-Number")]
        public int GetDonhangNumber()
        {
            return _donHangBLL.getAllDonHang().Count;
        }
        [HttpGet("Danh-Sach-Don-Hang-paginate/{pageIndex}")]
        public List<DonHang> GetDonHangs(string pageIndex)
        {
            return _donHangBLL.DonHangPaginate(int.Parse(pageIndex));
        }
        [HttpGet("Get-Row-total-don-hang-records")]
        public List<int> getdonhangrecords()
        {
            List<int> li = new List<int>();
            int a = 0;
            if ((_donHangBLL.getAllDonHang().Count % 4) == 0)
            {
                a = _donHangBLL.getAllDonHang().Count / 4;
            }
            else
            {
                a = (_donHangBLL.getAllDonHang().Count / 4) + 1;
            }
            for (int i = 1; i <= a; i++)
            {
                li.Add(i);
            }
            return li;
        }
        [Route("cap-nhat-don-hang/{id}/{trangthaidonhang}")]
        public void UpdateDonHang(string id, string trangthaidonhang)
        {
            _donHangBLL.UpdateDonHang(id, trangthaidonhang);
        }
        [Route("Del-Don-Hang/{id}")]
        public void DelDonHang(string id)
        {
            _donHangBLL.DelDonHang(id);
        }
        [Route("Search-Dn-Hang/{pageIndex}/{key}")]
        public List<DonHang> SearchDonHang(string pageIndex, string key)
        {
            return _donHangBLL.SearchDonHangPaginate(int.Parse(pageIndex), key);
        }
        [Route("Count-Search-DonHang/{key}")]
        public List<int> SearchDonHang(string key)
        {
            List<int> li = new List<int>();
            if (_donHangBLL.countSearchDonHangin4(key).Count > 0)
            {
                int a = 0;
                if ((_donHangBLL.countSearchDonHangin4(key).Count % 4) == 0)
                {
                    a = _donHangBLL.countSearchDonHangin4(key).Count / 4;
                }
                else
                {
                    a = (_donHangBLL.countSearchDonHangin4(key).Count / 4) + 1;
                }
                //int a = (_Tuixach.getdatatuixach().Count / 8) + 1;
                for (int i = 1; i <= a; i++)
                {
                    li.Add(i);
                }
                return li;
            }
            return li;
        }
        [Route("Get-All-Don-Hang-User-Khach-Hang-record-count/{email}")]
        public List<int> getDonHangByUser_KhachHang(string email)
        {
            List<int> li = new List<int>();
            if (_donHangBLL.getDonHangByUser_KhachHang(email).Count > 0)
            {
                int a = 0;
                if ((_donHangBLL.getDonHangByUser_KhachHang(email).Count % 4) == 0)
                {
                    a = _donHangBLL.getDonHangByUser_KhachHang(email).Count / 4;
                }
                else
                {
                    a = (_donHangBLL.getDonHangByUser_KhachHang(email).Count / 4) + 1;
                }
                //int a = (_Tuixach.getdatatuixach().Count / 8) + 1;
                for (int i = 1; i <= a; i++)
                {
                    li.Add(i);
                }
                return li;
            }
            return li;
        }
        [Route("Don-Hang-User-paginate/{pagIndex}/{email}")]
        public List<DonHang> DonHangUserPaginate(string pagIndex, string email)
        {
            return _donHangBLL.getDonHangByUser_KhachHang_Paginate(pagIndex, email);
        }
        [HttpGet("GetDonHangById/{id}")]
        public DonHang GetDonHangById(int id)
        {
            DonHang bill = new DonHang();
            List<DonHang> li = _donHangBLL.getAllDonHang();
            for (int i = 0; i < li.Count; i++)
            {
                if (li[i].MaDonHang == id)
                {
                    bill = li[i];
                    break;
                }
            }
            return bill;
        }
    }
}
