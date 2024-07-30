using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap01
{
    abstract public class Staff
    {
        string id;
        public string Name;
        public string Id
        {
            get { return id; }
            set { id = value;
                if (!(id.Length == 5 && id.StartsWith("NV") == true && id.Substring(2).All(char.IsDigit) == true))
                    id = "NV001";
            }
        }
        public int YearOfBirth;
         string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                if (sex != "male" && sex != "female")
                    sex = "male";
            }
        }
        public double CoefficientsSalary;   //hesoluong
        int yearofemloyment;
        public int YearOfEmloyment      //namvaolam
        {
            get { return yearofemloyment; }
            set
            {
                yearofemloyment = value;
                if (yearofemloyment > DateTime.Today.Year)
                    yearofemloyment = DateTime.Today.Year;
            }
        }
        protected static int BasicSalary = 1150;  //luongcoban
        public double SeniorityAllowances()     //phucapthamnien
        {
            return (DateTime.Today.Year - YearOfEmloyment)*BasicSalary/100;
        }
        public double Income()  //thunhap
        {
            char C= Classification();
            double EmulationCoefficient = 0;//hesothidua
            if (C == 'A')
                EmulationCoefficient = 1.0;
            if (C == 'B')
                EmulationCoefficient = 0.75;
            if (C == 'C')
                EmulationCoefficient = 0.5;
            return EmulationCoefficient*Salary()+SeniorityAllowances();
        }
        abstract public double Salary();    //luong
        abstract public char Classification();     //xeploai
        public Staff()
        {
            Id = "NV001";
            Name = "Dao";
            YearOfBirth = 2004;
            Sex = "female";
            CoefficientsSalary = 2.3;
            YearOfEmloyment = 2010;
        }
        public Staff(string id, string name, int yearOfBirth, string sex, double coefficientsSalary, int yearOfEmloyment)
        {
            Id = id;
            Name = name;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            CoefficientsSalary = coefficientsSalary;
            YearOfEmloyment = yearOfEmloyment;
        }
        public virtual void Iuput()
        {
            Console.Write("Nhap ma:");
            Id=Console.ReadLine();
            Console.Write("Nhap ten:");
            Name=Console.ReadLine();
            Console.Write("Nhap nam sinh:");
            YearOfBirth=int.Parse(Console.ReadLine());
            Console.Write("Nhap gioi tinh (male/female):");
            Sex=Console.ReadLine();
            Console.Write("Nhap he so luong:");
            CoefficientsSalary=double.Parse(Console.ReadLine());
            Console.Write("Nhap nam vao lam:");
            YearOfEmloyment=int.Parse(Console.ReadLine());
        }
        public virtual void Ouput()
        {
            Console.WriteLine($"Ma:{Id} \t Ten:{Name} \t Nam sinh:{YearOfBirth} \t Gioi tinh:{Sex} \t He So Luong:{CoefficientsSalary}");
            Console.WriteLine($"Xep loai:{Classification()} \t Thu Nhap:{Income()} \t\t Luong:{Salary()}");
        }
    }
}
