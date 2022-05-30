using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Models
{
    public class CartModel
    {
        List<SaleProduct> products;
        int Tongsoluong;
        double TongTien;

        public List<SaleProduct> Products { get => products; set => products = value; }
        public int Tongsoluong1 { get => Tongsoluong; set => Tongsoluong = value; }
        public double TongTien1 { get => TongTien; set => TongTien = value; }
    }
}
