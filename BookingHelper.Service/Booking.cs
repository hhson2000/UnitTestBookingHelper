using System;

namespace BookingHelper.Service
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public string Reference { get; set; }

        public string Status { get; set; }
    }
}