using Exchange;
using Exchange.Enums;
using Exchange.Models;

namespace ExchangeUnitTests;

public class CurrencyConverterTests
{
    [Fact]
    public void Convert_WithValidInput_Succeeds()
    {
        // Arrange
        var currencyProvider = new HardcodedCurrencyProvider();
        var currencyConverter = new CurrencyConverter(currencyProvider);

        var pair = new CurrencyPair(Currency.EUR, Currency.DKK);

        // Act
        decimal result = currencyConverter.Convert(pair, 100);

        // Assert
        Assert.Equal(743.94m, result);
    }
}