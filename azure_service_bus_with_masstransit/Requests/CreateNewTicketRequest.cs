namespace azure_service_bus_with_masstransit.Requests
{
    public class CreateNewTicketRequest
    {
        public string Content { get; set; }

        public string PhoneNumber { get; set; }
    }
}