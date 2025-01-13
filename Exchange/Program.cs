using Microsoft.Extensions.DependencyInjection;

using Exchange;
using Exchange.Interfaces;

try
{
    Console.WriteLine("Hello, World and Exchange app!");

    var serviceProvider = DependencyInjectionSetup.ConfigureServices();
    var exchangeService = serviceProvider.GetService<IExchangeService>();

    Console.WriteLine("Enter conversion input:");

    var input = Console.ReadLine();

    if (input != null)
    {
        var result = exchangeService?.Convert(input);

        Console.WriteLine($"Conversion Result: {result}");
    }

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadLine();
}
