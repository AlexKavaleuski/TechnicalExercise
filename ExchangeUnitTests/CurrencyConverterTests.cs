using Exchange;
using Exchange.Enums;
using Exchange.Interfaces;
using Exchange.Models;
using Moq;

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

    [Fact]
    public void Convert_WithValidInput_Succeeds_WithMock()
    {
        // Arrange
        var mockProvider = new Mock<ICurrencyProvider>();
        mockProvider
            .Setup(p => p.GetExchangeRate(It.IsAny<CurrencyPair>()))
            .Returns(7.4394m);

        var currencyConverter = new CurrencyConverter(mockProvider.Object);
        var pair = new CurrencyPair(Currency.EUR, Currency.DKK);

        // Act
        decimal result = currencyConverter.Convert(pair, 100);

        // Assert
        Assert.Equal(743.94m, result);
    }
}