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
        Assert.IsType<int>(result); // Int, The runtime does explicit unboxing
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
    public void NullablesWithCompareTo_returns_Value()
    {
        // Arrange
        int? one = 1;
        int? two = 2;

        // Act
        var result =
            from value in one
            from value2 in two
            select value.CompareTo(value2);

        // Assert
        Assert.IsType<int>(result);
        Assert.True(result.HasValue);
        Assert.Equal(-1, result.Value);
    }

    [Fact]
    public void NullablesWithNullCompareTo_returns_Null()
    {
        // Arrange
        int? one = null;
        int? two = 2;

        // one.Value.CompareTo(two); // Nullable value type may be null.

        // Act
        var result =
            from value in one
            from value2 in two
            select value.CompareTo(value2);

        // Assert
        Assert.Null(result);
    }

   [Fact]
    public void NullablesWithBothNullCompareTo_returns_Null()
    {
        // Arrange
        int? one = null;
        int? two = null;

        // one.Value.CompareTo(two); // Nullable value type may be null.

        // Act
        var result =
            from value in one
            from value2 in two
            select value.CompareTo(value2);

        // Assert
        Assert.Null(result);
    }
}
