using Cursoriam.Types;

namespace TypesTests;

public class OptionTest
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
        Assert.Equal(simpleType, option.Value);
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
    }

    [Fact]
    public void Option_WithOut_Value_Throws_Exception_When_Value_Is_Accessed_()
    {
        // Arrange
        const string? simpleType = null;

        // Act
        // Assert
        Assert.Throws<NullReferenceException>(() => new Option<string>(simpleType!));
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
        Assert.Throws<NullReferenceException>(() => { var value = option.Value; });
    }

    [Fact]
    public void FMap_With_Option_Some_returns_Value()
    {
        // Arrange
        var option = new Option<string>("Test");
        static string function(string s) => s + "1";

        // Act
        var result = option.Select(function);

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
        static string function(string s) => s + "1";

        // Act
        var result = option.Select(function);

        // Assert
        Assert.IsType<Option<string>>(result);
        Assert.True(result.IsNone);
    }

    [Fact]
    public void FMap_With_Different_Types_Option_Some_returns_Value()
    {
        // Arrange
        var option = new Option<int>(42);
        static string function(int s) => s.ToString() + "test";

        // Act
        var result = option.Select(function);

        // Assert
        Assert.IsType<Option<string>>(result);
        Assert.True(result.IsSome);
        Assert.Equal("42test", result.Value);
    }

}
