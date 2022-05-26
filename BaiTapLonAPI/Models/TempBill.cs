using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Models
{
    public class TempBill
    {
        public TempBill()
        {
            ten = "";
            email = "";
            phone = "";
            address = "";
            pass = "";
            note = "";
            tongsoluong = 0;
            products = null;
            //cart = new CartModel();
        }
        string ten;
        string email;
        string phone;
        string address;
        string pass;
        string note;
        double tongtien;
        //CartModel cart;
        double tongsoluong;
        List<SaleProduct> products;

        public string Ten { get ; set; }
        public string Email { get; set; }
        public string Phone { get; set ; }
        public string Address { get ; set ; }
        public string Pass { get; set ; }
        public string Note { get ; set ; }
        //public CartModel Cart { get => cart; set => cart = value; }
        public double Tongtien { get ; set; }
        public List<SaleProduct> Products { get ; set ; }
        public double Tongsoluong { get ; set ; }
    }
}
