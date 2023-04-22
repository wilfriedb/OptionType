namespace Cursoriam.Types.Tests.OptionType;

// https://blog.ploeh.dk/2022/04/25/the-maybe-monad/

public class MonadLawsTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void OptionObeysLeftIdentityLaw(int value)
    {
        // Arrange
        static Option<double> reciprocal(int i) =>
            i != 0 ? new Option<double>(1.0 / i) : new Option<double>();

        // Act
        // Assert
        Assert.Equal(reciprocal(value), new Option<int>(value).SelectMany(reciprocal));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void OptionObeysRightIdentityLaw(int value)
    {
        // Arrange
        static Option<double> reciprocal(int i) =>
            i != 0 ? new Option<double>(1.0 / i) : new Option<double>();

        // Act
        // Assert
        Assert.Equal(reciprocal(value), reciprocal(value).SelectMany(i => new Option<double>(i)));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void OptionObeysAssociativityLaw(int value)
    {
        // Arrange
        static Option<double> reciprocal(int i) =>
            i != 0 ? new Option<double>(1.0 / i) : new Option<double>();
        static Option<double> sqrt(double d) => Sqrt(d);
        static Option<string> toString(double d) => new(d.ToString());
        
        // Act
        // Assert
        Assert.Equal(reciprocal(value).SelectMany(sqrt).SelectMany(toString),
            reciprocal(value).SelectMany(r => sqrt(r).SelectMany(toString)));
    }

    private static Option<double> Sqrt(double d)
    {
        var result = Math.Sqrt(d);
        return result switch
        {
            double.NaN or double.PositiveInfinity => new Option<double>(),
            _ => new Option<double>(result),
        };
    }
}
