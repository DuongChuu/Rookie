using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Sinhvien
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Place { get; set; }
        public string Phone { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DOB.Year;
            }
        }
        public DateTime DOB { get; set; }
        public bool Isgraduated { get; set; }
        public Sinhvien(string fname, string lname, string gt, DateTime dob, string number, string birthplace, bool graduated)
        {
            Firstname = fname;
            Lastname = lname;
            Gender = gt;
            DOB = dob;
            Phone = number;
            Place = birthplace;
            Isgraduated = graduated;
        }
        public void ShowInfo()
        {
            Console.WriteLine(Firstname + " " + Lastname + "," + Gender + "," + DOB + "," + Phone + " " + Place + "," + Isgraduated);
        }
    }
}

