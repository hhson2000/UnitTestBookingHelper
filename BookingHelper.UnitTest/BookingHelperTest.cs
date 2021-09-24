using BookingHelper.Service;
using BookingHelper1.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookingHelper.UnitTest
{
    public class BookingHelperTest
    {
        private Mock<IBookingService> _mockBookingService;
        private List<Booking> bookings;

        [SetUp]
        public void Setup()
        {
            _mockBookingService = new Mock<IBookingService>();
            bookings = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                Status = "Live",
                ArrivalDate = DateTime.Now.AddDays(2),
                DepartureDate = DateTime.Now.AddDays(10),
                Reference="Nice"
                },
             };
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            //arrange
            _mockBookingService.Setup(x => x.GetActiveBooking(It.IsAny<int>())).Returns(bookings);
            
            var booking = new Booking()
            {
                Id = 2,
                Status = "Live",
                ArrivalDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(1),
                Reference = "Nice"
            };
            // act
            var result = BookingHelpers.OverlappingBookingExist(booking, _mockBookingService.Object);

            //Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
       public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingsReference()
        {
            //arrange
            _mockBookingService.Setup(x => x.GetActiveBooking(It.IsAny<int>())).Returns(bookings);

            var booking = new Booking()
            {
                Id = 2,
                Status = "Live",
                ArrivalDate = DateTime.Now.AddDays(2),
                DepartureDate = DateTime.Now.AddDays(2),
                Reference = "Nice"
            };
            // act
            var result = BookingHelpers.OverlappingBookingExist(booking, _mockBookingService.Object);

            //Assert
            Assert.That(result, Is.EqualTo(booking.Reference));

        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterOfAnExistingBooking_ReturnExistingBookingsReference()
        {
            //arrange
            _mockBookingService.Setup(x => x.GetActiveBooking(It.IsAny<int>())).Returns(bookings);

            var booking = new Booking()
            {
                Id = 2,
                Status = "Live",
                ArrivalDate = DateTime.Now.AddDays(2),
                DepartureDate = DateTime.Now.AddDays(11),
                Reference = "Nice"
            };
            // act
            var result = BookingHelpers.OverlappingBookingExist(booking, _mockBookingService.Object);

            //Assert
            Assert.That(result, Is.EqualTo(booking.Reference));

        }

        [Test]
        public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingsReference()
        {
            //arrange
            _mockBookingService.Setup(x => x.GetActiveBooking(It.IsAny<int>())).Returns(bookings);

            var booking = new Booking()
            {
                Id = 2,
                Status = "Live",
                ArrivalDate = DateTime.Now.AddDays(4),
                DepartureDate = DateTime.Now.AddDays(5),
                Reference = "Nice"
            };
            // act
            var result = BookingHelpers.OverlappingBookingExist(booking, _mockBookingService.Object);

            //Assert
            Assert.That(result, Is.EqualTo(booking.Reference));

        }

        [Test]
        public void BookingStartsInTheMiddleAndFinishesAfterOfAnExistingBooking_ReturnExistingBookingsReference()
        {
            //arrange
            _mockBookingService.Setup(x => x.GetActiveBooking(It.IsAny<int>())).Returns(bookings);

            var booking = new Booking()
            {
                Id = 2,
                Status = "Live",
                ArrivalDate = DateTime.Now.AddDays(4),
                DepartureDate = DateTime.Now.AddDays(12),
                Reference = "Nice"
            };
            // act
            var result = BookingHelpers.OverlappingBookingExist(booking, _mockBookingService.Object);

            //Assert
            Assert.That(result, Is.EqualTo(booking.Reference));

        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            //arrange
            _mockBookingService.Setup(x => x.GetActiveBooking(It.IsAny<int>())).Returns(bookings);

            var booking = new Booking()
            {
                Id = 2,
                Status = "Live",
                ArrivalDate = DateTime.Now.AddDays(13),
                DepartureDate = DateTime.Now.AddDays(14),
                Reference = "Nice"
            };
            // act
            var result = BookingHelpers.OverlappingBookingExist(booking, _mockBookingService.Object);

            //Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void BookingOverlapButNewBookingIsCancelled_ReturnEmptyString()
        {
            //arrange
            _mockBookingService.Setup(x => x.GetActiveBooking(It.IsAny<int>())).Returns(bookings);

            var booking = new Booking()
            {
                Id = 2,
                Status = "Cancelled",
                ArrivalDate = DateTime.Now.AddDays(5),
                DepartureDate = DateTime.Now.AddDays(6),
                Reference = "Nice"
            };
            // act
            var result = BookingHelpers.OverlappingBookingExist(booking, _mockBookingService.Object);

            //Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}