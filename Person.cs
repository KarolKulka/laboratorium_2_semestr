namespace zaliczenie_2_semestr
{
    public class Person
    {
        public string Name {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Phone {get;set;}
        public Address Address {get;set;}
        Display Display = new Display();
        public Person (string name, string lastName, string email, string phone, Address address)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public void Print()
        {
            Display.ConsolePrint("Imię i nazwisko: " + Name + " " + LastName);
            Display.ConsolePrint("E-mail: " + Email);
            Display.ConsolePrint("Phone: " + Phone);
            Address.Print();
        }
    }
}