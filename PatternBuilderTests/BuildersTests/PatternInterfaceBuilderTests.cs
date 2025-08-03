using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.BuildersTests
{
    public class PatternInterfaceBuilderTests
    {
        private readonly PatternInterfaceBuilder _builder;
        private readonly PatternParameter _property;
        private readonly PatternMethod _method;

        public PatternInterfaceBuilderTests()
        {
            _builder = new PatternInterfaceBuilder();
            _property = new PatternParameter("Name");
            _method = PatternMethodBuilder.Empty;
        }

        [Fact]
        public void AddProperty_WhenCalled_AddsPropertyToInterface()
        {
            var patternInterface = _builder
                .AddProperty(_property)
                .Build();

            Assert.Contains(_property, patternInterface.Properties);
        }

        [Fact]
        public void AddMethod_WhenCalled_AddsMethodToInterface()
        {
            var patternInterface = _builder
                .AddMethod(_method)
                .Build();

            Assert.Contains(_method, patternInterface.Methods);
        }

        [Fact]
        public void RemoveProperty_WhenCalled_RemovesPropertyFromInterface()
        {
            var builder = _builder
                .AddProperty(_property)
                .RemoveProperty(_property);

            var patternInterface = builder.Build();

            Assert.DoesNotContain(_property, patternInterface.Properties);
        }

        [Fact]
        public void RemoveMethod_WhenCalled_RemovesMethodFromInterface()
        {
            var builder = _builder
                .AddMethod(_method)
                .RemoveMethod(_method);

            var patternInterface = builder.Build();

            Assert.DoesNotContain(_method, patternInterface.Methods);
        }
    }
}
