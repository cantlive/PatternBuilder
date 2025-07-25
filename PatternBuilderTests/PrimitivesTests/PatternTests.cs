using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.PrimitivesTests
{
    public class PatternTests
    {
        private Pattern _pattern;

        public PatternTests()
        {
            _pattern = Core.Builders.PatternBuilder.Empty;
        }

        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            Assert.Equal("Pattern1", _pattern.Name);
            Assert.Equal("Pattern1", _pattern.UniqueKey);
            Assert.Equal("pattern", Pattern.SystemName);
            Assert.Equal("Pattern1", Pattern.DefaultName);
            Assert.Empty(_pattern.Classes);
            Assert.Empty(_pattern.Interfaces);
        }

        [Fact]
        public void AddClass_AddsToContainer()
        {
            _pattern.AddClass(PatternClassBuilder.Empty);

            var added = Assert.Single(_pattern.Classes);
            Assert.Equal("Class1", added.Name);
        }

        [Fact]
        public void RemoveClass_RemovesFromContainer()
        {
            PatternClass patternClass = PatternClassBuilder.Empty;

            _pattern.AddClass(patternClass);
            _pattern.RemoveClass(patternClass);

            Assert.Empty(_pattern.Classes);
        }

        [Fact]
        public void AddInterface_AddsToContainer()
        {
            _pattern.AddInterface(PatternInterfaceBuilder.Empty);

            var added = Assert.Single(_pattern.Interfaces);
            Assert.Equal("IInterface1", added.Name);
        }

        [Fact]
        public void RemoveInterface_RemovesFromContainer()
        {
            PatternInterface patternInterface = PatternInterfaceBuilder.Empty;

            _pattern.AddInterface(patternInterface);
            _pattern.RemoveInterface(patternInterface);

            Assert.Empty(_pattern.Interfaces);
        }
    }
}
