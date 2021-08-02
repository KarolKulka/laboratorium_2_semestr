using System.Collections.Generic;
using System;
namespace zaliczenie_2_semestr
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BedCount { get; set; }
        public List<string> Amenities { get; set; }
        public double Price { get; set; }
        public int HotelId { get; set; }
        public Display Display { get; set; }
        public Room(string name, int bedCount, string amenities, double price)
        {
            Random rnd = new Random();
            Display = new Display();
            Amenities = new List<string>();

            Name = name;
            BedCount = bedCount;
            foreach (string amenity in amenities.Split(";"))
            {
                Amenities.Add(amenity);
            }
            Price = price;
        }

        public void Print()
        {
            Display.ConsolePrint("Nazwa: " + Name);
            Display.ConsolePrint("Liczba łóżek: " + BedCount);
            Display.ConsolePrint("Cena: " + Price + " zł za noc");
            Display.ConsolePrint("Udogodnienia: ");
            foreach (string amenity in Amenities)
            {
                Display.ConsolePrint("  " + amenity);
            }
            Display.ConsolePrint("-----");
        }

        public void SetHotelId(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}