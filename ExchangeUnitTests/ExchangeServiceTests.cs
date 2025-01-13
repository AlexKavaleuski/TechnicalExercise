using Exchange;
using Exchange.Interfaces;
using Moq;

namespace ExchangeUnitTests;

public class ExchangeServiceTests
{
    [Theory]
    [InlineData("EUR/DKK 1", "7.4394")]
    [InlineData("EUR/DKK 2", "14.8788")]
    [InlineData("USD/DKK 1", "6.6311")]
    [InlineData("USD/DKK 100", "663.1100")]
    [InlineData("DKK/USD 663", "99.9834")]
    [InlineData("USD/EUR 1", "1.1219")]
    [InlineData("EUR/USD 1", "0.8913")]
    public void Convert_WithValidInput_Succeeds(string inputStr, string expectedOutput)
    {
        // Arrange
        var currencyProvider = new HardcodedCurrencyProvider();
        var currencyConverter = new CurrencyConverter(currencyProvider);
        var exchangeService = new ExchangeService(currencyConverter);

        // Act
        var result = exchangeService.Convert(inputStr);

        // Assert
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData("EII/DKK 1")]
    [InlineData("EUR/DKb 3")]
    [InlineData("USDDKK 1")]
    [InlineData("USD/DKK")]
    [InlineData("EUR/TRL 1")]
    public void Convert_InvalidRequestExceptionThrown_ArgumentException(string inputStr)
    {
        // Arrange
        var currencyConverter = new Mock<ICurrencyConverter>();
        var exchangeService = new ExchangeService(currencyConverter.Object);

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => exchangeService.Convert(inputStr));
    }
}