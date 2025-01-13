using Exchange.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Exchange
{
    public static class DependencyInjectionSetup
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICurrencyProvider, HardcodedCurrencyProvider>();
            services.AddSingleton<ICurrencyConverter, CurrencyConverter>();
            services.AddSingleton<IExchangeService, ExchangeService>();

            return services.BuildServiceProvider();
        }
    }
}
