namespace TicketApi.Tests
{
    internal class SeatReservationServiceTest
    {
        [Test]
        public void ReserveSeat_Test()
        {
            var noOfInfants = 2;
            var noOfChilds = 3;
            var noOfAdults = 3;
            var expected = 6;
            var sut = new SeatReservationService();
            var result = sut.NoOfSeatsToAllocate(noOfInfants, noOfChilds, noOfAdults);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
