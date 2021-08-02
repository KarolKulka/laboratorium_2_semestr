using System.Collections.Generic;
using System;

namespace zaliczenie_2_semestr
{
    class Program
    {
        protected Display Display {get; set;}
        protected List<Hotel> Hotels = new List<Hotel>();
        protected List<Reservation> Reservations = new List<Reservation>();
        protected List<Seller> Sellers = new List<Seller>();
        protected List<Client> Clients = new List<Client>();
        static void Main(string[] args)
        {
            Program programInstance = new Program();

            programInstance.PrepareData();

        }

        protected void PrepareData()
        {
            Display = new Display();
            PrepareHotels();
        }
        protected void PrepareHotels()
        {
            Hotel firstHotel = new Hotel("Hotel pierwszy", 3, "Opis pierwszego hotelu", new Address("Szubińska", "12A", "85-123", "Bydgoszcz"), "contact@pierwszy.pl");
            firstHotel.AddRoom(new Room("pierwszy pokój", 2, "wi-fi;balkon", 12.31));
            firstHotel.AddRoom(new Room("drugi pokój", 5, "wi-fi;balkon;wanna", 50));
            firstHotel.AddRoom(new Room("trzeci pokój", 1, "wi-fi;taras", 43.7));
            firstHotel.Print();
            Hotels.Add(firstHotel);
            Hotel secondHotel = new Hotel("Hotel drugi", 5, "Opis drugiego hotelu", new Address("Jagiellońska", "2", "89-423", "Grudziądz"), "contact@drugi.pl");
            Hotels.Add(secondHotel);
            Hotel thirdHotel = new Hotel("Hotel trzeci", 1, "Opis trzeciego hotelu", new Address("Warszawska", "12A", "81-713", "Toruń"), "contact@trzeci.pl");
            Hotels.Add(thirdHotel);
        }
    }
}
