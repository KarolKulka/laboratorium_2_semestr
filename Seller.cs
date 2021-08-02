using System;
namespace zaliczenie_2_semestr
{
    public class Seller : Person
    {
        public int Id {get;set;}
        public string PESEL {get;set;}
        public float Salary {get;set;}
        public float Commision {get;set;}
        public DateTime SignDate {get;set;}
    }
}