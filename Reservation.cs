using System;
namespace zaliczenie_2_semestr
{
    public class Reservation
    {
        private double cost;
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int SellerId { get; set; }
        public int ClientId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = (EndDate - BeginDate).TotalDays * value;
            }
        }
        public DateTime SellDate { get; set; }
        public Display Display = new Display();
        public Reservation(Room room, int sellerId, int clientId, DateTime beginDate, DateTime endDate, DateTime sellDate)
        {
            Random rnd = new Random();

            Id = int.Parse(rnd.Next(10, 99).ToString() + room.Id.ToString() + sellerId.ToString());
            RoomId = room.Id;
            SellerId = sellerId;
            BeginDate = beginDate;
            EndDate = endDate;
            SellDate = sellDate;
            ClientId = clientId;
            Cost = room.Price;
        }
        public void Print()
        {
            Display.ConsolePrint("ID: " + Id);
            Display.ConsolePrint("Pokój: " + RoomId);
            Display.ConsolePrint("Sprzedawca: " + SellerId);
            Display.ConsolePrint("Klient: " + ClientId);
            Display.ConsolePrint("Początek rezerwacji: " + BeginDate.ToString("dd/MM/yyyy"));
            Display.ConsolePrint("Koniec rezerwacji: " + EndDate.ToString("dd/MM/yyyy"));
            Display.ConsolePrint("Koszt: " + Cost + " zł");
            Display.ConsolePrint("Data sprzedazy: " + SellDate.ToString("dd/MM/yyyy"));
        }
    }
}