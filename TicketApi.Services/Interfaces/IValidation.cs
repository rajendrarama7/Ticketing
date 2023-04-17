using TicketApi.Entities.DTOs;

namespace TicketApi.Services.Interfaces
{
    public interface IValidation
    {
        bool IsAdultAccompanied(int noOfAdults);
        bool ValidNumberOfTickets(TicketTypeDTO ticketTypeDTO);
    }
}
