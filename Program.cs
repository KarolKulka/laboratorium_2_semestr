using System.Collections.Generic;
using System.Threading;
using System;
using System.Reflection;

namespace zaliczenie_2_semestr
{
    class Program
    {
        protected Display Display { get; set; }
        protected List<Hotel> Hotels = new List<Hotel>();
        protected List<Room> Rooms = new List<Room>();
        protected List<Reservation> Reservations = new List<Reservation>();
        protected List<Seller> Sellers = new List<Seller>();
        protected List<Client> Clients = new List<Client>();
        IDictionary<string, string> notifications = new Dictionary<string, string>() {
            { "default", "Nieznany klucz powiadomienia." },
            { "defaultExit", "Do widzenia :)" },
            { "menuHeader", "Witaj w systemie obsługi Hoteli. Wybierz jedną z poniższych opcji." },
            { "menuPos1", "1. Wyświetl wszystkie pokoje dwuosobowe wybranego hotelu." },
            { "menuPos2", "2. Wyświetl rezerwacje wybranego sprzedawcy." },
            { "menuPos3", "3. Wyświetl rezerwacje sprzedane w ciągu ostatnich 30 dni." },
            { "menuPos4", "4. Wyświetl wszystkie rezerwacje wybranego hotelu, które rozpoczynają lub kończą się w przyszłym tygodniu." },
            { "menuPos5", "5. Wyświetl ranking najlepszych sprzedawców z wybranego miesiąca." },
            { "menuPos6", "6. Wyświetl wszystkich klientów ze statusem „VIP”, którzy wybierają się do Krakowa." },
            { "chooseMenuOption", "Wybierz pozycję z menu 1 - " },
            { "errorMenuOptionInt", "Podaj poprawny numer pozycji z menu." },
        };
        IDictionary<int, string> menuActions = new Dictionary<int, string>()
        {
            { 1, "ShowHotelDoubleRooms" },
            { 2, "ShowSellerReservations" },
            { 3, "ShowReservationsSoldInLastThirtyDays" },
            { 4, "ShowHotelReservationsBeginingOrEndingInNextWeek" },
            { 5, "ShowBestSellersFromGivenMonth" },
            { 6, "ShowAllClientsWithVipStatus" },
            { 8, "ExitProgram" },
        };
        protected int lastChoosenMenuOption = 0;
        static void Main(string[] args)
        {
            Program programInstance = new Program();

            programInstance.PrepareData();
            programInstance.DisplayMenu();

            Console.ReadKey();
        }
        public void DisplayMenu()
        {
            Console.Clear();
            Notify("menuHeader");
            int i;
            for (i = 1; i <= 6; i++)
            {
                Notify("menuPos" + i);
            }

            Notify(NotificationContent("chooseMenuOption") + --i, true, true);
            string userMenuChoose = Console.ReadLine();
            int menuOption;
            while (!int.TryParse(userMenuChoose, out menuOption) || menuOption < 1 || menuOption > i)
            {
                Notify("errorMenuOptionInt");
                Notify(NotificationContent("chooseMenuOption") + i, true, true);
                userMenuChoose = Console.ReadLine();
            }
            lastChoosenMenuOption = menuOption;
            DynamicMethodCall();

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
            firstHotel.Room = new Room("czwarty pokój", 2, "wi-fi;taras;telewizor", 44);
            firstHotel.Room = new Room("piąty pokój", 3, "wi-fi;taras;lodówka", 49);
            PrepareRooms(firstHotel);
            Hotels.Add(firstHotel);
            Hotel secondHotel = new Hotel("Hotel drugi", 5, "Opis drugiego hotelu", new Address("Jagiellońska", "2", "89-423", "Grudziądz"), "contact@drugi.pl");
            secondHotel.Room = new Room("pierwszy pokój", 3, "balkon", 76);
            secondHotel.Room = new Room("drugi pokój", 1, "wi-fi;wanna", 65.12);
            secondHotel.Room = new Room("trzeci pokój", 4, "wi-fi;sauna", 31);
            secondHotel.Room = new Room("czwarty pokój", 2, "wi-fi;sauna;TV;lodówka;salon", 99);
            secondHotel.Room = new Room("piąty pokój", 2, "wi-fi;sauna;TV;taras;jacuzzi", 87);
            PrepareRooms(secondHotel);
            Hotels.Add(secondHotel);
            Hotel thirdHotel = new Hotel("Hotel trzeci", 1, "Opis trzeciego hotelu", new Address("Warszawska", "12A", "81-713", "Toruń"), "contact@trzeci.pl");
            thirdHotel.Room = new Room("pierwszy pokój", 1, "jacuzzi", 76);
            thirdHotel.Room = new Room("drugi pokój", 1, "wi-fi;taras", 61);
            thirdHotel.Room = new Room("trzeci pokój", 2, "sauna", 25);
            secondHotel.Room = new Room("czwarty pokój", 4, "wi-fi;sauna;TV;lodówka;salon", 99);
            secondHotel.Room = new Room("piąty pokój", 5, "wi-fi;sauna;TV;taras;jacuzzi;wanna", 120);
            PrepareRooms(thirdHotel);
            Hotels.Add(thirdHotel);
        }
        protected void PrepareRooms(Hotel hotel)
        {
            foreach (Room room in hotel.Rooms)
            {
                Rooms.Add(room);
            }
        }
        protected void DisplayHotelIds()
        {
            foreach(Hotel hotel in Hotels)
            {
                hotel.PrintNameId();
                Display.ConsolePrint("------");
            }
        }
        protected bool validHotelId(int hotelId)
        {
            Hotel currentHotel = Hotels.Find(h => h.Id == hotelId);
            if (currentHotel == null){
                return false;
            }

            return true;
        }
        public void ShowHotelDoubleRooms()
        {
            Display.ConsolePrint("Hotele: ");
            DisplayHotelIds();
            Display.ConsolePrint("Podaj ID hotelu dla którego chcesz wyświetlić pokoje 2-osobowe");
            string hotelId = Console.ReadLine();
            while (!validHotelId(int.Parse(hotelId)))
            {
                CustomNotify("Podane ID hotelu jest nie poprawne!");
                CustomNotify("Podaj ID hotelu którego szukasz.");
                hotelId = Console.ReadLine();
            }

            int hotelIdInt = int.Parse(hotelId);
            Hotel currentHotel = Hotels.Find(h => h.Id == hotelIdInt);
            Display.ConsolePrint("\n------\nPonizej znajduje się lista pokoi 2-osobowych hotelu: " + currentHotel.Name + "\n");
            foreach (Room room in currentHotel.Rooms)
            {
                if (room.BedCount == 2)
                {
                    room.Print();
                }
            }
        }
        public void ExitProgram(string reason = "defaultExit")
        {
            Notify(reason);
            Thread.Sleep(1000);
            Notify("Program za chwilę się zakończy.", true, true);
            Thread.Sleep(1000);
            System.Environment.Exit(1);
        }
        public void CustomNotify(string notifyContent)
        {
            Notify(notifyContent, true, true);
        }
        public void Notify(string notifyContent, bool newLine = true, bool userContent = false)
        {
            if (!userContent)
            {
                notifyContent = NotificationContent(notifyContent);
            }

            if (!newLine)
            {
                Display.ConsolePrint(notifyContent, false);
                return;
            }

            Display.ConsolePrint(notifyContent);
        }
        public string NotificationContent(string notificationName)
        {
            if (notifications.ContainsKey(notificationName))
            {
                return notifications[notificationName];
            }

            return notifications["default"];
        }
        public void DynamicMethodCall(string method = "", string[] parameters = null)
        {
            if (string.IsNullOrEmpty(method))
            {
                method = menuActions[lastChoosenMenuOption];
            }

            if (method == "exitProgram")
            {
                parameters = new string[1];
                parameters[0] = "defaultExit";
            }

            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(method);
            theMethod.Invoke(this, parameters);
        }
    }
}
