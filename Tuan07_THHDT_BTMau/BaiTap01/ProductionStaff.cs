using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap01
{
    public class ProductionStaff:Staff      // Nhan vien san xuat
    {
        int DayOff;     //ngaynghi
        public static double ToxicAllowance=0.1;
        public override char Classification()
        {
            if (DayOff <= 1) 
                return 'A';
            if (DayOff <= 3)
                return 'B';
            if (DayOff <= 5)
                return 'C';
            return 'D';
        }
        public override double Salary()
        {
            return CoefficientsSalary * BasicSalary * (1 + ToxicAllowance);
        }
        public override void Iuput()
        {
            base.Iuput();
            Console.Write("Nhap so ngay nghi:");
            DayOff=int.Parse(Console.ReadLine());
        }
        public override void Ouput()
        {
            Console.WriteLine("San xuat");
            base.Ouput();
            Console.WriteLine("So ngay nghi:{0}", DayOff);
        }
        public ProductionStaff():base()
        {
            DayOff = 1;
        }
        public ProductionStaff(string id, string name, int yearOfBirth, string sex, double coefficientsSalary, int yearOfEmloyment, int dayoff) : base(id,name, yearOfBirth, sex, coefficientsSalary, yearOfEmloyment)
        {
            DayOff=dayoff;
        }

    }
}
