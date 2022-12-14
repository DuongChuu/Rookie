using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
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

            for (int i = 0; i < SinhViens.Count; i++)
            {
                if (SinhViens[i].Gender == "Male")
                {
                    SinhViens[i].ShowInfo();
                }
            }

            Console.WriteLine("----------------------------------------------------------------");
            //Case 2
            int max = 0;

            foreach (var sinhvien in SinhViens)
            {
                if (max < sinhvien.Age)
                {
                    max = sinhvien.Age;
                }
            }

            foreach (var sinhvien in SinhViens)
            {
                if (sinhvien.Age == max)
                {
                    sinhvien.ShowInfo();
                    break;
                }
            }
            Console.WriteLine("----------------------------------------------------------------");

            //Case 3

            for (int i = 0; i < SinhViens.Count; i++)
            {
                Console.WriteLine(SinhViens[i].Fullname);
            }

            //Case 4
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    for (int i = 0; i < SinhViens.Count; i++)
                    {
                        if (SinhViens[i].DOB.Year == 2000) SinhViens[i].ShowInfo();
                    }
                    break;
                case 2:
                    for (int i = 0; i < SinhViens.Count; i++)
                    {
                        if (SinhViens[i].DOB.Year > 2000) SinhViens[i].ShowInfo();
                    }
                    break;
                case 3:
                    for (int i = 0; i < SinhViens.Count; i++)
                    {
                        if (SinhViens[i].DOB.Year < 2000) SinhViens[i].ShowInfo();
                    }
                    break;
            }
            Console.WriteLine("----------------------------------------------------------------");

            //Case 5
            for (int i = 0; i < SinhViens.Count; i++)
            {
                if (SinhViens[i].Place.ToUpper() == "HANOI")
                {
                    SinhViens[i].ShowInfo();
                    break;
                }
            }
        }
    }
}

