using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TicketApi.Controllers;
using TicketApi.Entities;
using TicketApi.Entities.DTOs;
using TicketApi.Services.Interfaces;

namespace TicketApi.Tests.Controllers
{
    internal class TicketControllerTest
    {
        private Mock<ILogger<TicketController>> _mockLogger;
        private Mock<ISeatReservation> _mockSeatReservation;
        private Mock<IValidation> _mockValidation;
        private Mock<ITicketPayment> _mockTicketPayment;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<TicketController>>();
            _mockSeatReservation = new Mock<ISeatReservation>();
            _mockValidation = new Mock<IValidation>();
            _mockTicketPayment = new Mock<ITicketPayment>();
            _fixture = new Fixture();
        }

        [Test]
        public async Task GetTickets_WhenCalledWithInvalidNumberOfTickets()
        {
            var ticketTypeDTO = _fixture.Create<TicketTypeDTO>();
            _mockValidation.Setup(x => x.ValidNumberOfTickets(ticketTypeDTO)).Returns(false);
            
            var sut = CreateSut();
            var output = await sut.BookTickets(ticketTypeDTO);
            
            output.Should().NotBeNull().And.Subject.Should().BeOfType<BadRequestObjectResult>();

        }

        [Test]
        public async Task GetTickets_WhenCalledWithNoAdultsAccompanied()
        {
            var ticketTypeDTO = _fixture.Create<TicketTypeDTO>();
            _mockValidation.Setup(x => x.IsAdultAccompanied(ticketTypeDTO.Adult)).Returns(false);
            
            var sut = CreateSut();
            var output = await sut.BookTickets(ticketTypeDTO);
            
            output.Should().NotBeNull().And.Subject.Should().BeOfType<BadRequestObjectResult>();

        }

        [Test]
        public async Task GetTickets_WhenCalledWithUnsuccessfulPayment()
        {
            var ticketTypeDTO = _fixture.Create<TicketTypeDTO>();
            _mockValidation.Setup(x => x.ValidNumberOfTickets(ticketTypeDTO)).Returns(true);
            _mockValidation.Setup(x => x.IsAdultAccompanied(ticketTypeDTO.Adult)).Returns(true);
            _mockTicketPayment.Setup(x => x.MakePayment(ticketTypeDTO)).ReturnsAsync(new PaymentConfirmation { Status = false});
            
            var sut = CreateSut();
            var output = await sut.BookTickets(ticketTypeDTO);
            
            output.Should().NotBeNull().And.Subject.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public async Task GetTickets_WhenCalledWithsuccessfulPaymentAndReservation()
        {
            var ticketTypeDTO = _fixture.Create<TicketTypeDTO>();
            _mockValidation.Setup(x => x.ValidNumberOfTickets(ticketTypeDTO)).Returns(true);
            _mockValidation.Setup(x => x.IsAdultAccompanied(ticketTypeDTO.Adult)).Returns(true);
            _mockTicketPayment.Setup(x => x.MakePayment(ticketTypeDTO)).ReturnsAsync(new PaymentConfirmation { Status = true, Message ="Payment" });
            _mockSeatReservation.Setup(x => x.ReserveSeats(ticketTypeDTO)).ReturnsAsync(new SeatConfirmation { Status = true, Message = "Reservation" });
            
            var sut = CreateSut();
            var output = await sut.BookTickets(ticketTypeDTO);
            
            output.Should().NotBeNull().And.Subject.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be("Payment and Reservation");
        }

        [Test]
        public async Task GetTickets_WhenCalledWithsuccessfulPaymentAndUnsuccessfulReservation()
        {
            var ticketTypeDTO = _fixture.Create<TicketTypeDTO>();
            _mockValidation.Setup(x => x.ValidNumberOfTickets(ticketTypeDTO)).Returns(true);
            _mockValidation.Setup(x => x.IsAdultAccompanied(ticketTypeDTO.Adult)).Returns(true);
            _mockTicketPayment.Setup(x => x.MakePayment(ticketTypeDTO)).ReturnsAsync(new PaymentConfirmation { Status = true, Message = "Payment" });
            _mockSeatReservation.Setup(x => x.ReserveSeats(ticketTypeDTO)).ReturnsAsync(new SeatConfirmation { Status = false, Message = "Reservation" });
            
            var sut = CreateSut();
            var output = await sut.BookTickets(ticketTypeDTO);
            
            output.Should().NotBeNull().And.Subject.Should().BeOfType<BadRequestObjectResult>();
        }

        private TicketController CreateSut()
        {
            return new TicketController(_mockLogger.Object, _mockSeatReservation.Object, _mockTicketPayment.Object, _mockValidation.Object);
        }
    }
}
