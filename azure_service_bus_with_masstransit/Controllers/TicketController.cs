using azure_service_bus_with_masstransit.Contracts;
using azure_service_bus_with_masstransit.Requests;
using Microsoft.AspNetCore.Mvc;

namespace azure_service_bus_with_masstransit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ILogger<TicketController> _logger;
        public TicketController(ITicketService ticketService, ILogger<TicketController> logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        /// <summary>
        /// Create new ticket async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> CreateNewTicketAsync(CreateNewTicketRequest request)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            return await _ticketService.CreateNewTicketAsync(request);
        }
    }
}
