using Exchange.Models;

namespace Exchange.Interfaces;

public interface ICurrencyConverter
{
    public decimal Convert(CurrencyPair pair, decimal amount);
}