namespace Cursoriam.Types.Tests.OptionType;

// https://blog.ploeh.dk/2018/03/26/the-maybe-functor/

public class FunctorLawsTests
{
    [Fact]
    public void PopulatedOptionObeysFirstFunctorLaw()
    {
        // Arrange
        static string identity(string x) => x;
        var option = new Option<string>("foo");

        // Act
        // Assert
        Assert.Equal(option, option.Select(identity));
    }

    [Fact]
    public void EmptyOptionObeysFirstFunctorLaw()
    {
        // Arrange
        static string identity(string x) => x;
        var option = new Option<string>();

        // Act
        // Assert
        Assert.Equal(option, option.Select(identity));
    }

    [Theory]
    [InlineData("odd")]
    [InlineData("even")]
    public void PopulatedOptionObeysSecondFunctorLaw(string value)
    {
        // Arrange
        static int g(string s) => s.Length;
        static bool f(int i) => i % 2 == 0;
        var option = new Option<string>(value);

        // Act
        // Assert
        Assert.Equal(option.Select(g).Select(f), option.Select(s => f(g(s))));
    }

    [Fact]
    public void EmptyOptionObeysSecondFunctorLaw()
    {
        // Arrange
        static int g(string s) => s.Length;
        static bool f(int i) => i % 2 == 0;
        var option = new Option<string>();

        // Act
        // Assert
        Assert.Equal(option.Select(g).Select(f), option.Select(s => f(g(s))));
    }
}
