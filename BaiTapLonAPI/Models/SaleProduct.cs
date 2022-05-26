using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Models
{
    public class SaleProduct
    {
        int maSanPham;
        TuiXach tui;
        int soluong;
        double dongia;
        public SaleProduct()
        {
            this.soluong = 0;
        }

        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public TuiXach Tui { get => tui; set => tui = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public double Dongia { get => dongia; set => dongia = value; }
    }
}
