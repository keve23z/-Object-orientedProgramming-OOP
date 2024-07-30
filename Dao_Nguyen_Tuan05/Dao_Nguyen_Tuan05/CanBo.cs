using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao_Nguyen_Tuan05
{
    public class CanBo:NhanVien
    {
        string chucvu;
        double hspcCV;
        public override char XepLoai()
        {
            return 'A';
        }
        public double PhuCapCV()
        {
            return 1100 * hspcCV;
        }
        public override double TinhLuong()
        {
            return Hsl * NhanVien.LuongCoBan + PhuCapCV();
        }
        public CanBo()
            : base()
        {
            chucvu = "truongPhong";
            hspcCV = 0.5;
        }
        public CanBo(string m, string t, int n, int nam, double hsl, int nvl, string cv, double hs)
            : base(m, t, n, nam, hsl, nvl)
        {
            chucvu = cv;
            hspcCV = hs;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap chuc vu:");
            chucvu = Console.ReadLine();
            Console.Write("Nhap hesophucap: ");
            hspcCV = double.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            Console.WriteLine();
            Console.WriteLine("CanBo");
            base.Xuat();
            Console.WriteLine("{0} - {1}", chucvu,hspcCV);
        }
    }
}
