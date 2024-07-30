using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap02
{
    public abstract class HoGiaDinh
    {
        public string TenChuHo;
        public string DiaChi;
        int soCu;
        public int SoCu
        {
            get => soCu;
            set
            {
                soCu = value;
                if (soCu < 0)
                    soCu = 0;
            }
        }
        int soMoi;
        public int SoMoi { get => soMoi;
            set { soMoi = value;
                if (soMoi < SoCu)
                    soMoi = SoCu;
            }
        }
        public int SoKhoiNuocSuDung()
        {
            return SoMoi-SoCu;
        }
        public abstract double SoNuocPhaiTra();

        public double TienNuoc()
        {
            return SoNuocPhaiTra() * 8000;
        }
        public HoGiaDinh(string tenChuHo, string diaChi, int soCu, int soMoi)
        {
            TenChuHo = tenChuHo;
            DiaChi = diaChi;
            SoCu = soCu;
            SoMoi = soMoi;
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Chu ho:{0} \t Diachi:{1} \t So cu:{2}-So moi{3} \t So nuoc da dung:{4}", TenChuHo, DiaChi, SoCu, soMoi, SoKhoiNuocSuDung());
            Console.WriteLine("So tien tra:{0}",SoNuocPhaiTra());
        }
    }
}
