using Exchange.Enums;
using Exchange.Interfaces;
using Exchange.Models;

namespace Exchange;

public class HardcodedCurrencyProvider : ICurrencyProvider
{
    private readonly Dictionary<Currency, decimal> dkkRates = new()
    {
        { Currency.EUR, 743.94m },
        { Currency.USD, 663.11m },
        { Currency.GBP, 852.85m },
        { Currency.SEK, 76.10m },
        { Currency.NOK, 78.40m },
        { Currency.CHF, 683.58m },
        { Currency.JPY, 5.9740m }
    };

    public decimal GetExchangeRate(CurrencyPair pair)
    {
        if (pair.MainCurrency == pair.MoneyCurrency)
            return 1.0m;

        if (pair.MoneyCurrency == Currency.DKK)
            return dkkRates[pair.MainCurrency] / 100;

        if (pair.MainCurrency == Currency.DKK)
            return 100 / dkkRates[pair.MoneyCurrency];

        if (dkkRates.ContainsKey(pair.MainCurrency) && dkkRates.ContainsKey(pair.MoneyCurrency))
        {
            decimal rateToDKKFromMain = dkkRates[pair.MainCurrency];
            decimal rateToDKKFromMoney = dkkRates[pair.MoneyCurrency];

            return rateToDKKFromMoney / rateToDKKFromMain;
        }

        throw new NotSupportedException($"Exchange rate for {pair.MainCurrency}/{pair.MoneyCurrency} not supported.");
    }
}