using TicketApi.Entities.DTOs;
using TicketApi.Services.Interfaces;

namespace TicketApi.Services
{
    public class ValidationService : IValidation
    {
        public bool IsAdultAccompanied(int noOfAdults)
        {
            if (noOfAdults >= Constants.MinNoOfAdults)
            {
                return true;
            }
            return false;
        }

        public bool ValidNumberOfTickets(TicketTypeDTO ticketTypeDTO)
        {
            if (ticketTypeDTO.Infant < 0 || ticketTypeDTO.Child < 0 || ticketTypeDTO.Adult < 0)
                return false;
            var tickets = ticketTypeDTO.Infant + ticketTypeDTO.Child + ticketTypeDTO.Adult;
            if (tickets <= Constants.MaxTickets && tickets >= Constants.MinTickets)
            {
                return true;
            }
            return false;
        }
    }
}
