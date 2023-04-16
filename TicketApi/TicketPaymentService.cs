namespace TicketApi.Tests
{
    public class TicketPaymentService
    {
        public int CalculatePayment(int noOfInfants, int noOfChilds, int noOfAdults)
        {
            return (noOfInfants * Constants.InfantPrice) + (noOfChilds * Constants.ChildPrice) + (noOfAdults * Constants.AdultPrice);
        }
    }
}
