using System;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

#region OrderCreatedHandler
public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
{
    static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

    public void Handle(OrderPlaced message)
    {
        Console.WriteLine($"OrderPlaced Handler: OrderPlaced EVENT received for Order Id: {message.OrderId}");
    }
}
#endregion