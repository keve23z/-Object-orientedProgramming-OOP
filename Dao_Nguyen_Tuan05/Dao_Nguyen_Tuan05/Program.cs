using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao_Nguyen_Tuan05
{
    class Program
    {
        static void Main(string[] args)
        {

            Cty list = new Cty();
            list.NhapXML("../../dsNhanVien.xml");
            //list.Xuat();
            Console.WriteLine();
            /*Console.WriteLine("So luong nhan vien san xuat la:{0}", list.slnvsx());
            list.NVSXTNCN();
            Console.WriteLine("Tong thu nhap cua nhan vien kinh doanh la:{0}", list.TongThuNhapNVKD());*/
            list.ThongkeXepLoai();
            list.ThongKeXepLoaiInt();
            Console.ReadKey();
        }
    }
}
