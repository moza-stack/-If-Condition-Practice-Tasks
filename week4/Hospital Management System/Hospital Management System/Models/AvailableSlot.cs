using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class AvailableSlot
    {
        public int slotId { get; set; }  //system generated
        public int doctorId { get; set; }   // user input choosen from list of doctors
        public string slotDate { get; set; }  //user input optional vaule 
        public string slotTime { get; set; }  //user input optional vaule
        public bool isBooked { get; set; }    //default value = false
    
}
}
