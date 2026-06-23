using Hotel_Management_System.Models;

namespace Hotel_Management_System
{
    public class HotelContext
    {
        public List<RoomModel> rooms { get; set; }=new List<RoomModel>();
        public List<GuestModel> guests { get; set; }= new List<GuestModel>();
        public List<BookingModel> bookings { get; set; } = new List<BookingModel>();
        public List<ReviewModel> reviews { get; set; } = new List<ReviewModel>();
        public List<StaffModel> staff { get; set; } = new List<StaffModel>();


        
      }
    }


