using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types;

namespace TypesTest
{
    [TestClass]
    public class OptionTest
    {
        [TestMethod]
        public void Option_With_Value_Returns_Value()
        {
            // Arrange
            const string simpleType = "test";

            // Act
            var option = Option<string>.Some(simpleType);

            // Assert
            Assert.IsInstanceOfType(option, typeof(Option<string>));
            Assert.IsTrue(option.IsSome);
            Assert.IsFalse(option.IsNone);
            Assert.AreEqual(option.Value, simpleType);
        }

        [TestMethod]
        public void Option_WithOut_Value_Returns_None()
        {
            // Arrange
            const string simpleType = null;

            // Act
            var option = Option<string>.Some(simpleType);

            // Assert
            Assert.IsInstanceOfType(option, typeof(Option<string>));
            Assert.IsTrue(option.IsNone);
            Assert.IsFalse(option.IsSome);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Option_WithOut_Value_Throws_Exception_When_Value_Is_Accessed_()
        {
            // Arrange
            const string simpleType = null;

            // Act
            var option = Option<string>.Some(simpleType);

            // Assert
            Assert.IsTrue(option.IsNone);
            var value = option.Value;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Option_None_Throws_Exception_When_Value_Is_Accessed_()
        {
            // Arrange
            // Nothing to arrange

            // Act
            var option = Option<string>.None();

            // Assert
            Assert.IsInstanceOfType(option, typeof(Option<string>));
            Assert.IsTrue(option.IsNone);
            var value = option.Value;
        }

        [TestMethod]
        public void FMap_With_Option_Some_returns_Value()
        {
            // Arrange
            var option = Option<string>.Some("Test");
            Func<string, string> function = s => s + "1";

            // Act
            var result = Option<string>.Map(option, function);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Option<string>));
            Assert.IsTrue(result.IsSome);
            Assert.IsFalse(result.IsNone);
            Assert.AreEqual(result.Value, "Test1");
        }

        [TestMethod]
        public void FMap_With_Option_None_returns_None()
        {
            // Arrange
            var option = Option<string>.None();
            Func<string, string> function = s => s + "1";

            // Act
            var result = Option<string>.Map(option, function);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Option<string>));
            Assert.IsTrue(result.IsNone);
            Assert.IsFalse(result.IsSome);
        }
    }

}
