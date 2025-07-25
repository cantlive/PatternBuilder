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
        public void AddProperty_Adds_Property_To_Interface()
        {
            var patternInterface = _builder
                .AddProperty(_property)
                .Build();

            Assert.Contains(_property, patternInterface.Properties);
        }

        [Fact]
        public void AddMethod_Adds_Method_To_Interface()
        {
            var patternInterface = _builder
                .AddMethod(_method)
                .Build();

            Assert.Contains(_method, patternInterface.Methods);
        }

        [Fact]
        public void RemoveProperty_Removes_Property_From_Interface()
        {
            var builder = _builder
                .AddProperty(_property)
                .RemoveProperty(_property);

            var patternInterface = builder.Build();

            Assert.DoesNotContain(_property, patternInterface.Properties);
        }

        [Fact]
        public void RemoveMethod_Removes_Method_From_Interface()
        {
            var builder = _builder
                .AddMethod(_method)
                .RemoveMethod(_method);

            var patternInterface = builder.Build();

            Assert.DoesNotContain(_method, patternInterface.Methods);
        }
    }
}
