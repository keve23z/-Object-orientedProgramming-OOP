using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dao_Nguyen_Tuan05
{
    public abstract class NhanVien
    {
        string ma, ten;
        int gt;

        
        int nvl, ns;
        double hsl;
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        bool gioitinh;
        public bool Gioitinh
        {
            get
            {
                return gioitinh;
            }
            set
            {
                if (gt == 1)
                    gioitinh= true;   
                else
                    gioitinh =false;
                gioitinh = value;

            }
        }
        public String TenGT
        {
            get
            {
                if (Gioitinh == true)
                    return "Nu";
                return "Nam";
            }
        }


        public int Ns
        {
            get { return ns; }
            set { ns = value; }
        }

        public int Nvl
        {
            get { return nvl; }
            set { nvl = value; }
        }
       

        public double Hsl
        {
            get { return hsl; }
            set { hsl = value; }
        }
        protected static double LuongCoBan = 1150;
        public double PhuCapThamNien()
        {
            int tn = DateTime.Today.Year - Nvl;
            if (tn >= 5)
                return tn * NhanVien.LuongCoBan / 100;
            return 0;
        }
        public double ThuNhap()
        {
            char xl = XepLoai();
            double hsThidua = 0;
            if (xl == 'A') hsThidua = 1.0;
            if (xl == 'B') hsThidua = 0.75;
            if (xl == 'C') hsThidua = 0.5;
            return hsThidua * TinhLuong() + PhuCapThamNien();
        }
        abstract public char XepLoai();
        abstract public double TinhLuong();
        public virtual void Nhap()
        {
            Console.Write("Nhap ma:");
            ma = Console.ReadLine();
            Console.Write("Nhap ten:");
            ten = Console.ReadLine();
            Console.WriteLine("1.Nu - 0.Nam");
            Console.Write("Nhap gioi tinh:");
            gt=int.Parse(Console.ReadLine());
            Console.Write("Nhap nam sinh:");
            Ns = int.Parse(Console.ReadLine());
            Console.Write("Nhap he so luong:");
            Hsl = double.Parse(Console.ReadLine());
            Console.Write("Nhap nam vao lam:");
            Nvl = int.Parse(Console.ReadLine());
        }
        public virtual void Xuat()
        {
            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", Ma, Ten, TenGT, Ns, Hsl, Nvl);
            Console.WriteLine("{0} - {1} - Thu Nhap{2}", XepLoai(), TinhLuong(),ThuNhap());
        }
        public NhanVien(string m, string t, int n, int nam, double hsl, int nvl)
        {
            ma = m;
            ten = t;
            gt = n;
            Ns = nam;
            Hsl = hsl;
            Nvl = nvl;
        }
        public NhanVien()
        {
            Ma = "2020";
            Ten = "dao";
            gt = 1;
            Ns = 1231;
            Hsl = 0.25;
            Nvl = 1232;
        }

    }
}
