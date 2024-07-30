using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dao_Nguyen_Tuan05
{
    class Cty
    {
        List<NhanVien> lst =new List <NhanVien>();

        public List<NhanVien> Lst
        {
          get { return lst; }
          set { lst = value; }
        }
        public void NhapXML(string file)
        {

            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("/DSNV/NhanVien");
            foreach (XmlNode item in nodeList) {
                string ma = item["Ma"].InnerText;
                string ten = item["Ten"].InnerText;
                int namsinh = int.Parse(item["NamSinh"].InnerText);
                int gioitinh = int.Parse(item["GioiTinh"].InnerText);
                double hsl = double.Parse(item["HSL"].InnerText);
                int namvaolam = int.Parse(item["Nvl"].InnerText);
                int loai = int.Parse(item.Attributes["loai"].Value);
                if (loai == 0)
                {
                    int snn = int.Parse(item["snn"].InnerText);
                    NhanVienSX a =new NhanVienSX(ma, ten, gioitinh, namsinh, hsl, namvaolam, snn);
                    lst.Add(a);
                }
                if (loai == 1)
                {
                    double doanhthu = double.Parse(item["doanhthu"].InnerText);
                    double doanhthutt = double.Parse(item["doanhthuTT"].InnerText);
                    NhanVienKD a = new NhanVienKD(ma, ten, gioitinh, namsinh, hsl, namvaolam, doanhthu, doanhthutt);
                    lst.Add(a);
                }
                if (loai == 2)
                {
                    string chucvu = item["chucvu"].InnerText;
                    double hspc = double.Parse(item["hspc"].InnerText);
                    CanBo a = new CanBo(ma, ten, gioitinh, namsinh, hsl, namvaolam, chucvu, hspc);
                    lst.Add(a);
                }
            }
        }
        public void Xuat()
        {
            foreach (NhanVien a in lst)
            {
                a.Xuat();
            }
        }
        public int slnvsx()
        {
            Console.WriteLine();
            List<NhanVienSX> list1 = lst.OfType<NhanVienSX>().ToList();
            return list1.Count();
            //return  (lst.OfType<NhanVienSX>().ToList()).Count();
            
        }
        public void NVSXTNCN()
        {
            Console.WriteLine();
            
            List<NhanVienSX> list1 = lst.OfType<NhanVienSX>().ToList();
 
            Console.WriteLine("Nhan vien san xuat co thu nhap cao nhat: ");

            double max = list1.Max(t=> t.ThuNhap());
            Console.WriteLine(max);
            foreach (NhanVienSX a in list1)
            {
                if (a.ThuNhap() == max)
                    a.Xuat();
            }
        }
        // tong thu nhap cua nhan vien kinh doanh
        public double TongThuNhapNVKD()
        {
            List<NhanVienKD> ListTemp=lst.OfType<NhanVienKD>().ToList();
            return ListTemp.Sum(t=>t.ThuNhap());
        }
        //Thong ke xep loai toan the nhan vien
        public void ThongkeXepLoai()
        {
            char temp = 'a';
            List<NhanVien> ListTemp = lst.OrderBy(t => t.XepLoai()).ToList();
            foreach (NhanVien x in ListTemp)
            {
                if (temp != x.XepLoai())
                {
                    Console.WriteLine();
                    temp = x.XepLoai();
                    Console.WriteLine("Nhan vien xep loai {0} la: ", temp);
                }
                    x.Xuat();
            }
        }
        public void ThongKeXepLoaiInt()
        {
            Console.WriteLine();
            int slTemp = 0;
            List<NhanVien> ListTemp = lst.OrderBy(t => t.XepLoai()).ToList();
            
             char temp = ListTemp[0].XepLoai();
             foreach(NhanVien x in ListTemp)
             {
                 if (temp == x.XepLoai())
                 {
                     slTemp++;
                 }
                 else
                 {
                     Console.WriteLine("So nhan vien thuoc loai {0} la: {1}",temp,slTemp);
                     temp = x.XepLoai();
                     slTemp = 1;
                 }
             }
             Console.WriteLine("So nhan vien thuoc loai {0} la: {1}", temp, slTemp);
        }
       }

    }

