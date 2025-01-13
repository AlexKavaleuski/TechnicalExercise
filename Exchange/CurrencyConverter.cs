using Exchange.Interfaces;
using Exchange.Models;

namespace Exchange;

public class CurrencyConverter : ICurrencyConverter
{
    private readonly ICurrencyProvider _provider;

    public CurrencyConverter(ICurrencyProvider provider)
    {
        _provider = provider;
    }

    public decimal Convert(CurrencyPair pair, decimal amount)
    {
        var rate = _provider.GetExchangeRate(pair);

        return amount * rate;
    }
}