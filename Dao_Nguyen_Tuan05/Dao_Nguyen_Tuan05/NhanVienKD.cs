using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao_Nguyen_Tuan05
{
    class NhanVienKD:NhanVien
    {
        double doanhthuTT, doanhthu;
        public override char XepLoai()
        {
            if (doanhthu < 0.5 * doanhthuTT)
                return 'D';
            if (doanhthu < doanhthuTT)
                return 'C';
            if (doanhthu < 2* doanhthuTT)
                return 'B';
            return 'A';
        }
        public override double TinhLuong()
        {
            return Hsl * NhanVien.LuongCoBan + HoaHong();
        }
        public double HoaHong()
        {
            char xl = XepLoai();
            double vuot = doanhthu - doanhthuTT;
            if (vuot > 0)
                return 0.15 * vuot;
            return 0;
        }
        public NhanVienKD()
            : base()
        {
            doanhthu = 1500000;
            doanhthuTT = 1500000;
        }
        public NhanVienKD(string m, string t, int n, int nam, double hsl, int nvl, double dt, double dttt)
            : base(m, t, n, nam, hsl, nvl)
        {
            doanhthu = dt;
            doanhthuTT = dttt;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap doanh thu:");
            doanhthu = double.Parse(Console.ReadLine());
            Console.Write("Nhap doanh thu TT:");
            doanhthuTT = double.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            Console.WriteLine();
            Console.WriteLine("Nhanvienkd");
            base.Xuat();
            Console.WriteLine("{0} - {1} - {2}", doanhthu, doanhthuTT, HoaHong());
        }
    }
}
