using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap02
{
    public class GiaDinhA:HoGiaDinh
    {
        int SoNhanKhau;
        public override double SoNuocPhaiTra()
        {
            return Math.Max(SoKhoiNuocSuDung() - 5 * SoNhanKhau, 0);
        }
        public GiaDinhA(string tenChuHo, string diaChi, int soCu, int soMoi, int soNhanKhau)
           : base(tenChuHo, diaChi, soCu, soMoi)
        {
            SoNhanKhau = soNhanKhau;
        }
        public override void Xuat()
        {
            Console.WriteLine();
            Console.WriteLine("Ho A");
            Console.WriteLine("So nhan khau:{0}", SoNhanKhau);
            base.Xuat();
        }
    }
}
