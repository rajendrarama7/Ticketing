using TicketApi.Entities.DTOs;
using TicketApi.Services;

namespace TicketApi.Tests.Services
{
    internal class ValidationTest
    {
        [Test]
        public void NumberOfTicketsOverTwenty_Test()
        {
            var ticketTypeDTO = new TicketTypeDTO
            {
                Infant = 7,
                Child = 7,
                Adult = 7
            };
            var sut = new ValidationService();
            var result = sut.ValidNumberOfTickets(ticketTypeDTO);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void NumberOfTicketsLessThanTwenty_Test()
        {
            var ticketTypeDTO = new TicketTypeDTO
            {
                Infant = 5,
                Child = 7,
                Adult = 7
            };
            var sut = new ValidationService();
            var result = sut.ValidNumberOfTickets(ticketTypeDTO);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NumberOfTicketsEqualToTwenty_Test()
        {
            var ticketTypeDTO = new TicketTypeDTO
            {
                Infant = 6,
                Child = 7,
                Adult = 7
            };
            var sut = new ValidationService();
            var result = sut.ValidNumberOfTickets(ticketTypeDTO);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NumberOfTicketsLessThanZero_Test()
        {
            var ticketTypeDTO = new TicketTypeDTO
            {
                Infant = -7,
                Child = 7,
                Adult = 7
            };
            var sut = new ValidationService();
            var result = sut.ValidNumberOfTickets(ticketTypeDTO);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void IsAdultAccompanied_Test()
        {
            var sut = new ValidationService();
            var noOfAdults = 0;
            var result = sut.IsAdultAccompanied(noOfAdults);
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
