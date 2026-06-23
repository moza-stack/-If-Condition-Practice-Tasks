using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.services
{
    public static class StaffService
    {
        //DisplayAllStaff(List<StaffModel void — print staffId, fullName, role, isOnDuty for every staff member
        public static void DisplayAllStaff(List<StaffModel> staff)
        {
            foreach (var e in staff)
            {
                Console.WriteLine($"Staff ID: {e.staffId}, Full Name: {e.fullName}, Role: {e.role}, On Duty: {e.isOnDuty}");
            }
        }

        public static StaffModel FindStaffById(List<StaffModel>staff, string staffId)
   
        {
            foreach (var e in staff)
            {
                if (e.staffId == staffId)
                {
                    return e;
                }
            }

            return null;
        }

        //ToggleDutyStatus(StaffModel) void — if isOnDuty is true set it to false; if false set it to true. Print the new status.

        public static void ToggleDutyStatus(StaffModel staff)
        {
            if (staff.isOnDuty == true)
            {
                staff.isOnDuty = false;
                Console.WriteLine($"staff{staff.fullName}DutyStatus updated to false");
            }
            else
            {
                staff.isOnDuty = true;
                Console.WriteLine($"staff{staff.fullName}DutyStatus updated to true");

            }
        }

    }
}