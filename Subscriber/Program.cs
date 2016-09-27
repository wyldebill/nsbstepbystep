using System;
using NServiceBus;
using NServiceBus.Logging;

class Program
{
    #region SubscriberInit
    static void Main()
    {
        Console.Title = "Samples.StepByStep.Subscriber";
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.StepByStep.Subscriber");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.EnableInstallers();
        busConfiguration.UsePersistence<InMemoryPersistence>();

        // Dear logger, shut it please.
        var defaultFactory = LogManager.Use<DefaultFactory>();
        defaultFactory.Level(LogLevel.Info);


        using (var bus = Bus.Create(busConfiguration).Start())
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    #endregion
}