using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Tests.CodeGenerationTests
{
    public class PatternPrimitiveCodeGeneratorBaseTests
    {
        private sealed class DummyPatternPrimitive : IPatternPrimitive
        {
            public static string SystemName => "PrimitiveName";

            public static string DefaultName => "DefaultName";

            public string Name => throw new NotImplementedException();

            public string UniqueKey => throw new NotImplementedException();
        }

        private sealed class DummyPatternPrimitiveCodeGenerator : PatternPrimitiveCodeGeneratorBase<DummyPatternPrimitive>
        {
            internal override string InternalGenerate(DummyPatternPrimitive patternPrimitive) => string.Empty;
        }

        [Fact]
        public void Generate_Throws_If_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new DummyPatternPrimitiveCodeGenerator().Generate(null));
            Assert.Equal("PrimitiveName cannot be null. (Parameter 'PrimitiveName')", ex.Message);
        }
    }
}
