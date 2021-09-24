using BookingHelper.Service;
using System.Linq;

namespace BookingHelper1.Service
{
    public static class BookingHelpers
    {
        public static string OverlappingBookingExist(Booking booking, IBookingService bookingService)
        {
            if (booking.Status == Status.Cancelled) return string.Empty;

            var bookings = bookingService.GetActiveBooking(booking.Id);

            var overlapBooking = bookings.FirstOrDefault(b =>
                                    booking.ArrivalDate < b.DepartureDate &&
                                    b.ArrivalDate < booking.DepartureDate);

            return overlapBooking == null ? string.Empty : overlapBooking.Reference;
        }
    }
}