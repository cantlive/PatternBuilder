using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.PrimitivesTests
{
    public class PatternInterfaceTests
    {
        private PatternInterface _emptyInterface;

        public PatternInterfaceTests()
        {
            _emptyInterface = PatternInterfaceBuilder.Empty;
        }

        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            Assert.Equal("IInterface1", _emptyInterface.Name);
            Assert.Equal("IInterface1", _emptyInterface.UniqueKey);
            Assert.Empty(_emptyInterface.Methods);
            Assert.Empty(_emptyInterface.Properties);
        }

        [Fact]
        public void AddProperty_AddsSuccessfully()
        {
            var property = new PatternParameter("Id", "int");

            _emptyInterface.AddProperty(property);

            var prop = Assert.Single(_emptyInterface.Properties);
            Assert.Equal("Id", prop.Name);
            Assert.Equal("int", prop.Type);
        }

        [Fact]
        public void RemoveProperty_RemovesSuccessfully()
        {
            var property = new PatternParameter("Name", "string");

            _emptyInterface.AddProperty(property);
            _emptyInterface.RemoveProperty(property);

            Assert.Empty(_emptyInterface.Properties);
        }

        [Fact]
        public void AddMethod_AddsSuccessfully()
        {
            var method = new PatternMethod("DoWork");

            _emptyInterface.AddMethod(method);

            var m = Assert.Single(_emptyInterface.Methods);
            Assert.Equal("DoWork", m.Name);
        }

        [Fact]
        public void RemoveMethod_RemovesSuccessfully()
        {
            var method = new PatternMethod("Run");

            _emptyInterface.AddMethod(method);
            _emptyInterface.RemoveMethod(method);

            Assert.Empty(_emptyInterface.Methods);
        }
    }
}
