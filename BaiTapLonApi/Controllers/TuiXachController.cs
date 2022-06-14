using DoAnTotNghiep.BLL;
using DoAnTotNghiep.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuiXachController : ControllerBase
    {
        ITuiXachBLL _Tuixach;
        private string _path;
        private string _fePath;
        //private UserManager<TuiXach> userManager;
        public TuiXachController(ITuiXachBLL tuiXachBLL, IConfiguration configuration)
        {
            this._Tuixach = tuiXachBLL;
            //userManager = userMgr;
            _path = configuration["AppSettings:PATH"];
            _fePath = configuration["AppSettings:FEPATH"];
        }
        
        //[Authorize(Roles = "Manager")]
        [Route("Danh-sach-tui-xach")]
        public List<TuiXach> GetTuis()
        {
            return _Tuixach.getdatatuixach();
        }
        [HttpPost("Xoa-San-Pham-Tui-Xach")]
        public IActionResult delTui([FromBody] int id)
        {
            try
            {
                _Tuixach.delTui(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost("Sua-San-Pham-Tui-Xach")]
        public IActionResult updateTui([FromBody] TuiXach tuiXach)
        {
            try
            {
                _Tuixach.UpdateTui(tuiXach.MaTuiXach.ToString(), tuiXach.MaLoaiTuiXach.ToString(), tuiXach.TenTuiXach, tuiXach.Gia.ToString(), tuiXach.MoTa, tuiXach.HinhAnh);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Route("Get-Row-total-tui-records")]
        public List<int> getPageNumber()
        {
            List<int> li = new List<int>();
            if (_Tuixach.getdatatuixach().Count > 0)
            {
                int a = 0;
                if ((_Tuixach.getdatatuixach().Count % 8) == 0)
                {
                    a = _Tuixach.getdatatuixach().Count / 8;
                }
                else
                {
                    a = (_Tuixach.getdatatuixach().Count / 8) + 1;
                }
                //int a = (_Tuixach.getdatatuixach().Count / 8) + 1;
                for (int i = 1; i <= a; i++)
                {
                    li.Add(i);
                }
            }
            else if (li.Count == 0)
            {
                li.Add(1);
            }
            return li;
        }
        [Route("Tui-page/{pageIndex}")]
        public List<TuiXach> paginate(int pageIndex)
        {
            return _Tuixach.tuipaginate(pageIndex);
        }

        [Route("Search-Tui-Paginate/{pageIndex}/{key}")]
        public List<TuiXach> SearchTuiPaginate(int pageIndex, string key)
        {
            return _Tuixach.SearchTuiPaginate(pageIndex, key);
        }


        //lấy ra số trang sau khi tìm kiếm 
        [Route("Search-Record-count/{key}")]
        public List<int> Search_Record_count(string key)
        {
            List<int> li = new List<int>();
            if (_Tuixach.countSearchin4(key).Count > 0)
            {
                int a = 0;
                if ((_Tuixach.countSearchin4(key).Count % 8) == 0)
                {
                    a = _Tuixach.countSearchin4(key).Count / 8;
                }
                else
                {
                    a = (_Tuixach.countSearchin4(key).Count / 8) + 1;
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

        [HttpPost("Them-San-Pham")]
        public IActionResult AddTui([FromBody] TuiXach tuiXach)
        {
            try
            {
                _Tuixach.addTui(tuiXach.MaLoaiTuiXach.ToString(), tuiXach.TenTuiXach, tuiXach.Gia.ToString(), tuiXach.MoTa, tuiXach.HinhAnh);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost("upload")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"{file.FileName}";
                    var fullPath = CreatePathFile(filePath);
                    var fullFEPath = CreateFEPathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    using (var fileStream1 = new FileStream(fullFEPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream1);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [NonAction]
        private string CreatePathFile(string RelativePathFileName)
        {
            try
            {
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                return fullPathFile;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [NonAction]
        private string CreateFEPathFile(string RelativePathFileName)
        {
            try
            {
                string serverRootPathFolder = _fePath;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                return fullPathFile;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("Get-Tui-by-ID/{id}")]
        public IActionResult GetTuiByID(int id)
        {
            try
            {
                return Ok(_Tuixach.GetTuiByID(id));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Route("getTuiByCateIdPaginate/{index}/{id}")]
        public List<TuiXach> getTuiByCateIdPaginate(int index, int id)
        {
            return _Tuixach.getTuiByCateIdPaginate(index, id);
        }
        [Route("getTuiByCateId_all/{id}")]
        public List<int> getTuiByCateId_all(int id)
        {
            List<int> li = new List<int>();
            if (_Tuixach.getTuiByCateId_all(id).Count > 0)
            {
                int a = 0;
                if ((_Tuixach.getTuiByCateId_all(id).Count % 8) == 0)
                {
                    a = _Tuixach.getTuiByCateId_all(id).Count / 8;
                }
                else
                {
                    a = (_Tuixach.getTuiByCateId_all(id).Count / 8) + 1;
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

        [Route("Get-related-products/{id}")]
        public List<TuiXach> GetRelatedProductsByCateId(int id)
        {
            var listProduct = _Tuixach.getTuiByCateId_all(id);
            return listProduct.Take(3).ToList();
        }
    }
}
