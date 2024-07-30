using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap01
{
    public class Manager:Staff      // nhan vien quan ly
    {
        string Posision;        //Chuc vu
        double PosisionCoefficient;     //hesochucvu
        public override char Classification()
        {
            return 'A';
        }
        public double PosisionAlowances()       //phu cap chuc vu
        {
            return 1100 * PosisionCoefficient;
        }
        public override double Salary()
        {
            return CoefficientsSalary * Staff.BasicSalary + PosisionAlowances();
        }
        public override void Iuput()
        {
            base.Iuput();
            Console.Write("Nhap chuc vu:");
            Posision=Console.ReadLine();
            Console.Write("Nhap he so chuc vu:");
            PosisionCoefficient=double.Parse(Console.ReadLine());
        }
        public override void Ouput()
        {
            Console.WriteLine("Quan ly");
            base.Ouput();
            Console.WriteLine($"Chuc vu:{Posision} \t He so chuc vu {PosisionCoefficient} \t Phu cap chuc vu:{PosisionAlowances()}");
        }
        public Manager():base() 
        {
            Posision = "Truong phong";
            PosisionCoefficient = 4.5;
        }
        public Manager(string id, string name, int yearOfBirth, string sex, double coefficientsSalary, int yearOfEmloyment, string posision, double posisionCoefficient) : base(id, name, yearOfBirth, sex, coefficientsSalary, yearOfEmloyment)
        {
            Posision = posision;
            PosisionCoefficient = posisionCoefficient;
        }
    }
}
