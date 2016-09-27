using System;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

#region PlaceOrderHandler

public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{

    #region intialize bus
    static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
    IBus bus;

    public PlaceOrderHandler(IBus bus)
    {
        this.bus = bus;
    }
    #endregion

    public void Handle(PlaceOrder message)
    {
        Console.WriteLine($"PlaceOrder Hanlder: Processing order COMMAND with id: {message.Id}");


        // fire off the OrderPlaced event now
        var orderPlaced = new OrderPlaced
        {
            OrderId = message.Id
        };

        Console.WriteLine($"PlaceOrder Handler: Notifying Subscribers of OrderPlaced EVENT for Order Id: {message.Id}");

        bus.Publish(orderPlaced);
    }
}

#endregion
