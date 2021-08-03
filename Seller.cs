using System;
namespace zaliczenie_2_semestr
{
    public class Seller : Person
    {
        public int Id { get; set; }
        public string Pesel { get; set; }
        public double Salary { get; set; }
        public float Commision { get; set; }
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
            Display.ConsolePrint("Data podpisania: " + SignDate.ToString("MM/dd/yyyy"));
        }
        public void PrintNameId()
        {
            Display.ConsolePrint("ID: " + Id);
            Display.ConsolePrint("Imię i nazwisko: " + Name + " " + LastName);
        }
    }
}