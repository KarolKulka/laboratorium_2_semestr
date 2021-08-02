using System;
namespace zaliczenie_2_semestr
{
    public class Reservation
    {
        public int Id {get;set;}
        public int RoomId {get;set;}
        public int SellerId {get;set;}
        public DateTime BeginDate {get;set;}
        public DateTime EndDate {get;set;}
        public float Cost {get;set;}
        public DateTime SellDate {get;set;}
    }
}