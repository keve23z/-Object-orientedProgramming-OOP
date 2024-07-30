using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao_Nguyen_Tuan05
{
    class NhanVienSX:NhanVien
    {
        int snn;
        static double hsPhuCapNangNhoc = 0.1;
        public override char XepLoai()
        {
            if (snn <= 1) return 'A';
            if (snn <= 3) return 'B';
            if (snn <= 5) return 'C';
            return 'D';
        }
        public override double TinhLuong()
        {
            return Hsl * NhanVien.LuongCoBan * (1 + NhanVienSX.hsPhuCapNangNhoc);
        }
        public NhanVienSX():base()
        {
            snn = 10;
        }
        public NhanVienSX(string m, string t, int n, int nam, double hsl, int nvl, int nn)
            : base(m, t, n, nam, hsl, nvl)
        {
            snn = nn;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so ngay nghi:");
            snn = int.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            Console.WriteLine();
            Console.WriteLine("NhanvienSX");
            base.Xuat();
            Console.WriteLine("So ngay nghi {0}",snn);
        }
    }
}
