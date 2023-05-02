namespace Cursoriam.Types.Tests.NullableTests;

public class QuerySyntaxTests
{
    [Fact]
    public void NullablesWithValue_returns_Value()
    {
        // Arrange
        int? one = 1;
        int? two = 2;

        // Act
        var result =
            from value in one
            from value2 in two
            select value + value2;

        // Assert
        Assert.IsType<int>(result); // The runtime does explicit unboxing
        Assert.True(result.HasValue);
        Assert.Equal(3, result.Value);
    }

    [Fact]
    public void NullablesWithOneNullValue_returns_Null()
    {
        // Arrange
        int? one = 1;
        int? two = null;

        // Act
        var result =
            from value in one
            from value2 in two
            select value + value2;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void NullablesWithDifferentTypesAndValue_returns_Value()
    {
        // Arrange
        int? one = 1;
        double? two = 2.0;

        // Act
        var result =
            from value in one
            from value2 in two
            select value + value2;

        // Assert
        Assert.IsType<double>(result);
        Assert.True(result.HasValue);
        Assert.Equal(3.0, result.Value);
    }

    [Fact]
    public void NullablesWithValueTypeAndReferenceType_returns_Value()
    {
        // Arrange
        int? one = 1;
        string? two = "2";

        // Act
        var result =
            from value in one
            from value2 in two
            select value + value2;

        // Assert
        Assert.IsType<string>(result);
        Assert.True(result.HasValue);
        Assert.Equal("", result.Value);
    }
}
}
