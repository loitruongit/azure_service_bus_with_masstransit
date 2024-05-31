using azure_service_bus_with_masstransit.Contracts;
using azure_service_bus_with_masstransit.Messages;

namespace azure_service_bus_with_masstransit.Implementations
{
    public class EmailService : IEmailService
    {
        public EmailService() { }

        public async Task<bool> SendMailAsync(NotificationMessage request)
        {
            //Seding Email to Admin with content and phoneNumber ..........
            //.............................................................

            return true;
        }
    }
}
