using System.Collections.Generic;
using System.Threading;
using System;
using System.Reflection;
using System.Linq;

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
            { "menuPos6", "6. Wyświetl rezerwacje wszystkich klientów z Polski, którzy wybierają się do hoteli w Grecji." },
            { "menuPos7", "7. Wyświetl wszystkich klientów ze statusem „VIP”, którzy wybierają się do Krakowa." },
            { "menuPos8", "8. Wyjście z programu" },
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
            { 6, "ShowClientsFromPolandGoingToGreece" },
            { 7, "ShowAllClientsWithVipStatus" },
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
            for (i = 1; i <= 8; i++)
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
            PrepareSellers();
            PrepareClients();
            PrepareReservations();
        }
        protected void PrepareReservations()
        {
            Reservation firstReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("3/2/2021"), Convert.ToDateTime("15/2/2021"), Convert.ToDateTime("10/1/2021"));
            Reservation secondReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/2/2021"), Convert.ToDateTime("25/2/2021"), Convert.ToDateTime("1/2/2021"));
            Reservation thirdReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("1/5/2021"), Convert.ToDateTime("2/6/2021"), Convert.ToDateTime("11/4/2021"));
            Reservation fourtReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("1/1/2021"), Convert.ToDateTime("5/1/2021"), Convert.ToDateTime("21/12/2020"));
            Reservation fifthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/6/2021"), Convert.ToDateTime("1/7/2021"), Convert.ToDateTime("11/6/2021"));
            Reservation sixthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("1/5/2021"), Convert.ToDateTime("15/5/2021"), Convert.ToDateTime("10/4/2021"));
            Reservation seventhReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("7/9/2021"), Convert.ToDateTime("29/8/2021"), Convert.ToDateTime("28/8/2021"));
            Reservation eigthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/7/2021"), Convert.ToDateTime("15/7/2021"), Convert.ToDateTime("10/7/2021"));
            Reservation ninethReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("3/10/2021"), Convert.ToDateTime("18/10/2021"), Convert.ToDateTime("19/6/2021"));
            Reservation tenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("1/12/2021"), Convert.ToDateTime("29/12/2021"), Convert.ToDateTime("1/3/2021"));
            Reservation eleventhReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("12/3/2021"), Convert.ToDateTime("15/3/2021"), Convert.ToDateTime("10/3/2021"));
            Reservation twelvethReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("9/9/2021"), Convert.ToDateTime("11/9/2021"), Convert.ToDateTime("8/9/2021"));
            Reservation thirteenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("15/7/2021"), Convert.ToDateTime("26/7/2021"), Convert.ToDateTime("10/7/2021"));
            Reservation fourteenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("6/2/2021"), Convert.ToDateTime("15/2/2021"), Convert.ToDateTime("1/1/2021"));
            Reservation fifteenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("12/2/2021"), Convert.ToDateTime("20/2/2021"), Convert.ToDateTime("10/2/2021"));
            Reservation sixteenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("1/8/2021"), Convert.ToDateTime("15/8/2021"), Convert.ToDateTime("10/6/2021"));
            Reservation seventeenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/12/2021"), Convert.ToDateTime("25/12/2021"), Convert.ToDateTime("6/12/2021"));
            Reservation eighteenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/6/2021"), Convert.ToDateTime("15/7/2021"), Convert.ToDateTime("1/5/2021"));
            Reservation nineteenthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("29/5/2021"), Convert.ToDateTime("29/6/2021"), Convert.ToDateTime("10/4/2021"));
            Reservation twentyReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("3/1/2021"), Convert.ToDateTime("15/1/2021"), Convert.ToDateTime("1/1/2021"));
            Reservation twentyFirstReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/10/2021"), Convert.ToDateTime("25/10/2021"), Convert.ToDateTime("1/9/2021"));
            Reservation twentySecondReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/12/2021"), Convert.ToDateTime("15/12/2021"), Convert.ToDateTime("10/1/2021"));
            Reservation twentyThirdReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("11/6/2021"), Convert.ToDateTime("15/7/2021"), Convert.ToDateTime("10/6/2021"));
            Reservation twentyFourthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("11/7/2021"), Convert.ToDateTime("15/7/2021"), Convert.ToDateTime("10/7/2021"));
            Reservation twentyFifthReservation = new Reservation(getRandomRoom(), getRandomSeller().Id, getRandomClient().Id, Convert.ToDateTime("13/8/2021"), Convert.ToDateTime("15/8/2021"), Convert.ToDateTime("10/8/2021"));
            Reservations.Add(firstReservation);
            Reservations.Add(secondReservation);
            Reservations.Add(thirdReservation);
            Reservations.Add(fourtReservation);
            Reservations.Add(fifthReservation);
            Reservations.Add(sixthReservation);
            Reservations.Add(seventhReservation);
            Reservations.Add(eigthReservation);
            Reservations.Add(ninethReservation);
            Reservations.Add(tenthReservation);
            Reservations.Add(eleventhReservation);
            Reservations.Add(twelvethReservation);
            Reservations.Add(thirteenthReservation);
            Reservations.Add(fourteenthReservation);
            Reservations.Add(fifteenthReservation);
            Reservations.Add(sixteenthReservation);
            Reservations.Add(seventeenthReservation);
            Reservations.Add(eighteenthReservation);
            Reservations.Add(nineteenthReservation);
            Reservations.Add(twentyReservation);
            Reservations.Add(twentyFirstReservation);
            Reservations.Add(twentySecondReservation);
            Reservations.Add(twentyThirdReservation);
            Reservations.Add(twentyFourthReservation);
            Reservations.Add(twentyFifthReservation);
        }
        protected Room getRandomRoom()
        {
            Random rnd = new Random();
            return Rooms[rnd.Next(Rooms.Count)];
        }
        protected Seller getRandomSeller()
        {
            Random rnd = new Random();
            return Sellers[rnd.Next(Sellers.Count)];
        }
        protected Hotel getRandomHotel()
        {
            Random rnd = new Random();
            return Hotels[rnd.Next(Hotels.Count)];
        }
        protected Client getRandomClient()
        {
            Random rnd = new Random();
            return Clients[rnd.Next(Clients.Count)];
        }
        protected void PrepareClients()
        {
            Client firstClient = new Client("Andrzej", "Kowalski", "kowaland@gmail.com", "+48 111 222 333", new Address("Towarowa", "10", "85-311", "Bydgoszcz"), "VIP", "1234A", "Lorem ipsum");
            Clients.Add(firstClient);
            Client secondClient = new Client("Tomek", "Kowalewski", "kowalktom@gmail.com", "+48 123 666 452", new Address("Śleszyńska", "12", "1A", "85-311", "Bydgoszcz"), "VIP", "1145B", "Some info");
            Clients.Add(secondClient);
            Client thirdClient = new Client("Anna", "Gontek", "anngont@gmail.com", "+48 123 456 667", new Address("Gdańska", "45", "21", "87-123", "Londyn", "Wielka Brytania"), "Normal", "8754Z", "Info");
            Clients.Add(thirdClient);
            Client fourthClient = new Client("Iwona", "Świątecka", "swiiw@gmail.com", "+48 765 890 112", new Address("Towarowa", "13", "81-319", "Włocławek"), "Normal", "0987H", "zxcasdqwe zxcasd");
            Clients.Add(fourthClient);
            Client fifthClient = new Client("Marian", "Zdun", "marzdu@gmail.com", "+48 555 678 231", new Address("Porzeczkowa", "1", "14", "76-322", "Piła"), "VIP", "8851L", "info info info");
            Clients.Add(fifthClient);
            Client sixthClient = new Client("Janusz", "Nosacz", "nosjan1234@gmail.com", "+48 986 874 654", new Address("Szubińska", "4C", "78", "85-302", "Berlin", "Niemcy"), "Normal", "9871A", "some additional info");
            Clients.Add(sixthClient);
            Client seventhClient = new Client("Irena", "Kowal", "kowalirena@gmail.com", "+48 546 789 342", new Address("Jodłowa", "12", "11", "85-311", "Bydgoszcz"), "VIP", "98765F", "This is extra info");
            Clients.Add(seventhClient);
        }
        protected void PrepareSellers()
        {
            Seller firstSeller = new Seller("Jan", "Kowalski", "kowaljan@gmail.com", "+48 876 123 452", new Address("Towarowa", "10", "85-311", "Bydgoszcz"), "12345345635", 43.2, Convert.ToDateTime("21/12/1999"));
            Sellers.Add(firstSeller);
            Seller secondSeller = new Seller("Tomek", "Kowalkowski", "kowalk@gmail.com", "+48 123 666 452", new Address("Śleszyńska", "12", "1A", "85-311", "Bydgoszcz"), "976554567897", 65, Convert.ToDateTime("16/2/2005"));
            Sellers.Add(secondSeller);
            Seller thirdSeller = new Seller("Agnieszka", "Kostrzela", "agakost@gmail.com", "+48 654 457 987", new Address("Gdańsak", "45", "21", "87-123", "Toruń"), "12356785468", 54, Convert.ToDateTime("12/3/2012"));
            Sellers.Add(thirdSeller);
            Seller fourthSeller = new Seller("Iwona", "Świątek", "swiatekiwona@gmail.com", "+48 452 546 789", new Address("Towarowa", "13", "81-319", "Włocławek"), "57644834521", 101, Convert.ToDateTime("1/1/206"));
            Sellers.Add(fourthSeller);
            Seller fifthSeller = new Seller("Mariusz", "Woda", "marwod@gmail.com", "+48 111 232 433", new Address("Porzeczkowa", "1", "14", "76-322", "Piła"), "98877678909", 24, Convert.ToDateTime("15/3/2021"));
            Sellers.Add(fifthSeller);
            Seller sixthSeller = new Seller("Janusz", "Nosacz", "nosjan@gmail.com", "+48 111 222 333", new Address("Szubińska", "4C", "78", "85-302", "Bydgoszcz"), "98766532412", 120, Convert.ToDateTime("12/6/1993"));
            Sellers.Add(sixthSeller);
            Seller seventhSeller = new Seller("Irena", "Kowalska", "kowalskairena@gmail.com", "+48 987 654 234", new Address("Jodłowa", "12", "11", "85-311", "Bydgoszcz"), "87655434567", 47.8, Convert.ToDateTime("1/9/2002"));
            Sellers.Add(seventhSeller);
        }
        protected void PrepareHotels()
        {
            Random rnd = new Random();

            Hotel firstHotel = new Hotel("Hotel pierwszy", 3, "Opis pierwszego hotelu", new Address("Szubińska", "12A", "85-123", "Bydgoszcz"), "contact@pierwszy.pl");
            firstHotel.Room = new Room("pierwszy pokój", rnd.Next(1, 6), "wi-fi;balkon", 12.31);
            firstHotel.Room = new Room("drugi pokój", rnd.Next(1, 6), "wi-fi;balkon;wanna", 50);
            firstHotel.Room = new Room("trzeci pokój", rnd.Next(1, 6), "wi-fi;taras", 43.7);
            firstHotel.Room = new Room("czwarty pokój", rnd.Next(1, 6), "wi-fi;taras;telewizor", 44);
            firstHotel.Room = new Room("piąty pokój", rnd.Next(1, 6), "wi-fi;taras;lodówka", 49);
            PrepareRooms(firstHotel);
            Hotels.Add(firstHotel);
            Hotel secondHotel = new Hotel("Hotel drugi", 5, "Opis drugiego hotelu", new Address("Jagiellońska", "2", "89-423", "Kraków"), "contact@drugi.pl");
            secondHotel.Room = new Room("pierwszy pokój", rnd.Next(1, 6), "balkon", 76);
            secondHotel.Room = new Room("drugi pokój", rnd.Next(1, 6), "wi-fi;wanna", 65.12);
            secondHotel.Room = new Room("trzeci pokój", rnd.Next(1, 6), "wi-fi;sauna", 31);
            secondHotel.Room = new Room("czwarty pokój", rnd.Next(1, 6), "wi-fi;sauna;TV;lodówka;salon", 99);
            secondHotel.Room = new Room("piąty pokój", rnd.Next(1, 6), "wi-fi;sauna;TV;taras;jacuzzi", 87);
            PrepareRooms(secondHotel);
            Hotels.Add(secondHotel);
            Hotel thirdHotel = new Hotel("Hotel trzeci", 1, "Opis trzeciego hotelu", new Address("Warszawska", "12A", "81-713", "Toruń"), "contact@trzeci.pl");
            thirdHotel.Room = new Room("pierwszy pokój", rnd.Next(1, 6), "jacuzzi", 76);
            thirdHotel.Room = new Room("drugi pokój", rnd.Next(1, 6), "wi-fi;taras", 61);
            thirdHotel.Room = new Room("trzeci pokój", rnd.Next(1, 6), "sauna", 25);
            thirdHotel.Room = new Room("czwarty pokój", rnd.Next(1, 6), "wi-fi;sauna;TV;lodówka;salon", 99);
            thirdHotel.Room = new Room("piąty pokój", rnd.Next(1, 6), "wi-fi;sauna;TV;taras;jacuzzi;wanna", 120);
            PrepareRooms(thirdHotel);
            Hotels.Add(thirdHotel);
            Hotel fourthHotel = new Hotel("Hotel trzeci", 1, "Opis trzeciego hotelu", new Address("Ateńska", "12A", "", "123123", "Ateny", "Grecja"), "contact@czwarty.pl");
            fourthHotel.Room = new Room("pierwszy pokój", rnd.Next(1, 6), "jacuzzi", 12);
            fourthHotel.Room = new Room("drugi pokój", rnd.Next(1, 6), "wi-fi;taras", 66);
            fourthHotel.Room = new Room("trzeci pokój", rnd.Next(1, 6), "sauna", 99);
            fourthHotel.Room = new Room("czwarty pokój", rnd.Next(1, 6), "wi-fi;sauna;TV;lodówka;salon", 15);
            fourthHotel.Room = new Room("piąty pokój", rnd.Next(1, 6), "wi-fi;sauna;TV;taras;jacuzzi;wanna", 120);
            PrepareRooms(fourthHotel);
            Hotels.Add(fourthHotel);
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
            foreach (Hotel hotel in Hotels)
            {
                hotel.PrintNameId();
                Display.ConsolePrint("------");
            }
        }
        protected bool validHotelId(int hotelId)
        {
            Hotel currentHotel = Hotels.Find(h => h.Id == hotelId);
            if (currentHotel == null)
            {
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
            foreach (Room room in Rooms.FindAll(r => r.HotelId == currentHotel.Id))
            {
                if (room.BedCount == 2)
                {
                    room.Print();
                }
            }
            MenuInvoker();
        }
        protected void DisplaySellerIds()
        {
            foreach (Seller seller in Sellers)
            {
                seller.PrintNameId();
                Display.ConsolePrint("------");
            }
        }
        protected bool validSellerId(int sellerId)
        {
            Seller currentSeller = Sellers.Find(h => h.Id == sellerId);
            if (currentSeller == null)
            {
                return false;
            }

            return true;
        }
        protected void MenuInvoker()
        {
            CustomNotify("\nAby powrócić do menu naduś dowolny przycisk");
            Console.ReadKey();
            DisplayMenu();
        }
        public void ShowSellerReservations()
        {
            Display.ConsolePrint("Sprzedawcy: ");
            DisplaySellerIds();
            Display.ConsolePrint("Podaj ID sprzedawcy dla którego chcesz wyświetlić rezerwacje");
            string sellerId = Console.ReadLine();
            while (!validSellerId(int.Parse(sellerId)))
            {
                CustomNotify("Podane ID sprzedawcy jest nie poprawne!");
                CustomNotify("Podaj ID sprzedawcy którego szukasz.");
                sellerId = Console.ReadLine();
            }

            int sellerIdInt = int.Parse(sellerId);
            Seller currentSeller = Sellers.Find(h => h.Id == sellerIdInt);
            int counter = 0;
            Display.ConsolePrint("\n------\nPonizej znajduje się lista rezerwaji sprzedawcy: " + currentSeller.Name + " " + currentSeller.LastName + "(" + currentSeller.Id + ")" + "\n");
            foreach (Reservation reservation in Reservations.FindAll(r => r.SellerId == currentSeller.Id))
            {
                reservation.Print();
                Display.ConsolePrint("-------");
                counter++;
            }
            if (counter == 0)
            {
                Display.ConsolePrint("Podany sprzedawca nie dokonał zadnej sprzedazy!");
            }
            MenuInvoker();
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

            if (method == "ExitProgram")
            {
                parameters = new string[1];
                parameters[0] = "defaultExit";
            }

            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(method);
            theMethod.Invoke(this, parameters);
        }
        public void ShowReservationsSoldInLastThirtyDays()
        {
            DateTime currentDate = DateTime.Now;
            int counter = 0;
            foreach (Reservation reservation in Reservations.FindAll(r => (r.SellDate < currentDate) && (r.SellDate > currentDate.AddDays(-30))))
            {
                reservation.Print();
                Display.ConsolePrint("-----");
                counter++;
            }
            if (counter == 0)
            {
                Display.ConsolePrint("Nie dokonano sprzedazy w ciągu ostatnich 30 dni!");
            }
            MenuInvoker();
        }
        public void ShowHotelReservationsBeginingOrEndingInNextWeek()
        {
            Display.ConsolePrint("Hotele: ");
            DisplayHotelIds();
            Display.ConsolePrint("Podaj ID hotelu dla którego chcesz wyświetlić rezerwacje zaczynająca lub kończące się w przyszłym tygodniu");
            string hotelId = Console.ReadLine();
            while (!validHotelId(int.Parse(hotelId)))
            {
                CustomNotify("Podane ID hotelu jest nie poprawne!");
                CustomNotify("Podaj ID hotelu którego szukasz.");
                hotelId = Console.ReadLine();
            }

            int hotelIdInt = int.Parse(hotelId);
            Hotel currentHotel = Hotels.Find(h => h.Id == hotelIdInt);
            Display.ConsolePrint("\n------\nPonizej znajduje się lista rezerwacji kończących lub zaczynających się w przyszłym tygodniu dla hotelu: " + currentHotel.Name + "\n");
            List<int> roomIds = new List<int>();
            foreach (Room room in Rooms.FindAll(r => r.HotelId == currentHotel.Id))
            {
                roomIds.Add(room.Id);
            }
            DateTime today = DateTime.Now;
            int currentDayOfWeek = (int)today.DayOfWeek;
            int nextWeekdAddDays = 0;
            if (currentDayOfWeek == 0)
            {
                nextWeekdAddDays = 1;
            }
            else
            {
                nextWeekdAddDays = 8 - currentDayOfWeek;
            }
            int existingReservations = 0;
            foreach (
                Reservation reservation in Reservations.FindAll(
                    r => (roomIds.Contains(r.RoomId) &&
                            (
                                (r.BeginDate >= today.AddDays(nextWeekdAddDays) && r.BeginDate <= today.AddDays(nextWeekdAddDays + 6))
                                || (r.EndDate >= today.AddDays(nextWeekdAddDays) && r.EndDate <= today.AddDays(nextWeekdAddDays + 6))
                            )
                    )
                )
            )
            {
                reservation.Print();
                Display.ConsolePrint("--------");
                existingReservations++;
            }
            if (existingReservations == 0)
            {
                Display.ConsolePrint("Wybrany hotel nie ma rezerwacji kończących lub zaczynających się w przyszłym tygodniu");
            }
            MenuInvoker();
        }
        protected bool ValidMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                return false;
            }

            return true;
        }
        protected string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "Styczeń";
                case 2:
                    return "Luty";
                case 3:
                    return "Marzec";
                case 4:
                    return "Kwiecień";
                case 5:
                    return "Maj";
                case 6:
                    return "Czerwiec";
                case 7:
                    return "Lipiec";
                case 8:
                    return "Sierpień";
                case 9:
                    return "Wrzesień";
                case 10:
                    return "Październik";
                case 11:
                    return "Listopad";
                case 12:
                    return "Grudzień";
            }

            return "invalid month";
        }
        public void ShowBestSellersFromGivenMonth()
        {
            Display.ConsolePrint("Podaj numer miesiąca dla jakiego chcesz sprawdzić ranking sprzedawców");
            string month = Console.ReadLine();
            while (!ValidMonth(int.Parse(month)))
            {
                CustomNotify("Podany miesiąc jest błędny!");
                CustomNotify("Podaj numer miesiąca dla jakiego chcesz sprawdzić ranking sprzedawców.");
                month = Console.ReadLine();
            }

            int monthInt = int.Parse(month);

            Display.ConsolePrint("Lista najlepszych sprzedawców w miesiącu: " + GetMonthName(int.Parse(month)));
            Display.ConsolePrint("Wyświetlani są tylko Ci sprzedawcy którzy dokonali sprzdazy w danym miesiącu");
            foreach (Seller seller in Sellers)
            {
                seller.ResetCommision();
            }
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.SellDate.Month == monthInt)
                {
                    foreach (Seller seller in Sellers)
                    {
                        if (seller.Id == reservation.SellerId)
                        {
                            seller.AddCommision(reservation.Cost);
                        }
                    }
                }
            }

            List<Seller> sellersRanking = Sellers.OrderByDescending(s => s.Commision).ToList();

            int counter = 1;
            foreach (Seller bestSeller in sellersRanking.FindAll(s => s.Commision > 0))
            {
                Display.ConsolePrint("#" + counter);
                bestSeller.PrintCommisionInfo();
                Display.ConsolePrint("-----------\n\n");
                counter++;
            }

            MenuInvoker();
        }
        public void ShowClientsFromPolandGoingToGreece()
        {
            List<Reservation> ReservationsClientsFromPolandInGreece = new List<Reservation>();
            foreach (Hotel hotel in Hotels.FindAll(h => h.Address.Country == "Grecja"))
            {
                foreach (Room room in Rooms.FindAll(r => r.HotelId == hotel.Id))
                {
                    foreach (Reservation reservation in Reservations.FindAll(re => re.RoomId == room.Id))
                    {
                        Client client = Clients.Find(c => c.Id == reservation.ClientId);
                        if (client.Address.Country == "Polska")
                        {
                            ReservationsClientsFromPolandInGreece.Add(reservation);
                        }
                    }
                }
            }

            Display.ConsolePrint("Rezerwacje klientów z Polski jadących do Grecji: ");
            foreach (Reservation reservation1 in ReservationsClientsFromPolandInGreece)
            {
                reservation1.Print();
                Display.ConsolePrint("-------");
            }

            if (ReservationsClientsFromPolandInGreece.Count == 0)
            {
                Display.ConsolePrint("Nie ma zadnych rezerwacji klientów z Polski w Grecji");
            }

            MenuInvoker();
        }
        public void ShowAllClientsWithVipStatus()
        {
            List<int> HotelsInCracowIds = new List<int>();
            foreach (Hotel hotel in Hotels.FindAll(h => h.Address.City == "Kraków"))
            {
                HotelsInCracowIds.Add(hotel.Id);
            }

            if (HotelsInCracowIds.Count == 0){
                Display.ConsolePrint("Nie ma w tej chwili zadnych hoteli w Krakowie :(");
                MenuInvoker();
            }

            List<int> VipClientIds = new List<int>();
            foreach (Client client in Clients.FindAll(c => c.Status == "VIP")){
                VipClientIds.Add(client.Id);
            }

            List<Reservation> ReservationsInCracowHotels = new List<Reservation>();
            foreach(Room room in Rooms.FindAll(r => HotelsInCracowIds.Contains(r.HotelId))){
                foreach (Reservation reservation in Reservations.FindAll(re => (re.RoomId == room.Id && VipClientIds.Contains(re.ClientId)))){
                    ReservationsInCracowHotels.Add(reservation);
                }
            }

            
        }
    }
}
