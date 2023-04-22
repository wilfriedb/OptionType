namespace Cursoriam.Types.Tests.WriterType;
// https://blog.ploeh.dk/2018/03/26/the-maybe-functor/

public class FunctorLawsTests
{
    [Fact]
    public void WriterObeysFirstFunctorLaw()
    {
        // Arrange
        static string identity(string x) => x;
        var writer = new StringWriter<string>("foo");

        // Act
        // Assert
        Assert.Equal(writer, writer.Select(identity));
    }

    [Theory]
    [InlineData("odd")]
    [InlineData("even")]
    public void PopulatedOptionObeysSecondFunctorLaw(string value)
    {
        // Arrange
        static int g(string s) => s.Length;
        static bool f(int i) => i % 2 == 0;
        var writer = new StringWriter<string>(value);

        // Act
        // Assert
        Assert.Equal(writer.Select(g).Select(f), writer.Select(s => f(g(s))));
    }

    //    static StringWriter<int> g(string s) => new(s.Length, "length");
    //     static StringWriter<bool> f(int i) => new(i % 2 == 0, "even");
    //     var writer = new StringWriter<string>(value);

    //     // Act
    //     // Assert
    //     Assert.Equal(writer.Select(g).Select(f), writer.Select(s => f(g(s))));
 
 
}
