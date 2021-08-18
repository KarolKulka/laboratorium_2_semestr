namespace zaliczenie_2_semestr
{
    public class Address
    {
        public string Street { get; set; }
        public string Building { get; set; }
        public string Appartment { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Display Display { get; set; }
        public Address(string street, string building, string appartment, string postalCode, string city)
        {
            Display = new Display();

            Street = street;
            Building = building;
            Appartment = appartment;
            PostalCode = postalCode;
            City = city;
            Country = "Polska";
        }
        public Address(string street, string building, string appartment, string postalCode, string city, string country)
        {
            Display = new Display();

            Street = street;
            Building = building;
            Appartment = appartment;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public Address(string street, string building, string postalCode, string city)
        {
            Display = new Display();

            Street = street;
            Building = building;
            PostalCode = postalCode;
            City = city;
            Appartment = "";
            Country = "Polska";
        }

        public void Print()
        {
            Display.ConsolePrint("---------------");
            Display.ConsolePrint("ADRES: ");
            Display.ConsolePrint(Street + " " + Building, false);
            if (Appartment != "")
            {
                Display.ConsolePrint("/" + Appartment);
            }
            else
            {
                Display.ConsolePrint("");
            }
            Display.ConsolePrint(PostalCode + " " + City);
            Display.ConsolePrint("---------------");
        }
    }
}