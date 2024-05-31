using azure_service_bus_with_masstransit.Contracts;
using azure_service_bus_with_masstransit.Messages;
using azure_service_bus_with_masstransit.Requests;
using MassTransit;

namespace azure_service_bus_with_masstransit.Implementations
{
    public class EventService : IEventService
    {
        private readonly IBus _bus;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        private readonly ILogger<IEventService> _logger;

        public EventService(IBus bus,
            ISendEndpointProvider sendEndpointProvider,
            ILogger<IEventService> logger)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _sendEndpointProvider = sendEndpointProvider ?? throw new ArgumentNullException(nameof(sendEndpointProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Noti to admin Async
        /// </summary>
        /// <param name="request"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public async Task NotiToAdminAsync(CreateNewTicketRequest request, string queueName)
        {
            var message = new NotificationMessage
            {
                Content = request.Content,
                PhoneNumber = request.PhoneNumber
            };

            await SendToQueueAsync(message, queueName: queueName);
        }

        private async Task<bool> SendToQueueAsync<T>(T messageObject, string queueName) where T : class
        {
            try
            {
                await (await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"))).Send(messageObject);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send message to serviceBus queue ${queueName}: {ex.Message}");
                return false;
            }
        }
    }
}
