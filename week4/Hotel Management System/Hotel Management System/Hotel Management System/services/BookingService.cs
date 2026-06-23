using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.services
{
    
        public static class BookingService
        {
        public static void DisplayAllBookings(List<BookingModel> bookings)
        {
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.bookingId}, Guest ID: {booking.guestId}, Room Number: {booking.roomNumber}, Check In: {booking.checkInDate}, Check Out: {booking.checkOutDate}, Total Price: {booking.totalPrice}, Status: {booking.status}");
            }
        }

        public static BookingModel FindBookingById(
                List<BookingModel> bookings,
                string bookingId)
            {
                foreach (var booking in bookings)
                {
                    if (booking.bookingId == bookingId)
                    {
                        return booking;
                    }
                }

                return null;
            }

            public static bool CancelBooking(BookingModel booking)
            {
                if (booking.status == "Cancelled")
                {
                    return false;
                }

                booking.status = "Cancelled";

                return true;
            }

            public static bool CompleteBooking(
                BookingModel booking,
                RoomModel room)
            {
                if (booking.status != "Confirmed")
                {
                    return false;
                }

                booking.status = "Completed";

                room.isAvailable = true;

                return true;
            }
        }
    }

