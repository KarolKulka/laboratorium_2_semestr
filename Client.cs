using System;
namespace zaliczenie_2_semestr
{
    public class Client : Person
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string PassportNumber { get; set; }
        public string AdditionalInfo { get; set; }
        public Display Display = new Display();
        public Client(string name, string lastName, string email, string phone, Address address, string status, string passportNumber, string additionalInfo) : base(name, lastName, email, phone, address)
        {
            Random rnd = new Random();

            Id = rnd.Next(10, 99);
            Status = status;
            PassportNumber = passportNumber;
            AdditionalInfo = additionalInfo;
        }
        public new void Print()
        {
            Display.ConsolePrint("ID: " + Id);
            base.Print();
            Display.ConsolePrint("Status: " + Status);
            Display.ConsolePrint("Numer paszportu: " + PassportNumber);
            Display.ConsolePrint("Dane dodatkowe: \n" + AdditionalInfo + "\n------");
        }
    }
}