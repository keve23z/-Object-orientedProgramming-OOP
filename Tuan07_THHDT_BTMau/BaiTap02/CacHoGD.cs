using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BaiTap02
{
    internal class CacHoGD
    {
        string Tencc;
        string ngaythanhlap;
        string diachi;
        List<HoGiaDinh> hoGiaDinh=new List<HoGiaDinh>();
        public List<HoGiaDinh> list
        {
            get { return hoGiaDinh; }
            set { hoGiaDinh = value;}
        }
        public void NhapXML(string file)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(file);
            XmlNode node = xmlDocument.SelectSingleNode("/DSCC");
            Tencc = node["tencc"].InnerText;
            ngaythanhlap = node["ngaythanhla"].InnerText;
            diachi = node["diachi"].InnerText;
            XmlNodeList nodeList = xmlDocument.SelectNodes("/DSCC/giadinh");
            foreach(XmlNode xml in nodeList)
            {
                string Ten = xml["ten"].InnerText;
                string dicchi= xml["diachi"].InnerText;
                int sc = int.Parse(xml["socu"].InnerText);
                int sm = int.Parse(xml["somoi"].InnerText);
                string loai = xml.Attributes["loai"].InnerText;
                if (loai == "A"|| loai == "C")
                {
                    int NhanKhau = int.Parse(xml["nhakhau"].InnerText);
                    if (loai == "A") {
                        GiaDinhA giaDinhA = new GiaDinhA(Ten, dicchi, sc, sm,NhanKhau);
                        hoGiaDinh.Add(giaDinhA);
                    }
                    else
                    {
                        GiaDinhC giaDinhC = new GiaDinhC(Ten, dicchi, sc, sm, NhanKhau);
                        hoGiaDinh.Add(giaDinhC);
                    }
                }
                if (loai == "B")
                {
                    GiaDinhB giaDinhB = new GiaDinhB(Ten, dicchi, sc, sm);
                    hoGiaDinh.Add(giaDinhB);
                }

            }
        }
        public void Xuat()
        {
            Console.WriteLine("TenChungCu:{0}", Tencc);
            Console.WriteLine("Diachi:{0}", diachi);
            Console.WriteLine("NgayThanhLap:{0}", ngaythanhlap);
            foreach( HoGiaDinh ho in hoGiaDinh )
            {
                ho.Xuat();
            }
        }
    }
}
