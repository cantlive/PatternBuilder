using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.BuildersTests
{
    public class PatternPrimitiveBuilderBaseTests
    {
        private readonly DummyPatternPrimitiveBuilder _builder;

        public PatternPrimitiveBuilderBaseTests()
        {
            _builder = new DummyPatternPrimitiveBuilder();
        }

        private sealed class DummyPatternPrimitive : PatternPrimitiveBase, IPatternPrimitive
        {
            public static string SystemName => "DummySystemName";

            public static string DefaultName => "DummyDefaultName";

            public DummyPatternPrimitive(string name) : base(name) { }
        }

        private sealed class DummyPatternPrimitiveBuilder : PatternPrimitiveBuilderBase<DummyPatternPrimitiveBuilder, DummyPatternPrimitive>
        {

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void SetName_WhenNullOrWhiteSpace_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => _builder.SetName(name));
        }

        [Fact]
        public void Empty_WhenAccessed_SetsDefaultName()
        {
            Assert.Equal(DummyPatternPrimitive.DefaultName, DummyPatternPrimitiveBuilder.Empty.Name);
        }

        [Fact]
        public void Build_WhenCalled_ReturnsCurrentValue()
        {
            _builder.SetName("CustomName");

            var result = _builder.Build();

            Assert.Equal("CustomName", result.Name);
        }

        [Fact]
        public void Clear_WhenCalled_SetsToEmpty()
        {
            _builder.SetName("TempName");
            _builder.Clear();

            var result = _builder.Build();

            Assert.Equal("DummyDefaultName", result.Name);
        }

        [Fact]
        public void Build_WhenUnchanged_ReturnsSameReference()
        {
            var result1 = _builder.Build();
            var result2 = _builder.Build();

            Assert.Same(result1, result2);
        }
    }
}
