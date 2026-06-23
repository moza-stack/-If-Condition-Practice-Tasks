using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.Models
{
    public class RoomModel
    {
        public string roomNumber {  get; set; }
        public string roomType {  get; set; }
        public double pricePerNight {  get; set; }
        public bool isAvailable = true;
        public int floor {  get; set; }
    }
}
