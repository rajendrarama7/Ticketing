using Microsoft.AspNetCore.Mvc;
using TicketApi.Entities.DTOs;
using TicketApi.Services.Interfaces;

namespace TicketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ISeatReservation _seatReservationService;
        private readonly ITicketPayment _ticketPaymentService;
        private readonly IValidation _validationService;
        public TicketController(ILogger<TicketController> logger, ISeatReservation seatReservationService, ITicketPayment ticketPaymentService, IValidation validationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _seatReservationService = seatReservationService ?? throw new ArgumentNullException(nameof(seatReservationService));
            _ticketPaymentService = ticketPaymentService ?? throw new ArgumentNullException(nameof(ticketPaymentService));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
        }

        [HttpGet(Name = "Tickets")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery]TicketTypeDTO ticketTypeDTO)
        {
            if (!_validationService.ValidNumberOfTickets(ticketTypeDTO) || !_validationService.IsAdultAccompanied(ticketTypeDTO.Adult))
            {
                _logger.LogInformation("Invalid input request");
                return BadRequest("Invalid input request");
            }
            var payment = await _ticketPaymentService.MakePayment(ticketTypeDTO);
            if (!payment.Status)
            {
                _logger.LogInformation("Payment request has not gone through");
                return BadRequest(payment.Message);
            }
            
            var reservation = await _seatReservationService.ReserveSeats(ticketTypeDTO);
            if (!reservation.Status)
            {
                _logger.LogInformation("Seats reservation is not successful");
                return BadRequest(reservation.Message);
            }
                
            return Ok($"{payment.Message} and {reservation.Message}" );
        }
    }
}
