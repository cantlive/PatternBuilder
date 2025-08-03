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
        public void Constructor_WhenCalled_InitializesCorrectly()
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
        public void SetReturnType_WhenCalled_SetsReturnTypeProperty()
        {
            _emptyMethod.SetReturnType("int");
            Assert.Equal("int", _emptyMethod.ReturnType);
        }

        [Fact]
        public void SetBody_WhenCalled_SetsBodyProperty()
        {
            _emptyMethod.SetBody("return 42;");
            Assert.Equal("return 42;", _emptyMethod.Body);
        }

        [Fact]
        public void AddParameter_WhenCalled_AddsParameterToContainer()
        {
            _emptyMethod.AddParameter("number", "int");

            var param = Assert.Single(_emptyMethod.Parameters);
            Assert.Equal("int", param.Type);
            Assert.Equal("number", param.Name);
        }

        [Fact]
        public void RemoveParameter_WhenCalled_RemovesParameterFromContainer()
        {
            var parameter = _emptyMethod.AddParameter("int", "number");
            _emptyMethod.RemoveParameter(parameter);

            Assert.Empty(_emptyMethod.Parameters);
        }

        [Fact]
        public void AddParameter_WhenCalledWithoutType_AllowsEmptyType()
        {
            var parameter = _emptyMethod.AddParameter("param");

            Assert.Single(_emptyMethod.Parameters);
            Assert.Equal("param", parameter.Name);
            Assert.Equal(string.Empty, parameter.Type);
        }

        [Fact]
        public void UniqueKey_WhenEmptyMethod_ReturnsCorrectFormat()
        {
            Assert.Equal("void;Method1;", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_WhenMethodWithoutReturnType_ReturnsCorrectFormat()
        {
            _emptyMethod.SetReturnType("");
            Assert.Equal(";Method1;", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_WhenNoParameters_ReturnsCorrectFormat()
        {
            _emptyMethod.SetName("Test");
            Assert.Equal("void;Test;", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_WhenHasUntypedParameter_ReturnsCorrectFormat()
        {
            _emptyMethod.SetName("Process");
            _emptyMethod.SetReturnType("void");
            _emptyMethod.AddParameter("input");

            Assert.Equal("void;Process;input", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void UniqueKey_WhenHasParameters_ReturnsCorrectFormat()
        {
            _emptyMethod.SetReturnType("int");
            _emptyMethod.SetName("Calculate");
            _emptyMethod.AddParameter("a", "int");
            _emptyMethod.AddParameter("b", "int");

            Assert.Equal("int;Calculate;inta;intb", _emptyMethod.UniqueKey);
        }

        [Fact]
        public void SetAbstract_WhenCalled_SetsPropertiesAndClearsBody()
        {
            _emptyMethod.SetBody("return;");
            _emptyMethod.SetAbstract();

            Assert.True(_emptyMethod.IsAbstract);
            Assert.False(_emptyMethod.HasImplementation);
            Assert.Empty(_emptyMethod.Body);
        }

        [Fact]
        public void SetNonAbstract_WhenCalled_SetsPropertiesCorrectly()
        {
            _emptyMethod.SetAbstract();
            _emptyMethod.SetNonAbstract();

            Assert.False(_emptyMethod.IsAbstract);
            Assert.True(_emptyMethod.HasImplementation);
        }

        [Fact]
        public void SetHasImplementation_WhenCalled_SetsHasImplementationTrue()
        {
            _emptyMethod.SetHasImplementation();
            Assert.True(_emptyMethod.HasImplementation);
        }

        [Fact]
        public void SetHasNoImplementation_WhenCalled_SetsHasImplementationFalse()
        {
            _emptyMethod.SetHasImplementation();
            _emptyMethod.SetHasNoImplementation();
            Assert.False(_emptyMethod.HasImplementation);
        }

        [Fact]
        public void Parameters_WhenCalled_ReturnsAllAddedParameters()
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
