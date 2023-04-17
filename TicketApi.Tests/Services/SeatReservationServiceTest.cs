using TicketApi.Entities.DTOs;
using TicketApi.Services;

namespace TicketApi.Tests.Services
{
    internal class SeatReservationServiceTest
    {
        [Test]
        public async Task ReserveSeat_Test()
        {
            var ticketTypeDTO = new TicketTypeDTO
            {
                Infant = 2,
                Child = 3,
                Adult = 3
            };
            var expected = "6 seat(s) confirmed";
            var sut = new SeatReservationService();
            var result = await sut.ReserveSeats(ticketTypeDTO);
            Assert.That(result.Message, Is.EqualTo(expected));
        }
    }
}
