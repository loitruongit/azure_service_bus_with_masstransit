using azure_service_bus_with_masstransit.Contracts;
using azure_service_bus_with_masstransit.Messages;
using MassTransit;

namespace azure_service_bus_with_masstransit.Consumers
{
    public class NotificationConsumer : IConsumer<NotificationMessage>
    {
        private readonly IEmailService _emailService;
        public NotificationConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Consume(ConsumeContext<NotificationMessage> consumeContext)
        {
            //Audit log..........................
            //...................................

            var message = consumeContext.Message;
            await _emailService.SendMailAsync(message);
        }
    }
}
