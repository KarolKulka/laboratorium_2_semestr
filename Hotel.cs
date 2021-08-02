using System.Collections.Generic;
using System;
namespace zaliczenie_2_semestr
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public Display Display { get; set; }
        protected List<Room> Rooms = new List<Room>();
        public Hotel(string name, int stars, string description, Address address, string email)
        {
            Random rnd = new Random();
            Display = new Display();

            Id = rnd.Next(100, 1000);
            Name = name;
            Stars = stars;
            Description = description;
            Address = address;
            Email = email;
        }

        public void Print()
        {
            Display.ConsolePrint("ID: " + Id);
            Display.ConsolePrint("NAZWA: " + Name);
            Display.ConsolePrint("GWIAZDKI: " + Stars);
            Display.ConsolePrint("OPIS: \n" + Description);
            Address.Print();
            Display.ConsolePrint("E-MAIL: " + Email);
            Display.ConsolePrint("----");
            Display.ConsolePrint("Pokoje: ");
            foreach (Room room in Rooms)
            {
                room.Print();
            }
        }

        public void AddRoom(Room room)
        {
            room.SetHotelId(Id);
            Rooms.Add(room);
        }
    }
}