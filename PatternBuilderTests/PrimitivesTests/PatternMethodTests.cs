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
            Assert.Equal("Method1", _emptyMethod.Name);
            Assert.Equal("void;Method1;", _emptyMethod.UniqueKey);
            Assert.Equal("void", _emptyMethod.ReturnType);
            Assert.Empty(_emptyMethod.Parameters);
            Assert.False(_emptyMethod.IsAbstract);
            Assert.True(_emptyMethod.HasImplementation);
            Assert.Null(_emptyMethod.Body);
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
            _emptyMethod.AddParameter("number", "int");

            var param = Assert.Single(_emptyMethod.Parameters);
            Assert.Equal("int", param.Type);
            Assert.Equal("number", param.Name);
        }

        [Fact]
        public void RemoveParameter_RemovesFromContainer()
        {
            var parameter = _emptyMethod.AddParameter("int", "number");
            _emptyMethod.RemoveParameter(parameter);

            Assert.Empty(_emptyMethod.Parameters);
        }

        [Fact]
        public void AddParameter_WithoutType_AllowsEmptyType()
        {
            var parameter = _emptyMethod.AddParameter("param");

            Assert.Single(_emptyMethod.Parameters);
            Assert.Equal("param", parameter.Name);
            Assert.Equal(string.Empty, parameter.Type);
        }

        [Fact]
        public void UniqueKey_EmptyMethod_ReturnsCorrectFormat()
        {
            Assert.Equal("void;Method1;", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_MethodWithoutReturnType_ReturnsCorrectFormat()
        {
            _emptyMethod.SetReturnType("");
            Assert.Equal(";Method1;", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_NoParameters_ReturnsCorrectFormat()
        {
            _emptyMethod.SetName("Test");
            Assert.Equal("void;Test;", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_WithUntypedParameter_ReturnsCorrectFormat()
        {
            _emptyMethod.SetName("Process");
            _emptyMethod.SetReturnType("void");
            _emptyMethod.AddParameter("input");

            Assert.Equal("void;Process;input", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_WithParameters_ReturnsCorrectFormat()
        {
            _emptyMethod.SetReturnType("int");
            _emptyMethod.SetName("Calculate");
            _emptyMethod.AddParameter("a", "int");
            _emptyMethod.AddParameter("b", "int");

            Assert.Equal("int;Calculate;inta;intb", _emptyMethod.UniqueKey);
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
        public void SetHasImplementation_SetsProperties()
        {
            _emptyMethod.SetHasImplementation();
            Assert.True(_emptyMethod.HasImplementation);
        }

        [Fact]
        public void SetHasNoImplementation_SetsProperties()
        {
            _emptyMethod.SetHasImplementation();
            _emptyMethod.SetHasNoImplementation();
            Assert.False(_emptyMethod.HasImplementation);
        }

        [Fact]
        public void Parameters_Property_ReturnsAllAddedParameters()
        {
            _emptyMethod.AddParameter("text", "string");
            _emptyMethod.AddParameter("flag", "bool");

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
                }
            );
        }
    }
}
