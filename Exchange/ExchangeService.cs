using Exchange.Enums;
using Exchange.Interfaces;
using Exchange.Models;

namespace Exchange;

public class ExchangeService : IExchangeService
{
    private readonly ICurrencyConverter _currencyConverter;

    public ExchangeService(ICurrencyConverter currencyConverter)
    {
        _currencyConverter = currencyConverter ?? throw new ArgumentNullException(nameof(currencyConverter));
    }

    public string Convert(string input)
    {
        string[] parts = input.Split('/', ' ');

        ValidateInputParams(parts);

        string baseCurrencyStr = parts[0];
        string targetCurrencyStr = parts[1];
        string amountStr = parts[2];
        
        var baseCurrency = (Currency)Enum.Parse(typeof(Currency), baseCurrencyStr.ToUpper());
        var targetCurrency = (Currency)Enum.Parse(typeof(Currency), targetCurrencyStr.ToUpper());
        decimal amount = decimal.Parse(amountStr);

        var pair = new CurrencyPair(baseCurrency, targetCurrency);

        decimal result = _currencyConverter.Convert(pair, amount);

        return result.ToString("0.0000");
    }

    private static void ValidateInputParams(string[] parts)
    {
        if (parts.Length < 1)
        {
            throw new ArgumentException($"baseCurrency has wrong format. example input str 'EUR/DKK 123' ");
        }

        if (parts.Length < 2)
        {
            throw new ArgumentException($"targetCurrency has wrong format. example input str 'EUR/DKK 123' ");
        }

        if (parts.Length < 3)
        {
            throw new ArgumentException($"amount has wrong format. example input str 'EUR/DKK 123' ");
        }
    }
}