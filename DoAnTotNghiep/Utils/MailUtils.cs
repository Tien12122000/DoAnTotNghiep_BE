using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Ultils
{
    public class MailUtils
    {
        public static async Task<bool> SendMail(string _from, string _to, string _subject, string _body, SmtpClient client)
        {
            // Tạo nội dung Email
            MailMessage message = new MailMessage(
                from: _from,
                to: _to,
                subject: _subject,
                body: _body
            );
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);


            try
            {
                await client.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //public static async Task<bool> SendMailLocalSmtp(string _from, string _to, string _subject, string _body)
        //{
        //    using (SmtpClient client = new SmtpClient("localhost"))
        //    {
        //        return await SendMail(_from, _to, _subject, _body, client);
        //    }
        //}
        public static async Task<bool> SendMailGoogleSmtp(string _to)
        {

            //MailMessage message = new MailMessage(
            //    from: "quanlyflatshop@gmail.com",
            //    to: _to,
            //    subject: "Đặt hàng FlatShop",
            //    body: "Đặt hàng thành công"
            //);
            //message.BodyEncoding = System.Text.Encoding.UTF8;
            //message.SubjectEncoding = System.Text.Encoding.UTF8;
            //message.IsBodyHtml = true;
            //message.ReplyToList.Add(new MailAddress("quanlyflatshop@gmail.com"));
            //message.Sender = new MailAddress("quanlyflatshop@gmail.com");

            // Tạo SmtpClient kết nối đến smtp.gmail.com
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("quanlyflatshop@gmail.com", "QuanLyFlatShop123");
                client.EnableSsl = true;
                return await SendMail("quanlyflatshop@gmail.com", _to, "Đặt hàng FlatShop", "<h1>Đặt hàng thành công</h1> <br/><h2>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi</h2>", client);
            }

        }
    }
}
