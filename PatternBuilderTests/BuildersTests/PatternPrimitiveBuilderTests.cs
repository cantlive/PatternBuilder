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
        public void AddClass_Adds_Class_To_Pattern()
        {
            var pattern = _builder
                .AddClass(_emptyClass)
                .Build();

            Assert.Contains(_emptyClass, pattern.Classes);
        }

        [Fact]
        public void AddInterface_Adds_Interface_To_Pattern()
        {
            var pattern = _builder
                .AddInterface(_emptyInterface)
                .Build();

            Assert.Contains(_emptyInterface, pattern.Interfaces);
        }

        [Fact]
        public void RemoveClass_Removes_Class_From_Pattern()
        {
            var builder = _builder
                .AddClass(_emptyClass)
                .RemoveClass(_emptyClass);

            var pattern = _builder.Build();

            Assert.DoesNotContain(_emptyClass, pattern.Classes);
        }

        [Fact]
        public void RemoveInterface_Removes_Interface_From_Pattern()
        {
            var builder = _builder
                .AddInterface(_emptyInterface)
                .RemoveInterface(_emptyInterface);

            var pattern = _builder.Build();

            Assert.DoesNotContain(_emptyInterface, pattern.Interfaces);
        }
    }
}
