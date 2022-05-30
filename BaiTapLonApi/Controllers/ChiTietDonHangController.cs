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
    public class ChiTietDonHangController : ControllerBase
    {
        IChiTietDonHangBLL _chiTietDonHangBLL;
        public ChiTietDonHangController(IChiTietDonHangBLL chiTietDonHangBLL)
        {
            _chiTietDonHangBLL = chiTietDonHangBLL;
        }
        [Route("sp_ChiTietDonHang_Paginate_By_ID/{pageindex}/{id}")]
        public List<ChiTietDonHang> sp_ChiTietDonHang_Paginate_By_ID(string pageindex, string id)
        {
            return _chiTietDonHangBLL.sp_ChiTietDonHang_Paginate_By_ID(int.Parse(pageindex), int.Parse(id));
        }
        [Route("get-Chi-Tiet-Don-Hang-Record-count/{id}")]
        public List<int> GetAllChiTietDonByID(string id)
        {
            List<int> li = new List<int>();
            int a = 0;
            if ((_chiTietDonHangBLL.GetAllChiTietDonByID(int.Parse(id)).Count % 4) == 0)
            {
                a = _chiTietDonHangBLL.GetAllChiTietDonByID(int.Parse(id)).Count / 4;
            }
            else
            {
                a = (_chiTietDonHangBLL.GetAllChiTietDonByID(int.Parse(id)).Count / 4) + 1;
            }
            for (int i = 1; i <= a; i++)
            {
                li.Add(i);
            }
            return li;
        }
        [HttpGet("GetAllBillDetailById/{id}")]
        public List<ChiTietDonHang> GetAllChiTietDon(string id)
        {
            return _chiTietDonHangBLL.GetAllChiTietDonByID(int.Parse(id));
        }
    }
}
