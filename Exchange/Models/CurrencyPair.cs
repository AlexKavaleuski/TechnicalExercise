using Exchange.Enums;

namespace Exchange.Models;

public class CurrencyPair
{
    public Currency MainCurrency { get; }

    public Currency MoneyCurrency { get; }

    public CurrencyPair(Currency main, Currency money)
    {
        MainCurrency = main;
        MoneyCurrency = money;
    }
}