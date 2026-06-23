using Hotel_Management_System.Models;
using Hotel_Management_System.services;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics.Metrics;


namespace Hotel_Management_System
{
    public class Program
    {
        public static void RegisterGuest(HotelContext context)
        {
            Console.Write("Enter Guest ID: ");
            string guestId =Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter PhoneNumber: ");
            string phoneNumbe = Console.ReadLine();
            GuestModel guest = new GuestModel
            {
                guestId = guestId,
                fullName= fullName,
                email = email,
                phoneNumber= phoneNumbe

            };
            context.guests.Add(guest);
            EmailService.SendEmail(email, "Welcome to Grand Codeline Hotel", "Thank you for registering. We look forward to hosting you!");
        }

        // ========= ROOMS =============

        public static void AddRoom(HotelContext context)
        {
            Console.Write("Enter Room Number: ");
            string roomnumber = Console.ReadLine();

            Console.Write("Enter Room Type: ");
            string roomtype = Console.ReadLine();
            Console.Write("Enter Price Per Night: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Floor: ");
            int floor = Convert.ToInt32(Console.ReadLine());



            RoomModel room = new RoomModel
            {
                roomNumber = roomnumber,
                roomType = roomtype,
                pricePerNight= price,
                floor=floor
            };

            context.rooms.Add(room);

            Console.WriteLine("Room added successfully");
        }


        //DisplayAvailableRoom

        public static void DisplayAvailableRooms(HotelContext context)
        {
           
            if (context.rooms.Count == 0)
            {
                Console.WriteLine("No rooms in system.");
                return;
            }

            RoomService.DisplayAvailableRooms(context.rooms);
        }





        // ============== AddStaff ================

        public static void AddStaff(HotelContext context)
        {
            Console.Write("Enter Staff ID: ");
            string staffid = Console.ReadLine();

            Console.Write("Enter Full Name: ");
            string fullname = Console.ReadLine();

            Console.Write("Enter Role: ");
            string role = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            StaffModel staff = new StaffModel
            {
                staffId = staffid,
                fullName =fullname,
                role = role,
                email = email,
                isOnDuty = true
            };

            context.staff.Add(staff);

            Console.WriteLine("Staff added successfully");
        }

        //==========DisplayAllStaff=======

        public static void DisplayAllStaff(HotelContext context)
        {
            foreach (var s in context.staff)
            {
                Console.WriteLine($"ID: {s.staffId}");
                Console.WriteLine($"FullName: {s.fullName}");
                Console.WriteLine($"Role: {s.role}");
                Console.WriteLine($"Email: {s.email}");
                Console.WriteLine($"On Duty: {s.isOnDuty}");

            }
        }
        //=====BookRoom=====
        public static void BookRoom(HotelContext context)
        {
            Console.Write("Enter Guest ID: ");
            string guestId = Console.ReadLine();

            Console.Write("Enter Room Number: ");
            string roomNumber = Console.ReadLine();

            GuestModel guest = GuestService.FindGuestById(context.guests, guestId);
            if (guest == null)
            {
                Console.WriteLine("Guest not found");
                return;
            }

            RoomModel room = RoomService.FindRoomByNumber(context.rooms, roomNumber);
            if (room == null)
            {
                Console.WriteLine("Room not found");
                return;
            }

            if (!room.isAvailable)
            {
                Console.WriteLine("Room not available");
                return;
            }

            Console.Write("Enter Check In Date: ");
            string checkIn= Console.ReadLine();

            Console.Write("Enter Check Out Date: ");
            string checkOut = Console.ReadLine();


            Console.Write("Enter Number Of Nights: ");
            int nights=Convert.ToInt32(Console.ReadLine());

            double totalPrice =
                RoomService.CalculateTotalPrice(room, nights);

            Console.Write("Enter Booking ID: ");
            string bookingId = Console.ReadLine();

            BookingModel booking = new BookingModel
            {
                bookingId = bookingId,
                guestId = guestId,
                roomNumber = roomNumber,
                checkInDate = checkIn,
                checkOutDate = checkOut,
                totalPrice = totalPrice,
                status = "Confirmed",
                bookingReviews = new List<ReviewModel>()
            };

            context.bookings.Add(booking);

            room.isAvailable = false;

            guest.guestBookings.Add(booking);

            EmailService.SendEmail(
                guest.email,
                "Booking Confirmed",
                $"Your booking for room {roomNumber} has been confirmed. Total: {totalPrice} OMR"
            );

            Console.WriteLine("Booking created successfully.");
        }

        //=========CancelBooking===========
        public static void CancelBooking(HotelContext context)
        {
            Console.Write("Enter Booking ID: ");
            string bookingId = Console.ReadLine();

           
            BookingModel booking = BookingService.FindBookingById(context.bookings, bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            
            bool cancelled = BookingService.CancelBooking(booking);

            if (!cancelled)
            {
                Console.WriteLine("Booking already cancelled.");
                return;
            }

           
            RoomModel room = RoomService.FindRoomByNumber(context.rooms, booking.roomNumber);

            if (room != null)
            {
                room.isAvailable = true;
            }

          
            GuestModel guest = GuestService.FindGuestById(context.guests, booking.guestId);

            if (guest != null)
            {
                EmailService.SendEmail(
                    guest.email,
                    "Booking Cancelled",
                    $"Your booking {booking.bookingId} has been cancelled."
                );
            }

            Console.WriteLine("Booking cancelled successfully.");
        }

        //====AddReviewToBooking====

       
        public static void AddReviewToBooking(HotelContext c)
        {
            Console.WriteLine("Enter Booking ID:");
            string bookingId = Console.ReadLine();

            var booking = BookingService.FindBookingById(c.bookings, bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            if (booking.status != "Completed")
            {
                Console.WriteLine("Reviews can only be added to completed bookings.");
                return;
            }

            Console.WriteLine("Enter Review ID:");
            string reviewId = Console.ReadLine();

            Console.WriteLine("Enter Rating (1-5):");
            int rating = Convert.ToInt32(Console.ReadLine());

            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Rating must be between 1 and 5.");
                return;
            }

            Console.WriteLine("Enter Comment:");
            string comment = Console.ReadLine();

            ReviewModel review = new ReviewModel
            {
                reviewId = reviewId,
                bookingId = bookingId,
                rating = rating,
                comment = comment
            };

            ReviewService.AddReview(booking, review);

            c.reviews.Add(review);

            var guest = GuestService.FindGuestById(c.guests, booking.guestId);

            if (guest != null)
            {
                EmailService.SendEmail(
                    guest.email,
                    "Thank You for Your Review",
                    $"We appreciate your feedback! Rating: {rating}/5");
            }

            Console.WriteLine("Review added successfully.");
        }


        //======ToggleStaffDuty=====
        public static void ToggleStaffDuty(HotelContext context)
        {
            Console.Write("Enter Staff ID: ");
            string staffId = Console.ReadLine();

            StaffModel staff = StaffService.FindStaffById(context.staff, staffId);

            if (staff == null)
            {
                Console.WriteLine("Staff member not found.");
                return;
            }

            StaffService.ToggleDutyStatus(staff);

            Console.WriteLine("Staff duty status updated successfully.");
        }

        //=====DisplayGuestBookingHistor=====
        public static void DisplayGuestBookingHistory(HotelContext context)
        {
            Console.Write("Enter Guest ID: ");
            string guestId = Console.ReadLine();

            GuestModel guest = GuestService.FindGuestById(context.guests, guestId);

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            foreach (var booking in guest.guestBookings)
            {
                Console.WriteLine($"Booking ID: {booking.bookingId}");
                Console.WriteLine($"Room Number: {booking.roomNumber}");
                Console.WriteLine($"Status: {booking.status}");
                Console.WriteLine($"Total Price: {booking.totalPrice}");


                if (guest.guestBookings == null || guest.guestBookings.Count == 0)
                {
                    Console.WriteLine("No booking history for this guest.");
                    return;
                }

            }
        }

        //=====CompleteBooking=======
        public static void CompleteBooking(HotelContext context)
        {
            Console.Write("Enter Booking ID: ");
            string bookingId = Console.ReadLine();

            // 2Find booking
            BookingModel booking = BookingService.FindBookingById(context.bookings, bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            // 3Find associated room
            RoomModel room = RoomService.FindRoomByNumber(context.rooms, booking.roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            //4 Complete booking
            bool completed = BookingService.CompleteBooking(booking, room);

            if (!completed)
            {
                Console.WriteLine("Only confirmed bookings can be completed.");
                return;
            }

            //5 Find guest
            GuestModel guest = GuestService.FindGuestById(context.guests, booking.guestId);

            if (guest != null)
            {
                EmailService.SendEmail(
                    guest.email,
                    "Stay Completed — Share Your Experience",
                    "Your stay at Grand Codeline Hotel is complete. Please leave a review!"
                );
            }

            Console.WriteLine("Booking completed successfully.");
        }

        //=====DisplayRoomReviewSummary==========
        public static void DisplayRoomReviewSummary(HotelContext context)
        {
            Console.Write("Enter Room Number: ");
            string roomNumber = Console.ReadLine();

            RoomModel room = RoomService.FindRoomByNumber(context.rooms, roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            int totalReviews = 0;
            int totalRating = 0;

            foreach (BookingModel booking in context.bookings)
            {
                if (booking.roomNumber == roomNumber)
                {
                    foreach (ReviewModel review in booking.bookingReviews)
                    {
                        totalReviews++;
                        totalRating += review.rating;
                    }
                }
            }

            if (totalReviews == 0)
            {
                Console.WriteLine("No reviews for this room.");
                return;
            }

            double avg = (double)totalRating / totalReviews;

            Console.WriteLine("Total Reviews: " + totalReviews);
            Console.WriteLine("Average: " + avg.ToString("F2"));

            Console.WriteLine("Reviews:");

            foreach (BookingModel booking in context.bookings)
            {
                if (booking.roomNumber == roomNumber)
                {
                    foreach (ReviewModel review in booking.bookingReviews)
                    {
                        Console.WriteLine($"Rating: {review.rating}, Comment: {review.comment}");
                        
                    }
                }
            }
        }

        //===== FullGuestProfile=========
        public static void FullGuestProfile(HotelContext context)
        {
            Console.Write("Enter Guest ID: ");
            string guestId = Console.ReadLine();

            GuestModel guest = GuestService.FindGuestById(context.guests, guestId);

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            Console.WriteLine("===== Guest Profile =====");
            Console.WriteLine($"Full Name: {guest.fullName}, Email: {guest.email}, Phone Number: {guest.phoneNumber},");
            Console.WriteLine($"Email: {guest.email}");
            Console.WriteLine($"Phone Number: {guest.phoneNumber}");
           

            Console.WriteLine($"Total Bookings: {guest.guestBookings.Count}");

            int completedStays = 0;

            foreach (BookingModel booking in guest.guestBookings)
            {

                
                Console.WriteLine($"Booking ID: {booking.bookingId}");
                Console.WriteLine($"Room Number: {booking.roomNumber}");
                Console.WriteLine($"Status: {booking.status}");
                Console.WriteLine($"Total Price: {booking.totalPrice}");
                Console.WriteLine($"Reviews Count: {booking.bookingReviews.Count}");

                if (booking.status == "Completed")
                {
                    completedStays++;
                }
            }

            Console.WriteLine($"Completed stays: {completedStays}");
        }



       
        static void Main(string[] args)
        {
            HotelContext context = new HotelContext();
            context.bookings = new List<BookingModel>();
            context.guests = new List<GuestModel>();
            context.reviews = new List<ReviewModel>();
            context.rooms = new List<RoomModel>();
            context.staff = new List<StaffModel>();
           
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Welcome to the Hotel system");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. RegisterGuest");
                Console.WriteLine("2. AddRoom");
                Console.WriteLine("3. DisplayAvailableRooms");
                Console.WriteLine("4. BookRoom");
                Console.WriteLine("5. CancelBooking");
                Console.WriteLine("6. CompleteBooking");
                Console.WriteLine("7. AddReviewToBooking");
                Console.WriteLine("8. DisplayGuestBookingHistory");
                Console.WriteLine("9.DisplayRoomReviewSummary");
                Console.WriteLine("10. FullGuestProfile");
                Console.WriteLine("11.AddStaff ");
                Console.WriteLine("12.DisplayAllStaff");
                Console.WriteLine("13.ToggleStaffDuty");
                Console.WriteLine("0. Exit");
                

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        RegisterGuest(context);
                        break;

                    case 2:
                        AddRoom(context);


                        break;

                    case 3:
                        DisplayAvailableRooms(context);


                        break;

                    case 4:
                        BookRoom(context);



                        break;

                    case 5:
                        CancelBooking(context);

                        break;

                    case 6:
                        CompleteBooking(context);

                        break;
                    case 7:
                        AddReviewToBooking(context);

                        break;

                    case 8:
                        DisplayGuestBookingHistory(context);

                        break;

                    case 9:
                        DisplayRoomReviewSummary(context);



                        break;
                    case 10:
                        FullGuestProfile(context);



                        break;

                    case 11:
                        AddStaff(context);

                        break;

                    case 12:
                        DisplayAllStaff(context);

                        break;
                    case 13:
                        ToggleStaffDuty(context);

                        break;
                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}

 
