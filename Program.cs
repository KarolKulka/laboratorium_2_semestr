using System.Collections.Generic;
using System;

namespace zaliczenie_2_semestr
{
    class Program
    {
        protected Display Display {get; set;}
        protected List<Hotel> Hotels = new List<Hotel>();
        protected List<Room> Rooms = new List<Room>();
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
            firstHotel.Room = new Room("pierwszy pokój", 2, "wi-fi;balkon", 12.31);
            firstHotel.Room = new Room("drugi pokój", 5, "wi-fi;balkon;wanna", 50);
            firstHotel.Room = new Room("trzeci pokój", 1, "wi-fi;taras", 43.7);
            PrepareRooms(firstHotel);
            firstHotel.Print();
            Hotels.Add(firstHotel);
            Hotel secondHotel = new Hotel("Hotel drugi", 5, "Opis drugiego hotelu", new Address("Jagiellońska", "2", "89-423", "Grudziądz"), "contact@drugi.pl");
            secondHotel.Room = new Room("pierwszy pokój", 3, "balkon", 76);
            secondHotel.Room = new Room("drugi pokój", 1, "wi-fi;wanna", 65.12);
            secondHotel.Room = new Room("trzeci pokój", 4, "wi-fi;sauna", 31);
            PrepareRooms(secondHotel);
            Hotels.Add(secondHotel);
            Hotel thirdHotel = new Hotel("Hotel trzeci", 1, "Opis trzeciego hotelu", new Address("Warszawska", "12A", "81-713", "Toruń"), "contact@trzeci.pl");
            thirdHotel.Room = new Room("pierwszy pokój", 1, "jacuzzi", 76);
            thirdHotel.Room = new Room("drugi pokój", 1, "wi-fi;taras", 61);
            thirdHotel.Room = new Room("trzeci pokój", 2, "sauna", 25);
            PrepareRooms(thirdHotel);
            Hotels.Add(thirdHotel);
        }

        protected void PrepareRooms(Hotel hotel)
        {
            foreach (Room room in hotel.Rooms){
                Rooms.Add(room);
            }
        }
    }
}
