using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.PrimitivesTests
{
    public class PatternTests
    {
        private Pattern _pattern;

        public PatternTests()
        {
            _pattern = PatternPrimitiveBuilder.Empty;
        }

        [Fact]
        public void Constructor_WhenCalled_InitializesCorrectly()
        {
            Assert.Equal("Pattern1", _pattern.Name);
            Assert.Equal("Pattern1", _pattern.UniqueKey);
            Assert.Equal("pattern", Pattern.SystemName);
            Assert.Equal("Pattern1", Pattern.DefaultName);
            Assert.Empty(_pattern.Classes);
            Assert.Empty(_pattern.Interfaces);
        }

        [Fact]
        public void AddClass_WhenCalled_AddsClassToContainer()
        {
            _pattern.AddClass(PatternClassBuilder.Empty);

            var added = Assert.Single(_pattern.Classes);
            Assert.Equal("Class1", added.Name);
        }

        [Fact]
        public void RemoveClass_WhenCalled_RemovesClassFromContainer()
        {
            PatternClass patternClass = PatternClassBuilder.Empty;

            _pattern.AddClass(patternClass);
            _pattern.RemoveClass(patternClass);

            Assert.Empty(_pattern.Classes);
        }

        [Fact]
        public void AddInterface_WhenCalled_AddsInterfaceToContainer()
        {
            _pattern.AddInterface(PatternInterfaceBuilder.Empty);

            var added = Assert.Single(_pattern.Interfaces);
            Assert.Equal("IInterface1", added.Name);
        }

        [Fact]
        public void RemoveInterface_WhenCalled_RemovesInterfaceFromContainer()
        {
            PatternInterface patternInterface = PatternInterfaceBuilder.Empty;

            _pattern.AddInterface(patternInterface);
            _pattern.RemoveInterface(patternInterface);

            Assert.Empty(_pattern.Interfaces);
        }
    }
}
