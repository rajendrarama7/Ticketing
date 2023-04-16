namespace TicketApi.Tests
{
    internal class ValidationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NumberOfTicketsOverTwenty_Test()
        {
            var input = 21;
            var sut = new Validation();
            var result = sut.NumberOfTickets(input);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void NumberOfTicketsLessThanTwenty_Test()
        {
            var input = 19;
            var sut = new Validation();
            var result = sut.NumberOfTickets(input);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NumberOfTicketsEqualToTwenty_Test()
        {
            var input = 20;
            var sut = new Validation();
            var result = sut.NumberOfTickets(input);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NumberOfTicketsLessThanZero_Test()
        {
            var input = -1;
            var sut = new Validation();
            var result = sut.NumberOfTickets(input);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void IsAdultAccompanied_Test()
        {
            var sut = new Validation();
            var noOfAdults = 0;
            var result = sut.IsAdultAccompanied(noOfAdults);
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
