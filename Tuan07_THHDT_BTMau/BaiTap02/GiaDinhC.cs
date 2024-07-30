using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap02
{
    public class GiaDinhC:HoGiaDinh
    {
        int SoNhanKhau;
        public override double SoNuocPhaiTra()
        {
            return Math.Max(SoKhoiNuocSuDung() - 10 * SoNhanKhau, 0);
        }
        public GiaDinhC(string tenChuHo, string diaChi, int soCu, int soMoi, int soNhanKhau)
           : base(tenChuHo, diaChi, soCu, soMoi)
        {
            SoNhanKhau = soNhanKhau;
        }
        public override void Xuat()
        {
            Console.WriteLine();
            Console.WriteLine("Ho C");
            Console.WriteLine("So nhan khau:{0}", SoNhanKhau);
            base.Xuat();
        }
    }
}
