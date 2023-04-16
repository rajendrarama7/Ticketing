namespace TicketApi.Tests
{
    public class Validation
    {
        public bool IsAdultAccompanied(int noOfAdults)
        {
            if (noOfAdults >= Constants.MinNoOfAdults)
            {
                return true;
            }
            return false;
        }

        public bool NumberOfTickets(int input)
        {
            if (input <= Constants.MaxTickets && input >= Constants.MinTickets)
            {
                return true;
            }
            return false;
        }
    }
}
