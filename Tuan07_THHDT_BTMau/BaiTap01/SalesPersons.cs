using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap01
{
    public class SalesPersons:Staff     // nhan vien kinh doanh
    {
        double Revenue;     // doanh thu
        double MinimalRevenue;  // doanh thu toi thieu
        public override char Classification()
        {
            if (Revenue<0.5*MinimalRevenue)
                return 'D';
            if (Revenue<MinimalRevenue)
                return 'C';
            if (Revenue<2*MinimalRevenue)
                return 'B';
            return 'A';
        }
        public override double Salary()
        {
            return CoefficientsSalary * Staff.BasicSalary + Commission();
        }
        public double Commission()  // tienhoahong
        {
            double ExceedRevenue = Revenue - MinimalRevenue;
            if (ExceedRevenue > 0) return ExceedRevenue * 0.15;
            return 0;
        }
        public override void Iuput()
        {
            base.Iuput();
            Console.Write("Nhap doanh thu da dat duoc:");
            Revenue=double.Parse(Console.ReadLine());
            Console.Write("Nhap doanh thu toi thieu: ");
            MinimalRevenue=double.Parse(Console.ReadLine());
        }
        public override void Ouput()
        {
            Console.WriteLine("Kinh doanh");
            base.Ouput();
            Console.WriteLine($"Doanh thu:{Revenue} \t Doanh thu toi thieu:{MinimalRevenue} \t Tien hoa hong:{Commission()}");
        }
        public SalesPersons() : base() {
            Revenue = 2000;
            MinimalRevenue = 2500;
        }
        public SalesPersons(string id, string name, int yearOfBirth, string sex, double coefficientsSalary, int yearOfEmloyment, double revenue, double minimalRevenue) : base(id, name, yearOfBirth, sex, coefficientsSalary, yearOfEmloyment)
        {
            Revenue = revenue;
            MinimalRevenue = minimalRevenue;
        }
    }
}
