using azure_service_bus_with_masstransit.Requests;

namespace azure_service_bus_with_masstransit.Contracts
{
    public interface IEventService
    {
        Task NotiToAdminAsync(CreateNewTicketRequest request, string queueName);
    }
}
