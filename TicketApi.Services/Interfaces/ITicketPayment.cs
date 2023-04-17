using TicketApi.Entities;
using TicketApi.Entities.DTOs;

namespace TicketApi.Services.Interfaces
{
    public interface ITicketPayment
    {
        Task<PaymentConfirmation> MakePayment(TicketTypeDTO ticketTypeDTO);
    }
}
