using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Sinhvien
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string place { get; set; }
        public string phone { get; set; }
        public int age
        {
            get
            {
                return DateTime.Now.Year - DOB.Year;
            }
        }
        public DateTime DOB { get; set; }
        public bool isgraduated;
        public Sinhvien(string fname, string lname, string gt, DateTime BOB, string number, string birthplace, bool graduated)
        {
            firstname = fname;
            lastname = lname;
            gender = gt;
            DOB = BOB;
            phone = number;
            place = birthplace;
            isgraduated = graduated;
        }
        public void showinfo()
        {
            Console.WriteLine(firstname + " " + lastname + "," + gender + "," + DOB + "," + phone + " " + place + "," + isgraduated);
        }
    }
}

