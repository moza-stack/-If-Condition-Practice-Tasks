using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.services
{
 
        public static class ReviewService
        {
            public static void AddReview(
                BookingModel booking,
                ReviewModel review)
            {
                booking.bookingReviews.Add(review);
            }

            public static void DisplayReviewsForBooking(
                BookingModel booking)
            {
                if (booking.bookingReviews.Count == 0)
                {
                    Console.WriteLine("No reviews yet.");
                    return;
                }

            foreach (var review in booking.bookingReviews)
            {
                Console.WriteLine($"Rating: {review.rating}, Comment: {review.comment}");
            

        }
            }
        }
    }

    

