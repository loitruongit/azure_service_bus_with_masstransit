using azure_service_bus_with_masstransit.Common;
using azure_service_bus_with_masstransit.Contracts;
using azure_service_bus_with_masstransit.Requests;

namespace azure_service_bus_with_masstransit.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly IEventService _eventService;
        public TicketService(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<bool> CreateNewTicketAsync(CreateNewTicketRequest request)
        {
            //Todo Sth..................
            //..........................
            //..........................
            //..........................

            //Send Message [CMSNewTicket]
            await _eventService.NotiToAdminAsync(request, Queues.CMSNewTicket);

            return true;
        }
    }
}
