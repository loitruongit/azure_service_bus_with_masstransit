using azure_service_bus_with_masstransit.Messages;

namespace azure_service_bus_with_masstransit.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(NotificationMessage request);
    }
}
