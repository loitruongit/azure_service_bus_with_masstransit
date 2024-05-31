using azure_service_bus_with_masstransit.Requests;

namespace azure_service_bus_with_masstransit.Contracts
{
    public interface ITicketService
    {
        Task<bool> CreateNewTicketAsync(CreateNewTicketRequest request);
    }
}
