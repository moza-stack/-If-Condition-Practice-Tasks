using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
        public int patientId { get; set; }   // System generated
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientGender { get; set; }
        public  string patientPhone { get; set; }
        public string patientEmail { get; set; }
        public string patientBloodType { get; set; }



        //public Patient(int id, string name, int age,
        //       string gender, string email,
        //       string phone, string bloodType)
        //{
        //    patientId = id;
        //    patientName = name;
        //    patientAge = age;
        //    patientGender = gender;
        //    patientEmail = email;
        //    patientPhone = phone;
        //    patientBloodType = bloodType;
        //}

        //public override string ToString() =>
        //    $"[{patientId}] {patientName,-10} | {patientAge,-8} | {patientGender,-8} | {patientPhone,-9}| {patientEmail,-6} | {patientBloodType,-8} ";

        //public void convertDataToString()
        //{
        //    Console.WriteLine($"{patientId} | {patientName,-10} | {patientAge,-8} | {patientGender,-8} | {patientPhone,-9} | {patientEmail,-6} | {patientBloodType, -8}");
        //}


    }
}
