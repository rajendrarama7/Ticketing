namespace TicketApi.Tests
{
    internal class TicketPaymentServiceTest
    {
        [Test]
        public void PaymentCalculator_Test()
        {
            var noOfInfants = 1;
            var noOfChilds = 2;
            var noOfAdults = 1;
            var sut = new TicketPaymentService();
            var expected = 40;
            var result = sut.CalculatePayment(noOfInfants, noOfChilds, noOfAdults);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
