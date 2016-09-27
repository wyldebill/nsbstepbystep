using System;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

class Program
{
    #region ClientInit
    static void Main()
    {
        #region setup the bus configuration

        // This makes it easier to tell console windows apart
        Console.Title = "Samples.StepByStep.Client";

        var busConfiguration = new BusConfiguration();

        // The endpoint name will be used to determine queue names and serves
        // as the address, or identity, of the endpoint
        busConfiguration.EndpointName("Samples.StepByStep.Client");

        // Use JSON to serialize and deserialize messages (which are just
        // plain classes) to and from message queues
        busConfiguration.UseSerialization<JsonSerializer>();

        // Ask NServiceBus to automatically create message queues
        busConfiguration.EnableInstallers();

        // Store information in memory for this example, rather than in
        // a database. In this sample, only subscription information is stored
        busConfiguration.UsePersistence<InMemoryPersistence>();

        var defaultFactory = LogManager.Use<DefaultFactory>();
        defaultFactory.Level(LogLevel.Fatal);

        // Initialize the endpoint with the finished configuration
        using (var bus = Bus.Create(busConfiguration).Start())
        {
           SendOrder(bus);
        }

        #endregion
    }
    #endregion


    #region SendOrder
    static void SendOrder(IBus bus)
    {
        Console.WriteLine("Press enter to send a message");
        Console.WriteLine("Press any key to exit");

        while (true)
        {
            var entry = Console.ReadLine();
            

            if (entry.Equals("q"))
            {
                return;
            }

            var id = Guid.NewGuid();
            var placeOrder = new PlaceOrder
            {
                Id = id
            };


            bus.Send("Samples.StepByStep.Server", placeOrder);
            Console.WriteLine($"Sent a PlaceOrder COMMAND with id: {id:N}");
        }
    }
    #endregion
}
