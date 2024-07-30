using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.ImportXML("../../ListOfEmployee.xml");
            //company.ExportXML();

           /* Console.WriteLine("Danh sach Tang dan theo luong:");
            List<Staff> ListIncreases = company.ListIncreasesWithSalary();
            foreach (Staff staff in ListIncreases)
            {
                staff.Ouput();
            }*/

            /*Console.WriteLine("Danh sach Giam dan theo luong:");
            List<Staff> ListDescendes = company.ListDescendesWithSalary();
            foreach (Staff staff in ListDescendes)
            {
                staff.Ouput();
            }*/

            //List<ProductionStaff> listProductionStaff = company.ListProductionStaff();
            //Console.WriteLine("Nhan vien san xuat la:");
            //foreach (ProductionStaff productionStaff in listProductionStaff)
            //    productionStaff.Ouput();

            company.OuputHighestIncomePerson();
                Console.ReadKey();
        }
    }
}
