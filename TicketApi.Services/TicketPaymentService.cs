using TicketApi.Entities;
using TicketApi.Entities.DTOs;
using TicketApi.Services.Interfaces;

namespace TicketApi.Services
{
    public class TicketPaymentService : ITicketPayment
    {
        private int CalculatePayment(TicketTypeDTO ticketTypeDTO)
        {
            return (ticketTypeDTO.Infant * Constants.InfantPrice) + (ticketTypeDTO.Child * Constants.ChildPrice) + (ticketTypeDTO.Adult * Constants.AdultPrice);
        }

        public async Task<PaymentConfirmation> MakePayment(TicketTypeDTO ticketTypeDTO)
        {
            var payment = CalculatePayment(ticketTypeDTO);
            //make a call to ticket payment api
            return new PaymentConfirmation
            {
                Message = $"£{payment} received",
                Status = true
            };
        }
    }
}
