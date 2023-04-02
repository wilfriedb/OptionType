using Iridium.Types;

namespace TypesTest
{
    public class OptionTest
    {
        [Fact]
        public void Option_With_Value_Returns_Value()
        {
            // Arrange
            const string simpleType = "test";

            // Act
            var option = Option<string>.Some(simpleType);

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
            const string simpleType = null;

            // Act
            var option = Option<string>.Some(simpleType);

            // Assert
            Assert.IsType<Option<string>>(option);
            Assert.True(option.IsNone);
            Assert.False(option.IsSome);
        }

        [Fact]
        public void Option_WithOut_Value_Throws_Exception_When_Value_Is_Accessed_()
        {
            // Arrange
            const string simpleType = null;

            // Act
            var option = Option<string>.Some(simpleType);

            // Assert
            Assert.True(option.IsNone);
            Assert.Throws<NullReferenceException>(() => { var value = option.Value; });
        }

        [Fact]
        public void Option_None_Throws_Exception_When_Value_Is_Accessed_()
        {
            // Arrange
            // Nothing to arrange

            // Act
            var option = Option<string>.None();

            // Assert
            Assert.IsType<Option<string>>(option);
            Assert.True(option.IsNone);
            Assert.Throws<NullReferenceException>(() => { var value = option.Value; });
        }

        [Fact]
        public void FMap_With_Option_Some_returns_Value()
        {
            // Arrange
            var option = Option<string>.Some("Test");
            Func<string, string> function = s => s + "1";

            // Act
            var result = Option<string>.Map(option, function);

            // Assert
            Assert.IsType<Option<string>>(result);
            Assert.True(result.IsSome);
            Assert.False(result.IsNone);
            Assert.Equal("Test1", result.Value);
        }

        [Fact]
        public void FMap_With_Option_None_returns_None()
        {
            // Arrange
            var option = Option<string>.None();
            Func<string, string> function = s => s + "1";

            // Act
            var result = Option<string>.Map(option, function);

            // Assert
            Assert.IsType<Option<string>>(result);
            Assert.True(result.IsNone);
            Assert.False(result.IsSome);
        }
    }

}
