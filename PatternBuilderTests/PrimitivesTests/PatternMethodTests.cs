using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilderTests.PrimitivesTests
{
    public class PatternMethodTests
    {
        private PatternMethod _emptyMethod;

        public PatternMethodTests()
        {
            _emptyMethod = PatternMethodBuilder.Empty;
        }

        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            Assert.Null(_emptyMethod.Name);
            Assert.Null(_emptyMethod.ReturnType);
            Assert.Empty(_emptyMethod.Parameters);
            Assert.False(_emptyMethod.IsAbstract);
            Assert.True(_emptyMethod.HasImplementation);
            Assert.Null(_emptyMethod.Body);
        }

        [Fact]
        public void SetName_ValidName_SetsProperty()
        {
            _emptyMethod.SetName("TestMethod");
            Assert.Equal("TestMethod", _emptyMethod.Name);
        }

        [Fact]
        public void SetName_NullOrWhiteSpace_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _emptyMethod.SetName(null));
            Assert.Throws<ArgumentException>(() => _emptyMethod.SetName(""));
            Assert.Throws<ArgumentException>(() => _emptyMethod.SetName("   "));
        }

        [Fact]
        public void SetReturnType_SetsProperty()
        {
            _emptyMethod.SetReturnType("int");
            Assert.Equal("int", _emptyMethod.ReturnType);
        }

        [Fact]
        public void SetBody_SetsProperty()
        {
            _emptyMethod.SetBody("return 42;");
            Assert.Equal("return 42;", _emptyMethod.Body);
        }

        [Fact]
        public void AddParameter_AddsToContainer()
        {
            _emptyMethod.AddParameter("int", "number");

            var param = Assert.Single(_emptyMethod.Parameters);
            Assert.Equal("int", param.Type);
            Assert.Equal("number", param.Name);
        }

        [Fact]
        public void RemoveParameter_RemovesFromContainer()
        {
            _emptyMethod.AddParameter("int", "number");
            _emptyMethod.RemoveParameter("number");

            Assert.Empty(_emptyMethod.Parameters);
        }

        [Fact]
        public void GetSignature_NoParameters_ReturnsCorrectFormat()
        {
            _emptyMethod.SetReturnType("void");
            _emptyMethod.SetName("Test");

            Assert.Equal("void;Test;", _emptyMethod.GetSignature());
        }

        [Fact]
        public void GetSignature_WithParameters_ReturnsCorrectFormat()
        {
            _emptyMethod.SetReturnType("int");
            _emptyMethod.SetName("Calculate");
            _emptyMethod.AddParameter("int", "a");
            _emptyMethod.AddParameter("int", "b");

            Assert.Equal("int;Calculate;inta;intb", _emptyMethod.GetSignature());
        }

        [Fact]
        public void SetAbstract_SetsPropertiesAndClearsBody()
        {
            _emptyMethod.SetBody("return;");
            _emptyMethod.SetAbstract();

            Assert.True(_emptyMethod.IsAbstract);
            Assert.False(_emptyMethod.HasImplementation);
            Assert.Empty(_emptyMethod.Body);
        }

        [Fact]
        public void SetNonAbstract_SetsProperties()
        {
            _emptyMethod.SetAbstract();
            _emptyMethod.SetNonAbstract();

            Assert.False(_emptyMethod.IsAbstract);
            Assert.True(_emptyMethod.HasImplementation);
        }

        [Fact]
        public void Parameters_Property_ReturnsAllAddedParameters()
        {
            _emptyMethod.AddParameter("string", "text");
            _emptyMethod.AddParameter("bool", "flag");

            Assert.Collection(_emptyMethod.Parameters,
                p1 =>
                {
                    Assert.Equal("string", p1.Type);
                    Assert.Equal("text", p1.Name);
                },
                p2 =>
                {
                    Assert.Equal("bool", p2.Type);
                    Assert.Equal("flag", p2.Name);
                });
        }
    }
}
