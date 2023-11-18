namespace Cursoriam.Types.Tests.OptionType;

public class OptionTests
{
    [Fact]
    public void Option_With_Value_Returns_Value()
    {
        // Arrange
        const string simpleType = "test";

        // Act
        var option = new Option<string>(simpleType);

        // Assert
        Assert.IsType<Option<string>>(option);
        Assert.True(option.IsSome);
        Assert.False(option.IsNone);
        option.Select(v => { Assert.Equal(simpleType, v); return v; });
        Assert.True(option.Any());
    }

    [Fact]
    public void Option_WithOut_Value_Returns_None()
    {
        // Arrange

        // Act
        var option = new Option<string>();

        // Assert
        Assert.IsType<Option<string>>(option);
        Assert.True(option.IsNone);
        Assert.False(option.IsSome);
        Assert.False(option.Any());
    }

    [Fact]
    public void Option_WithOut_Value_Throws_Exception_When_Option_Is_Created_()
    {
        // Arrange
        const string? simpleType = null;

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Option<string>(simpleType!));
    }

    [Fact]
    public void Option_None_Throws_Exception_When_Value_Is_Accessed_()
    {
        // Arrange
        // Act
        var option = new Option<string>();

        // Assert
        Assert.IsType<Option<string>>(option);
        Assert.True(option.IsNone);
        option.Select(v=> { Assert.Fail("This code should not be reached."); return v; });
    }

    [Fact]
    public void Map_With_Option_Some_returns_Value()
    {
        // Arrange
        var option = new Option<string>("Test");
        static string function(string s) => s + "1";

        // Act
        var result = option.Select(function);

        // Assert
        Assert.IsType<Option<string>>(result);
        Assert.True(result.IsSome);
        result.Select(v => { Assert.Equal("Test1", v); return v; });
    }

    [Fact]
    public void Map_With_Option_None_returns_None()
    {
        // Arrange
        var option = new Option<string>();
        static string function(string s) => s + "1";

        // Act
        var result = option.Select(function);

        // Assert
        Assert.IsType<Option<string>>(result);
        Assert.True(result.IsNone);
    }

    [Fact]
    public void Map_With_Different_Types_Option_Some_returns_Value()
    {
        // Arrange
        var option = new Option<int>(42);
        static string function(int s) => s.ToString() + "test";

        // Act
        var result = option.Select(function);

        // Assert
        Assert.IsType<Option<string>>(result);
        Assert.True(result.IsSome);
        result.Select(v => { Assert.Equal("42test", v); return v; });
    }

}
