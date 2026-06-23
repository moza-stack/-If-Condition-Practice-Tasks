using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class MedicalRecord
    {
        public int recordId { get; set; } // System generated
        public int patientId { get; set; }  // system calcualted from appointmentId
        public int doctorId { get; set; }    // system calcualted from appointmentId
        public int appointmentId { get; set; } // user input 
        public string diagnosis { get; set; }  // user input 
        public string prescription { get; set; } // user input 
        public string visitDate { get; set; }    // system calcualted from appointmentId
        public decimal visitFee { get; set; }   // system calcualted from doctorId

    }
}
