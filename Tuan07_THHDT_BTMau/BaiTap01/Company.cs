using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BaiTap01
{
    public class Company
    {
        string CompanyName;     //TenCongTy
        string Address;         //diachi
        string Establishment;       //ngay thanh lap
        List<Staff> List = new List<Staff>();
        public List<Staff> ListStaff
        {
            get { return List; }
            set { List = value; }
        }
        public void ImportXML(string xml)       //Nhap xml
        {
            XmlDocument read=new XmlDocument();     //doc ds
            read.Load(xml);

            XmlNode node = read.SelectSingleNode("/ListOfEmployee");        //doc phan tu dau
            CompanyName = node["CompanyName"].InnerText;
            Address = node["Address"].InnerText;
            Establishment = node["Establishment"].InnerText;

            XmlNodeList nodeList = read.SelectNodes("/ListOfEmployee/Employee");    //doc ds nhan vien
            foreach(XmlNode item in nodeList)
            {   
                string id = item["Id"].InnerText;                                   //Ma
                string name = item["Name"].InnerText;                               //Ten
                int yearOfBirth = int.Parse(item["YearOfBirth"].InnerText);         //namsinh
                string sex = item["Sex"].InnerText;                                 // gioi tinh
                double coefficientsSalary = double.Parse(item["CoefficientsSalary"].InnerText);             //hesoluong
                int yearOfEmloyment= int.Parse(item["YearOfEmloyment"].InnerText) ;                         //Nam vao lam
                
                string category = item.Attributes["Category"].Value;                 // phan loai nhan vien
                                                                                     
                if (category== "Nhan vien san xuat")                                // nhan vien san xuat
                {
                    int dayOff = int.Parse(item["DayOff"].InnerText);               // ngay nghi
                    ProductionStaff productionStaff = new ProductionStaff(id, name, yearOfBirth, sex, coefficientsSalary, yearOfEmloyment,dayOff);
                    List.Add(productionStaff);
                } 
                else if(category== "Nhan vien kinh doanh")                        // nhan vien kinh doanh
                {
                    double revenue = double.Parse(item["Revenue"].InnerText);                       //doanh thu
                    double minimalRevenue = double.Parse(item["MinimalRevenue"].InnerText);         //doanh thu toi thieu
                    SalesPersons salesPersons = new SalesPersons(id, name, yearOfBirth, sex, coefficientsSalary, yearOfEmloyment, revenue, minimalRevenue);
                    List.Add(salesPersons);
                }
                else if(category== "Nhan vien quan ly")                            //Nhan vien quan ly
                {
                    string posision = item["Posision"].InnerText;                   // chuc vu
                    double posisionCoefficient = double.Parse(item["PosisionCoefficient"].InnerText);           //he so chuc vu
                    Manager manager = new Manager(id, name, yearOfBirth, sex, coefficientsSalary, yearOfEmloyment, posision, posisionCoefficient);
                    List.Add(manager);
                }
            }
        }
        public void ExportXML()     //Xuatxml
        {
            Console.WriteLine($"Ten cong ty:{CompanyName} \t Dia chi:{Address} \t Ngay thanh lap:{Establishment}");
            Console.WriteLine("Nhan sach nhan vien trong cong ty la:");
            Console.WriteLine();
            foreach(Staff staff in List)
            {
                staff.Ouput();
                Console.WriteLine();
            }
        }
        public List<Staff> ListIncreasesWithSalary()        // Tang dan theo luong
        {
                return List.OrderBy(t=>t.Salary()).ToList();
        }
        public List<Staff> ListDescendesWithSalary()        // Giam dan theo luong
        {
            return List.OrderByDescending(t=>t.Salary()).ToList();
        }
        public List<ProductionStaff> ListProductionStaff()    //Lay danh sach nhan vien san xuat
        {

            return List.OfType<ProductionStaff>().ToList();
        }
        public void OuputHighestIncomePerson()          // Xuat nguoi co thu nhap cao nhat
        {
            Console.WriteLine("Nguoi co thu nhap cao nhat: ");
            double HighestIncome = List.Max(t => t.Income());
            foreach(Staff staff in List)
            {
                if (staff.Income() == HighestIncome)
                {
                    staff.Ouput();
                }
            }
        }

        public void OuputLowestIncomePerson()          // Xuat nguoi co thu nhap thap nhat
        {
            Console.WriteLine("Nguoi co thu nhap thap nhat: ");
            double HighestIncome = List.Min(t => t.Income());
            foreach (Staff staff in List)
            {
                if (staff.Income() == HighestIncome)
                {
                    staff.Ouput();
                }
            }
        }
    }
}
