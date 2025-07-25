using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using System.Reflection;

namespace PatternBuilder.Tests.BuildersTests
{
    public class PatternPrimitiveBuilderBaseTests
    {
        private readonly DummyPatternPrimitiveBuilder _builder;

        public PatternPrimitiveBuilderBaseTests()
        {
            _builder = new DummyPatternPrimitiveBuilder();
        }

        public static IEnumerable<object[]> GetBuildersTypes()
        {
            return Assembly
                .GetAssembly(typeof(PatternPrimitiveBuilderBase<,>))!
                .GetTypes()
                .Where(t =>
                    !t.IsAbstract &&
                    t.BaseType is { IsGenericType: true } &&
                    t.BaseType.GetGenericTypeDefinition() == typeof(PatternPrimitiveBuilderBase<,>))
                .Select(t => new object[] { t });
        }

        [Theory]
        [MemberData(nameof(GetBuildersTypes))]
        public void Empty_Sets_DefaultName_ForAllBuilders(Type builderType)
        {
            Type baseGenericType = builderType.BaseType!;
            Type primitiveType = builderType.BaseType!.GetGenericArguments()[1];

            var defaultNameProp = primitiveType.GetProperty(nameof(IPatternPrimitive.DefaultName), BindingFlags.Static | BindingFlags.Public);
            Assert.NotNull(defaultNameProp);

            var expectedName = (string)defaultNameProp.GetValue(null)!;

            var emptyProp = baseGenericType.GetProperty(nameof(DummyPatternPrimitiveBuilder.Empty), BindingFlags.Static | BindingFlags.Public);
            Assert.NotNull(emptyProp);

            var emptyInstance = (IPatternPrimitive)emptyProp.GetValue(null)!;

            Assert.Equal(expectedName, emptyInstance.Name);
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
        public void SetName_NullOrWhiteSpace_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => _builder.SetName(name));
        }

        [Fact]
        public void Build_ReturnsCurrentValue()
        {
            _builder.SetName("CustomName");

            var result = _builder.Build();

            Assert.Equal("CustomName", result.Name);
        }

        [Fact]
        public void Clear_SetsToEmpty()
        {
            _builder.SetName("TempName");

            _builder.Clear();
            var result = _builder.Build();

            Assert.Equal("DummyDefaultName", result.Name);
        }

        [Fact]
        public void Build_ReturnsSameReferenceIfUnchanged()
        {
            var result1 = _builder.Build();
            var result2 = _builder.Build();

            Assert.Same(result1, result2);
        }
    }
}
