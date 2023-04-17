using TicketApi.Entities.DTOs;
using TicketApi.Services;

namespace TicketApi.Tests.Services
{
    internal class TicketPaymentServiceTest
    {
        [Test]
        public async Task PaymentCalculator_Test()
        {
            var ticketTypeDTO = new TicketTypeDTO
            {
                Infant = 1,
                Child = 2,
                Adult = 1
            };
            var sut = new TicketPaymentService();
            var expected = "£40 received";
            var result = await sut.MakePayment(ticketTypeDTO);
            Assert.That(result.Message, Is.EqualTo(expected));
        }
    }
}
