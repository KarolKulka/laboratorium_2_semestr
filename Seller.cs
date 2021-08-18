using System;
namespace zaliczenie_2_semestr
{
    public class Seller : Person
    {
        private double commision = 0;
        public int Id { get; set; }
        public string Pesel { get; set; }
        public double Salary { get; set; }
        public double Commision 
        { 
            get
            {
                return commision;
            } 
        }
        public DateTime SignDate { get; set; }
        public Display Display = new Display();

        public Seller(string name, string lastName, string email, string phone, Address address, string pesel, double salary, DateTime signDate) : base(name, lastName, email, phone, address)
        {
            Random rnd = new Random();

            Id = rnd.Next(10,99);
            Pesel = pesel;
            Salary = salary;
            SignDate = signDate;
        }
        public new void Print()
        {
            Display.ConsolePrint("ID: " + Id);
            base.Print();
            Display.ConsolePrint("PESEL: " + Pesel);
            Display.ConsolePrint("Pensja podstawowa: " + Salary);
            Display.ConsolePrint("Prowizja: " + Commision);
            Display.ConsolePrint("Data podpisania: " + SignDate.ToString("MM/dd/yyyy"));
        }
        public void PrintCommisionInfo()
        {
            Display.ConsolePrint("ID: " + Id);
            Display.ConsolePrint("Imię i nazwisko: " + Name + " " + LastName);
            Display.ConsolePrint("Prowizja: " + Commision);
        }
        public void PrintNameId()
        {
            Display.ConsolePrint("ID: " + Id);
            Display.ConsolePrint("Imię i nazwisko: " + Name + " " + LastName);
        }
        public void AddCommision(double roomCost)
        {
            commision += roomCost * 0.03;
        }
        public void ResetCommision()
        {
            commision = 0;
        }
    }
}