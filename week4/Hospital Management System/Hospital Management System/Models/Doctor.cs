using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        public int doctorId { get; set; } //system generated
        public string doctorName { get; set; }
        public string doctorSpecialization { get; set; }
        public string doctorPhone { get; set; }
        public string doctorEmail { get; set; }
        public decimal consultationFee { get; set; }

        //public Doctor(int id, string name,
        //              string specialization,
        //              string email,
        //              string phone,
        //              decimal fee)
        //    {
        //        doctorId = id;
        //        doctorName = name;
        //        doctorSpecialization = specialization;
        //        doctorEmail = email;
        //        doctorPhone = phone;
        //        consultationFee = fee;
        //    }

        //    public override string ToString() =>
        //        $"[{doctorId}] {doctorName,-10} | {doctorSpecialization,-15} | {doctorEmail,-10} | {doctorPhone,-20} | {consultationFee,-8}";

        //    public void convertDataToString()
        //    {
        //        Console.WriteLine(
        //            $"{doctorId} | {doctorName,-10} | {doctorSpecialization,-15} | {doctorEmail,-10} | {doctorPhone,-20} | {consultationFee,-8}"
        //        );
        //    }
    }
}
