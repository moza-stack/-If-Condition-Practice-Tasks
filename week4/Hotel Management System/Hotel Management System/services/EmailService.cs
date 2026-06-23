using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.services
{
    public static class EmailService
    {
        public static string SystemEmail = "hms@grandcodeline.om";

        public static void SendEmail(string to, string subject, string body)
        {
            //Simulate sending an email
            Console.WriteLine($"Sending email From: {SystemEmail}");
            Console.WriteLine($"Sending email To: {to}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
            Console.WriteLine("Email sent successfully");
        }
    }
}
