using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.BLL;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiTuiXachesController : ControllerBase
    {
        //private readonly QuanLyTuiXachContext _context;
        ILoaiTuiXachBLL _loaiTuixach;
        private string _path;
        public LoaiTuiXachesController(ILoaiTuiXachBLL loai, IConfiguration configuration)
        {
            _loaiTuixach = loai;
            _path = configuration["AppSettings:PATH"];
        }

        [Route("danhsach")]
        [HttpGet]
        public List<LoaiTuiXach> GetLoai()
        {
            return _loaiTuixach.getdataloaituixach();
        }

        [Route("AddloaiTui")]
        [HttpPost]
        public IActionResult addloai([FromBody] LoaiTuiXach loai)
        {
            try
            {
                _loaiTuixach.addloai(loai.TenLoai, loai.MoTa);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost("delLoaiTuixach")]
        public IActionResult delloai([FromBody] int maloai)
        {
            try
            {
                _loaiTuixach.delloai(maloai.ToString());
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost("update-loai")]
        public IActionResult Updateloai([FromBody] LoaiTuiXach loai)
        {
            try
            {
                _loaiTuixach.Updateloai(loai.MaLoaiTuiXach.ToString(), loai.TenLoai, loai.MoTa);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }


        [Route("Loai-Tui-page-count")]
        public List<int> getPageNumber()
        {
            List<int> li = new List<int>();
            int a = 0;
            if ((_loaiTuixach.getdataloaituixach().Count % 8) == 0)
            {
                a = _loaiTuixach.getdataloaituixach().Count / 8;
            }
            else
            {
                a = (_loaiTuixach.getdataloaituixach().Count / 8) + 1;
            }
            for (int i = 1; i <= a; i++)
            {
                li.Add(i);
            }
            return li;
        }
        [Route("Loai-Tui-page/{pageIndex}")]
        public List<LoaiTuiXach> paginate(int pageIndex)
        {
            return _loaiTuixach.Loaituipaginate(pageIndex);
        }
        [Route("LuuId/{id}")]
        public void LuuID(HttpContext context, string id)
        {
            var session = context.Session;
            session.SetString("StoreData", id);
        }
        [Route("GetLoaiTuiByID/{id}")]
        public IActionResult GetLoaiTuiByID(int id)
        {
            try
            {
                LoaiTuiXach type = new LoaiTuiXach();
                type = _loaiTuixach.GetLoaiTuiByID(id);
                return Ok(type);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        [Route("Search-Record-count/{key}")]
        public List<int> Search_Record_count(string key)
        {
            List<int> li = new List<int>();
            if (_loaiTuixach.countLoaiSearchin4(key).Count > 0)
            {
                int a = 0;
                if ((_loaiTuixach.countLoaiSearchin4(key).Count % 8) == 0)
                {
                    a = _loaiTuixach.countLoaiSearchin4(key).Count / 1;
                }
                else
                {
                    a = (_loaiTuixach.countLoaiSearchin4(key).Count / 8) + 1;
                }
                //int a = (_Tuixach.getdatatuixach().Count / 8) + 1;
                for (int i = 1; i <= a; i++)
                {
                    li.Add(i);
                }
                return li;
            }
            if (li.Count == 0)
            {
                li.Add(1);
            }
            return li;
        }
        [Route("Search-Loai-Tui-Paginate/{pageIndex}/{key}")]
        public List<LoaiTuiXach> SearchTuiPaginate(int pageIndex, string key)
        {
            return _loaiTuixach.SearchLoaiTuiPaginate(pageIndex, key);
        }
    }
}
