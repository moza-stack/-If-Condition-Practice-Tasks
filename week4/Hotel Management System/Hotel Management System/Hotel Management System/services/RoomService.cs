using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.services
{
    public static class RoomService
    {


        public static void DisplayAllRooms(List<RoomModel> rooms)
        {
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room Number: {room.roomNumber}, Room Type: {room.roomType}, Price Per Night: {room.pricePerNight}, Available: {room.isAvailable}");
            }
        }
        

        public static void DisplayAvailableRooms(List<RoomModel> rooms)
        {
            foreach (var room in rooms)
            {
                if (room.isAvailable == true)
                {
                    Console.WriteLine("Room Number: " + room.roomNumber);
                    Console.WriteLine("Room Type: " + room.roomType);
                    Console.WriteLine("Price Per Night: " + room.pricePerNight);

                    
                }
            }
        }

        public static RoomModel FindRoomByNumber(
            List<RoomModel> rooms,
            string roomNumber)
        {
            foreach (var room in rooms)
            {
                if (room.roomNumber == roomNumber)
                {
                    return room;
                }
            }

            return null;
        }

        public static double CalculateTotalPrice(
            RoomModel room,
            int nights)
        {
            return room.pricePerNight * nights;
        }
    }
}