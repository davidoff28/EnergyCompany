using System;

namespace EnergyCompany.Models
{
    public class MeterReading
    {
        public int MeterReadingId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public Account Account { get; set; }
    }
}
