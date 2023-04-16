namespace TicketApi.Tests
{
    public class SeatReservationService
    {
        public int NoOfSeatsToAllocate(int noOfInfants, int noOfChilds, int noOfAdults)
        {
            return (noOfInfants * Constants.InfantSeatAllocation)
                + (noOfChilds * Constants.ChildSeatAllocation)
                + (noOfAdults * Constants.AdultSeatAllocation);
        }
    }
}
