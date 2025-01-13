using Exchange.Models;

namespace Exchange.Interfaces;

public interface ICurrencyProvider
{
    decimal GetExchangeRate(CurrencyPair pair);
}