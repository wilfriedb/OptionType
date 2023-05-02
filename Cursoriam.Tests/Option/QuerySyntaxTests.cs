namespace Cursoriam.Types.Tests.OptionType;

public class QuerySyntaxTests
{
    [Fact]
    public void FMap_With_Option_Some_returns_Value()
    {
        // Arrange
        var option = new Option<string>("Test");

        // Act
        var result = from value in option select value + "1";

        // Assert
        Assert.IsType<Option<string>>(result);
        Assert.True(result.IsSome);
        Assert.Equal("Test1", result.Value);
    }

    [Fact]
    public void FMap_With_Option_None_returns_None()
    {
        // Arrange
        var option = new Option<string>();

        // Act
        var result = from value in option select value + "1";

        // Assert
        Assert.IsType<Option<string>>(result);
        Assert.True(result.IsNone);
    }
}
