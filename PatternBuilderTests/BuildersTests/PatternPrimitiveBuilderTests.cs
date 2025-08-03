using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.BuildersTests
{
    public class PatternPrimitiveBuilderTests
    {
        private readonly PatternPrimitiveBuilder _builder;
        private readonly PatternClass _emptyClass;
        private readonly PatternInterface _emptyInterface;

        public PatternPrimitiveBuilderTests()
        {
            _builder = new PatternPrimitiveBuilder();
            _emptyClass = PatternClassBuilder.Empty;
            _emptyInterface = PatternInterfaceBuilder.Empty;
        }

        [Fact]
        public void AddClass_WhenCalled_AddsClassToPattern()
        {
            var pattern = _builder
                .AddClass(_emptyClass)
                .Build();

            Assert.Contains(_emptyClass, pattern.Classes);
        }

        [Fact]
        public void AddInterface_WhenCalled_AddsInterfaceToPattern()
        {
            var pattern = _builder
                .AddInterface(_emptyInterface)
                .Build();

            Assert.Contains(_emptyInterface, pattern.Interfaces);
        }

        [Fact]
        public void RemoveClass_WhenCalled_RemovesClassFromPattern()
        {
            var builder = _builder
                .AddClass(_emptyClass)
                .RemoveClass(_emptyClass);

            var pattern = _builder.Build();

            Assert.DoesNotContain(_emptyClass, pattern.Classes);
        }

        [Fact]
        public void RemoveInterface_WhenCalled_RemovesInterfaceFromPattern()
        {
            var builder = _builder
                .AddInterface(_emptyInterface)
                .RemoveInterface(_emptyInterface);

            var pattern = _builder.Build();

            Assert.DoesNotContain(_emptyInterface, pattern.Interfaces);
        }
    }
}
