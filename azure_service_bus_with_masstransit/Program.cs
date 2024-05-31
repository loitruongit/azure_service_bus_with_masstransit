using Azure.Messaging.ServiceBus;
using azure_service_bus_with_masstransit.Common;
using azure_service_bus_with_masstransit.Consumers;
using azure_service_bus_with_masstransit.Contracts;
using azure_service_bus_with_masstransit.Implementations;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IEmailService, EmailService>();

//Add message
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumers(Assembly.GetExecutingAssembly());

    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(builder.Configuration["AzureServiceBusSettings:ConnectionString"],
            h =>
            {
                h.TransportType = ServiceBusTransportType.AmqpWebSockets;
            });

        cfg.ReceiveEndpoint(Queues.CMSNewTicket, e =>
        {
            e.ConfigureConsumer<NotificationConsumer>(context);
        });

        cfg.EnableDuplicateDetection(TimeSpan.FromMinutes(5));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
