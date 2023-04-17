using TicketApi.Entities;
using TicketApi.Entities.DTOs;
using TicketApi.Services.Interfaces;

namespace TicketApi.Services
{
    public class SeatReservationService : ISeatReservation
    {
        private int NoOfSeatsToAllocate(TicketTypeDTO ticketTypeDTO)
        {
            return (ticketTypeDTO.Infant * Constants.InfantSeatAllocation)
                + (ticketTypeDTO.Child * Constants.ChildSeatAllocation)
                + (ticketTypeDTO.Adult * Constants.AdultSeatAllocation);
        }

        public async Task<SeatConfirmation> ReserveSeats(TicketTypeDTO ticketTypeDTO)
        {
            var seatsToReserve = NoOfSeatsToAllocate(ticketTypeDTO);
            //make a call to seat reservation api
            return new SeatConfirmation
            {
                Message = $"{seatsToReserve} seat(s) confirmed",
                Status = true
            };
        }
    }
}
