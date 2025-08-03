using PatternBuilder.Core.Exceptions;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilderTests.ValidationTests
{
    public class PatternValidatorTests
    {
        private sealed class Dummy : IPatternPrimitive
        {
            public string Name { get; set; } = "TestName";
            public static string SystemName => "DummySystem";
            public string UniqueKey { get; set; } = "unique-key";
            public static string DefaultName => "DummyDefault";
        }

        [Fact]
        public void ThrowIfNullArgument_WhenCalledWithNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                PatternValidator.ThrowIfNullArgument(null, "myParam"));

            Assert.Equal("myParam cannot be null. (Parameter 'myParam')", ex.Message);
        }

        [Fact]
        public void ThrowIfNullArgument_WhenCalledWithNonNull_DoesNotThrow()
        {
            PatternValidator.ThrowIfNullArgument("not null", "myParam");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ThrowIfNullOrWhiteSpace_WhenCalledWithNullOrWhiteSpace_ThrowsArgumentException(string input)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                PatternValidator.ThrowIfNullOrWhiteSpace(input, "valueName"));

            Assert.Equal("valueName cannot be null or whitespace. (Parameter 'valueName')", ex.Message);
        }

        [Fact]
        public void ThrowIfNullOrWhiteSpace_WhenCalledWithValidValue_DoesNotThrow()
        {
            PatternValidator.ThrowIfNullOrWhiteSpace("something", "valueName");
        }

        [Fact]
        public void ValidateUniquePatternPrimitive_WhenDuplicateWithFallbackSystemName_ThrowsDuplicateElementException()
        {
            var existing = new Dummy { UniqueKey = "dup", Name = "Name1" };
            var primitives = new Dictionary<string, Dummy> { { existing.UniqueKey, existing } };

            var duplicate = new Dummy { UniqueKey = "dup", Name = "Name1" };

            var ex = Assert.Throws<DuplicateElementException>(() =>
                PatternValidator.ValidateUniquePatternPrimitive(primitives, duplicate, "myContainer"));

            Assert.Equal("DummySystem 'Name1' already exists in the myContainer.", ex.Message);
        }

        [Fact]
        public void ValidateUniquePatternPrimitive_WhenDuplicateWithCustomParameterName_ThrowsDuplicateElementException()
        {
            var existing = new Dummy { UniqueKey = "dup", Name = "Name1" };
            var primitives = new Dictionary<string, Dummy> { { existing.UniqueKey, existing } };

            var duplicate = new Dummy { UniqueKey = "dup", Name = "Name1" };

            var ex = Assert.Throws<DuplicateElementException>(() =>
                PatternValidator.ValidateUniquePatternPrimitive(primitives, duplicate, "myContainer", "CustomParam"));

            Assert.Equal("CustomParam 'Name1' already exists in the myContainer.", ex.Message);
        }

        [Fact]
        public void ValidateUniquePatternPrimitive_WhenUnique_DoesNotThrow()
        {
            var primitives = new Dictionary<string, Dummy>();
            var newItem = new Dummy { UniqueKey = "key1", Name = "Name1" };

            PatternValidator.ValidateUniquePatternPrimitive(primitives, newItem, "myContainer");
        }
    }
}
