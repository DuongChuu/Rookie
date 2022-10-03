using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Program
    {
        static void Main(string[] agrs)
        {
            List<Sinhvien> Sinhviens = new List<Sinhvien> {
                new Sinhvien( "Duong","Chu", "Male",new DateTime(2000,01,11),"094962311","HaNoi",false ),
                new Sinhvien( "Duong","Huong", "Female",new DateTime(2001,12,11),"094962311","HaiDuong",true ),
                new Sinhvien( "Pham","ThieuAnh", "Female",new DateTime(2003,09,11),"094962311","BacGiang",false ),
                new Sinhvien( "Trinh","HoangAnh", "Male",new DateTime(2004,08,09),"094962311","HaiPhong",false ),
                new Sinhvien( "Nguyen","Hung", "Male",new DateTime(1999,01,01),"094962311","Hanoi",true )
            };
            //Case1
            Console.WriteLine("Case 1:");

            var result = from Sinhvien in Sinhviens
                         where Sinhvien.gender == "Male"
                         select Sinhvien;

            foreach (var sinhvien in result) sinhvien.showinfo();

            Console.WriteLine("----------------------------------------------------------------");
            //Case 2
            Console.WriteLine("Case 2:");

            var result0 = from Sinhvien in Sinhviens
                          orderby Sinhvien.age descending
                          select Sinhvien;

            foreach (var sinhvien in result0)
            {
                Console.WriteLine(sinhvien.age);
                break;
            }

            Console.WriteLine("----------------------------------------------------------------");

            //Case 3
            Console.WriteLine("Case 3:");

            var result5 = from Sinhvien in Sinhviens
                          select Sinhvien.firstname + " " + Sinhvien.lastname;

            foreach (var sinhvien in result5)
            {
                Console.WriteLine(sinhvien);
            }
            Console.WriteLine("----------------------------------------------------------------");
            //Case 4
            Console.WriteLine("Case 4:");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    var result1 = from Sinhvien in Sinhviens
                                  where Sinhvien.DOB.Year == 2000
                                  select Sinhvien;
                    foreach (var sinhvien in result1) sinhvien.showinfo();
                    break;
                case 2:
                    var result2 = from Sinhvien in Sinhviens
                                  where Sinhvien.DOB.Year > 2000
                                  select Sinhvien;
                    foreach (var sinhvien in result2) sinhvien.showinfo();
                    break;
                case 3:
                    var result3 = from Sinhvien in Sinhviens
                                  where Sinhvien.DOB.Year < 2000
                                  select Sinhvien;
                    foreach (var sinhvien in result3) sinhvien.showinfo();
                    break;
            }
            Console.WriteLine("----------------------------------------------------------------");

            //Case 5
            Console.WriteLine("Case 5:");

            var result4 = from Sinhvien in Sinhviens
                          where Sinhvien.place.ToUpper() == "HANOI"
                          select Sinhvien;
                          
            foreach (var sinhvien in result4)
            {
                sinhvien.showinfo(); break;
            }

        }
    }
}

