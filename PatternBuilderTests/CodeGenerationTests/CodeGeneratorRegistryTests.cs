using PatternBuilder.CodeGeneration.CodeGenerators;
using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.CodeGenerationTests
{
    public class CodeGeneratorRegistryTests
    {
        private class DummyPrimitive : IPatternPrimitive
        {
            public static string SystemName => nameof(SystemName);

            public static string DefaultName => nameof(DefaultName);

            public string Name => nameof(Name);

            public string UniqueKey => nameof(UniqueKey);
        }

        private class DummyGenerator : PatternPrimitiveCodeGeneratorBase<DummyPrimitive>
        {
            internal override PatternLanguages Language => PatternLanguages.Any;

            internal override string InternalGenerate(DummyPrimitive patternPrimitive) => "dummy code";
        }

        [Fact]
        public void RegisterGenerator_WhenGeneratorIsNull_ThrowsArgumentNullException()
        {
            CodeGeneratorRegistry.Clear();
            Assert.Throws<ArgumentNullException>(() => CodeGeneratorRegistry.RegisterGenerator<DummyPrimitive>(null));
        }

        [Fact]
        public void RegisterGenerator_WhenCalled_AllowsRetrievalByType()
        {
            var generator = new DummyGenerator();

            CodeGeneratorRegistry.Clear();
            CodeGeneratorRegistry.RegisterGenerator(generator);

            var result = CodeGeneratorRegistry.GetGenerator<DummyPrimitive>(generator.Language);

            Assert.Same(generator, result);
            CodeGeneratorRegistry.Clear();
        }

        [Fact]
        public void RegisterGenerator_WhenCalledTwice_ReplacesExistingGenerator()
        {
            var first = new DummyGenerator();
            var second = new DummyGenerator();

            CodeGeneratorRegistry.Clear();
            CodeGeneratorRegistry.RegisterGenerator(first);
            CodeGeneratorRegistry.RegisterGenerator(second);

            var result = CodeGeneratorRegistry.GetGenerator<DummyPrimitive>(second.Language);

            Assert.Same(second, result);
            CodeGeneratorRegistry.Clear();
        }

        [Fact]
        public void GetGenerator_WhenTypeNotRegistered_ThrowsKeyNotFoundException()
        {
            CodeGeneratorRegistry.Clear();
            Assert.Throws<KeyNotFoundException>(() => CodeGeneratorRegistry.GetGenerator<DummyPrimitive>(PatternLanguages.Any));
        }
    }
}
