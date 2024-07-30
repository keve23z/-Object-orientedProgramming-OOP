using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap02
{
    public class GiaDinhB : HoGiaDinh
    {
        public override double SoNuocPhaiTra()
        {
            return Math.Max(SoKhoiNuocSuDung() - 20, 0);
        }
        public GiaDinhB(string tenChuHo, string diaChi, int soCu, int soMoi)
           : base(tenChuHo, diaChi, soCu, soMoi)
        { }
        public override void Xuat()
        {
            Console.WriteLine();
            Console.WriteLine("Ho B");
            base.Xuat();
        }
    }
}
