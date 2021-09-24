using System.Collections.Generic;
using System.Linq;

namespace BookingHelper.Service
{
    public class BookingService : IBookingService
    {
        public List<Booking> GetActiveBooking(int? bookingId)
        {
            var unitOfWork = new UnitOfWork();
            var bookings = unitOfWork.Query<Booking>().Where(b => b.Status != Status.Cancelled);

            if (bookingId.HasValue)
                bookings = bookings.Where(b => b.Id != bookingId.Value);

            return bookings.ToList();
        }
    }
}