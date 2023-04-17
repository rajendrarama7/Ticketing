using TicketApi.Entities;
using TicketApi.Entities.DTOs;

namespace TicketApi.Services.Interfaces
{
    public interface ISeatReservation
    {
        Task<SeatConfirmation> ReserveSeats(TicketTypeDTO ticketTypeDTO);
    }
}
