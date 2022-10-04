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
            List<Sinhvien> SinhViens = new List<Sinhvien> {
                new Sinhvien( "Duong","Chu", "Male",new DateTime(2000,01,11),"094962311","HaNoi",false ),
                new Sinhvien( "Duong","Huong", "Female",new DateTime(2001,12,11),"094962311","HaiDuong",true ),
                new Sinhvien( "Pham","ThieuAnh", "Female",new DateTime(2003,09,11),"094962311","BacGiang",false ),
                new Sinhvien( "Trinh","HoangAnh", "Male",new DateTime(2004,08,09),"094962311","HaiPhong",false ),
                new Sinhvien( "Nguyen","Hung", "Male",new DateTime(1999,01,01),"094962311","Hanoi",true )
            };
            //Case1
            Console.WriteLine("Case 1:");

            var Listmembers = SinhViens.Where(m => m.Gender == "Male");

            if (Listmembers.Any())
            {
                foreach (var sinhvien in Listmembers) sinhvien.ShowInfo();
            }

            Console.WriteLine("----------------------------------------------------------------");
            //Case 2
            Console.WriteLine("Case 2:");

            var result = SinhViens.Max(m => m.Age);
            var maxAge = SinhViens.Find(m => m.Age == result);

            if (maxAge != null)
            {
                maxAge.ShowInfo();
            }

            Console.WriteLine("----------------------------------------------------------------");

            //Case 3
            Console.WriteLine("Case 3:");

            foreach (var sinhvien in SinhViens)
            {
                Console.WriteLine(sinhvien.Fullname);
            }
            Console.WriteLine("----------------------------------------------------------------");
            //Case 4
            Console.WriteLine("Case 4:");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    var member2000 = SinhViens.Where(m => m.Age == 2000);
                    if (member2000.Any())
                    {
                        foreach (var sinhvien in member2000) sinhvien.ShowInfo();
                    }
                    break;
                case 2:
                    var membergreater2000 = SinhViens.Where(m => m.Age > 2000);
                    if (membergreater2000.Any())
                    {
                        foreach (var sinhvien in membergreater2000) sinhvien.ShowInfo();
                    }
                    break;
                case 3:
                    var memberless2000 = SinhViens.Where(m => m.Age < 2000);
                    if (memberless2000.Any())
                    {
                        foreach (var sinhvien in memberless2000) sinhvien.ShowInfo();
                    }
                    break;
            }
            Console.WriteLine("----------------------------------------------------------------");

            //Case 5
            Console.WriteLine("Case 5:");

            var borninhanoi = (from Sinhvien in SinhViens
                               where Sinhvien.Place.ToUpper() == "HANOI"
                               select Sinhvien).FirstOrDefault();
            if (borninhanoi != null)
            {
                borninhanoi.ShowInfo();
            }
        }
    }
}

