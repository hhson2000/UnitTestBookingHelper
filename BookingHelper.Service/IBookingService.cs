using System.Collections.Generic;

namespace BookingHelper.Service
{
    public interface IBookingService
    {
        List<Booking> GetActiveBooking(int? bookingId);
    }
}