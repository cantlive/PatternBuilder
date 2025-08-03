using PatternBuilder.CodeGeneration.CodeGeneratorsBase;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Tests.CodeGenerationTests
{
    public class CodeGeneratorRegistryTests
    {
        private readonly CodeGeneratorRegistry _registry;

        public CodeGeneratorRegistryTests()
        {
            _registry = new CodeGeneratorRegistry();
        }

        private class DummyPrimitive : IPatternPrimitive
        {
            public static string SystemName => throw new NotImplementedException();

            public static string DefaultName => throw new NotImplementedException();

            public string Name => throw new NotImplementedException();

            public string UniqueKey => throw new NotImplementedException();
        }

        private class DummyGenerator : PatternPrimitiveCodeGeneratorBase<DummyPrimitive>
        {
            internal override string InternalGenerate(DummyPrimitive patternPrimitive) => "dummy code";
        }

        [Fact]
        public void RegisterGenerator_WhenGeneratorIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _registry.RegisterGenerator<DummyPrimitive>(null));
        }

        [Fact]
        public void RegisterGenerator_WhenCalled_AllowsRetrievalByType()
        {
            var generator = new DummyGenerator();

            _registry.RegisterGenerator(generator);

            var result = _registry.GetGenerator<DummyPrimitive>();

            Assert.Same(generator, result);
        }

        [Fact]
        public void RegisterGenerator_WhenCalledTwice_ReplacesExistingGenerator()
        {
            var first = new DummyGenerator();
            var second = new DummyGenerator();

            _registry.RegisterGenerator(first);
            _registry.RegisterGenerator(second);

            var result = _registry.GetGenerator<DummyPrimitive>();

            Assert.Same(second, result);
        }

        [Fact]
        public void GetGenerator_WhenTypeNotRegistered_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => _registry.GetGenerator<DummyPrimitive>());
        }
    }
}
