using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronPdf;
using DoAnTotNghiep.BLL;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillToPDF : Controller
    {
        IChiTietDonHangBLL _chiTietDonHangBLL;
        IDonHangBLL _donHangBLL;
        ITuiXachBLL _Tuixach;
        public BillToPDF(IChiTietDonHangBLL chiTietDonHangBLL, IDonHangBLL donHangBLL, ITuiXachBLL Tuixach)
        {
            _chiTietDonHangBLL = chiTietDonHangBLL;
            _donHangBLL = donHangBLL;
            _Tuixach = Tuixach;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("PDF-Export/{id}")]
        public IActionResult PDFExport(string id)
        {
            try
            {
                List<ChiTietDonHang> li = new List<ChiTietDonHang>();
                li = _chiTietDonHangBLL.GetAllChiTietDonByID(int.Parse(id));
                DonHang bill = new DonHang();
                List<DonHang> listBill = _donHangBLL.getAllDonHang();
                for (int i = 0; i < listBill.Count; i++)
                {
                    if (listBill[i].MaDonHang == int.Parse(id))
                    {
                        bill = listBill[i];
                        break;
                    }
                }
                var pdfForm = "<meta http-equiv=\"Content - Type\" content=\"text / html\"; charset=\"utf - 8\">" +
      @"<style>

         *{ font - family: DejaVu Sans !important; }
#Head{
                font - family: 'Oswald', sans - serif!important;
            }
</style>
<div>" +
    "<p style = \"text-align: justify;\" > Kính gửi " + bill.tenKhachHang + ",</p>" +

    "<p style = \"text-align: justify;\" > Công ty chúng tôi gửi đến quý khách hàng lá thư này nhằm xác nhận về việc đặt hàng" +
        "của quý khách hàng vào ngày" + bill.NgayDatHang + ".</p>" +


      "<p style = \"text-align: justify;\" > Trong trường hợp không nhận được thông báo nào về việc thay đổi hoặc huỷ bỏ đơn hàng" +
               @"trong vòng mười ngày (10) kể từ ngày quý khách hàng nhận được lá thư này, chúng tôi sẽ tiến hành giao hàng mà
        quý khách hàng đã đặt vào ngày đã nêu.</p>

    <p> &nbsp;</p>
   

       <p> &nbsp;</p>
      

          <p> &nbsp;</p>" +



             "<table border = \"0\" cellpadding = \"0\" cellspacing = \"0\" role = \"presentation\" width = \"100%\">" + @"
                  
                          <tbody>
                  
                              <tr>" +

               "<td style = \"padding:40px 30px;background:#ffffff;border-radius:8px\" bgcolor = \"#ffffff\" valign = \"top\">" +

                                           "<table width = \"100%\" border = \"0\" cellpadding = \"0\" cellspacing = \"0\" role = \"presentation\">"

                                                        + @"<tbody>
                                
                                                            <tr>" +

                                                                "<td style = \"font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:30px;line-height:46px;letter-spacing:-0.6px;color:#151515;padding:0 10px\"" +
                                    "valign = \"top\" align = \"center\">" + @"
  
                                      <strong> Thông Tin Hóa Đơn </strong>
     
                                     </td>
                                 </tr>
     
                                 <tr>"

                                     + "<td height = \"15\" style = \"line-height:1px;font-size:1px\"> &nbsp;" + @"
                                </td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr>" +
                                "<td style = \"font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:15px;line-height:30px;letter-spacing:-0.2px;color:#363333;padding:0 10px\"" +
                                    "valign = \"top\" >" + @"
                                    Xin chào , <strong> Flat Shop </strong> đã nhận được đặt hàng của bạn.
                                    <strong > Flat Shop </strong> sẽ thông báo cho bạn khi đơn hàng được
                                    gửi đi.
                                </td>
                            </tr>
                            <tr>" +
                                "<td height = \"25\" style = \"line-height:1px;font-size:1px\" > &nbsp;" + @"
                                </td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr>" +
                                "<td style = \"font-family:'Fira Sans';font-size:20px;line-height:30px;letter-spacing:-0.2px;color:#201f1f;padding:0 10px\"" +
                                    "valign = \"top\" >" + @"
                                    Thông tin đơn hàng
                                </td>
                            </tr>
                            <tr>" +
                                "<td style = \"font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:15px;line-height:30px;letter-spacing:-0.2px;color:#363333;padding:0 10px\"" +
                                    "valign = \"top\">" +
                                    "Mã đơn hàng: " + bill.MaDonHang + "</td></tr><tr>" +
                                "<td style = \"font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:15px;line-height:30px;letter-spacing:-0.2px;color:#363333;padding:0 10px\"" +
                                    "valign = \"top\" >" +
                                    "Tên khách hàng: " + bill.tenKhachHang + @"
                                </td>
                            </tr>
                            <tr>" +
                                "<td style = \"font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:15px;line-height:30px;letter-spacing:-0.2px;color:#363333;padding:0 10px\"" +
                                    "valign = \"top\">" +
                                    "Số điện thoại :" + bill.SoDienThoai + @"
                                </td>
                            </tr>
                            <tr>" +
                                "<td style = \"font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:15px;line-height:30px;letter-spacing:-0.2px;color:#363333;padding:0 10px\"" +
                                    "valign = \"top\" >" +
                                    "Địa chỉ giao hàng: " + bill.DiaChiGiaoHang + @"
                                </td>
                            </tr>
                            <tr>" +
                                "<td style = \"font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:15px;line-height:30px;letter-spacing:-0.2px;color:#363333;padding:0 10px\"" +
                                    "valign = \"top\" >" +
                                    "Ngày đặt hàng :" + bill.NgayDatHang + @"
                                </td>
                            </tr>
                        </tbody>

                        <tbody>
                            <tr>" +
                                "<td height = \"25\" style = \"line-height:1px;font-size:1px\" > &nbsp;" + @"
                                </td>
                            </tr>
                            <tr>" +
                                "<td style = \"padding:0 10px\" valign = \"top\" >" +

                                       "<table border = \"0\" cellpadding = \"0\" cellspacing = \"0\" role = \"presentation\" width = \"100%\" >" + @"
            
                                                    <tbody>
            
                                                        <tr>" +
                                                            "<th style = \"letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:16px;padding:10px 10px 10px 0;border-bottom:1px solid #e5e5e5;width:40px;color:#151515\"" +
                                                    "align = \"center\" >" + @"
                                                    STT
                                                </th>" +
                                                "<th style = \"letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:16px;padding:10px 10px 10px 0;border-bottom:1px solid #e5e5e5;width:100px;color:#151515\"" +
                                                    "align = \"center\">" + @"
                                                    Tên sản phẩm
                                                </th>" +
                                                "<th style = \"letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:16px;border-bottom:1px solid #e5e5e5;padding:10px 0;width:56px;color:#151515\"" +
                                                    "align = \"center\" >" + @"
                                                    Số lượng
                                                </th>" +
                                                "<th style = \"letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:16px;border-bottom:1px solid #e5e5e5;padding:10px 0;width:56px;color:#151515\"" +
                                                    "align = \"center\" >" + @"
                                                    Giá
                                                </th>"
                                                + "<th style = \"letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:16px;border-bottom:1px solid #e5e5e5;padding:10px 0;width:56px;color:#151515\"" +
                                                    "align = \"center\" >" + @"
                                                    Tổng
                                                </th>
                                            </tr>
                                            <tr>" +
                                                "<td colspan = \"3\" height = \"0\" style = \"font-size:1px;line-height:1px\" >" + @"
                                                         &nbsp;</td>
     
                                                 </tr>
     
                                             </tbody>
     
                                             <tbody>";

                for (int i = 0; i < li.Count; i++)
                {
                    TuiXach bag = _Tuixach.GetTuiByID(int.Parse(li[i].MaTuiXach.ToString()));
                    pdfForm += @"<tr>" +

                          "<td style = \"padding:20px 10px 20px 0;font-size:16px;letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;border-bottom:1px solid #e5e5e5\"" +
                        "valign = \"top\" align = \"center\" >" + 
  
                                                          li[i].MaCtdonHang +"</td>" +

                       "<td style = \"padding:20px 10px 20px 0;font-size:16px;letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;border-bottom:1px solid #e5e5e5\"" +
                        "valign = \"top\" align = \"center\" >" +
                        bag.TenTuiXach +
                        @"<br>
                                                    </td>" +
                    "<td style = \"padding:20px 10px 20px 0;font-size:16px;letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;border-bottom:1px solid #e5e5e5\"" +
                        "valign = \"top\" align = \"center\" >" +
                        li[i].SoLuong + @"
                                                    </td>" +
                    "<td style = \"padding:20px 10px 20px 0;font-size:16px;letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;border-bottom:1px solid #e5e5e5\"" +
                        "valign = \"top\" align = \"center\" >" +
                        bag.Gia + "VNĐ" + @"
            </td>" +

"<td style = \"padding:20px 10px 20px 0;font-size:16px;letter-spacing:-0.2px;line-height:26px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;border-bottom:1px solid #e5e5e5\"" +
                        "valign = \"top\" align = \"center\" >" +
                        li[i].SoLuong*li[i].DonGia + "VNĐ" + @"
            </td>

        </tr>";
                }

 pdfForm+= @"</tbody>

</table>

</td>

</tr>

</tbody>

<tbody>

<tr>"+
"<td style = \"float:right;font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:15px;line-height:30px;letter-spacing:-0.2px;color:#080808;padding:0 10px\""+
                                    "valign = \"top\" >"+
                                    "Tổng hóa đơn: "+ bill.TongTien + "Đ"+@"
</td>

</tr>

</tbody>

</table>

</td>

</tr>

</tbody>

</table>"+


"<p style = \"text-align: justify;\" > Trân trọng cảm ơn quý khách,</p>"+

    
   


       "<p style = \"text-align: justify;\" > VŨ MINH HIẾU</p>"+
       

           "<p style = \"text-align: justify;\" > Chức vụ: QUẢN LÝ</p>"+
           

               "<p style = \"text-align: justify;\"> Số điện thoại liên hệ : 0339286032 </p>"+
                

                    "<p style = \"text-align: justify;\" > Email liên hệ : vuminhhieu444 @gmail.com </p>"+
                      

                          @"<p> &nbsp;</ p >
                         

                             <p> &nbsp;</p>
                            

                                <p> &nbsp;</p>
                               

                                   <p> &nbsp;</p>
                                  

                                      <p> &nbsp;</p>
                                     </div>

                                     ";

                var Renderer = new IronPdf.ChromePdfRenderer();
                Renderer.RenderHtmlAsPdf(pdfForm).SaveAs("pixel-perfect.pdf");

                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
