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
        public void ThrowIfNullArgument_Throws_WhenNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                PatternValidator.ThrowIfNullArgument(null, "myParam"));

            Assert.Equal("myParam cannot be null. (Parameter 'myParam')", ex.Message);
        }

        [Fact]
        public void ThrowIfNullArgument_DoesNotThrow_WhenNotNull()
        {
            PatternValidator.ThrowIfNullArgument("not null", "myParam");
            // No exception expected
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ThrowIfNullOrWhiteSpace_Throws(string input)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                PatternValidator.ThrowIfNullOrWhiteSpace(input, "valueName"));

            Assert.Equal("valueName cannot be null or whitespace. (Parameter 'valueName')", ex.Message);
        }

        [Fact]
        public void ThrowIfNullOrWhiteSpace_DoesNotThrow_WhenValid()
        {
            PatternValidator.ThrowIfNullOrWhiteSpace("something", "valueName");
            // No exception expected
        }

        [Fact]
        public void ValidateUniquePatternPrimitive_Throws_WhenDuplicate_FallbackSystemName()
        {
            var existing = new Dummy { UniqueKey = "dup", Name = "Name1" };
            var primitives = new Dictionary<string, Dummy> { { existing.UniqueKey, existing } };

            var duplicate = new Dummy { UniqueKey = "dup", Name = "Name1" };

            var ex = Assert.Throws<DuplicateElementException>(() =>
                PatternValidator.ValidateUniquePatternPrimitive(primitives, duplicate, "myContainer"));

            Assert.Equal("DummySystem 'Name1' already exists in the myContainer.", ex.Message);
        }

        [Fact]
        public void ValidateUniquePatternPrimitive_Throws_WhenDuplicate_CustomParameterName()
        {
            var existing = new Dummy { UniqueKey = "dup", Name = "Name1" };
            var primitives = new Dictionary<string, Dummy> { { existing.UniqueKey, existing } };

            var duplicate = new Dummy { UniqueKey = "dup", Name = "Name1" };

            var ex = Assert.Throws<DuplicateElementException>(() =>
                PatternValidator.ValidateUniquePatternPrimitive(primitives, duplicate, "myContainer", "CustomParam"));

            Assert.Equal("CustomParam 'Name1' already exists in the myContainer.", ex.Message);
        }

        [Fact]
        public void ValidateUniquePatternPrimitive_DoesNotThrow_WhenUnique()
        {
            var primitives = new Dictionary<string, Dummy>();
            var newItem = new Dummy { UniqueKey = "key1", Name = "Name1" };

            PatternValidator.ValidateUniquePatternPrimitive(primitives, newItem, "myContainer");
            // No exception expected
        }
    }
}
