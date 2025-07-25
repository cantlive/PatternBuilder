using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.BuildersTests
{
    public class PatternMethodBuilderTests
    {
        private readonly PatternMethodBuilder _builder;

        public PatternMethodBuilderTests()
        {
            _builder = new PatternMethodBuilder();
        }

        [Fact]
        public void AddParameter_WithNameOnly_Adds_Parameter()
        {
            var method = _builder
                .AddParameter("value")
                .Build();

            var param = Assert.Single(method.Parameters);
            Assert.Equal("value", param.Name);
            Assert.Equal(string.Empty, param.Type);
        }

        [Fact]
        public void AddParameter_WithNameAndType_Adds_Parameter()
        {
            var method = _builder
                .AddParameter("value", "int")
                .Build();

            var param = Assert.Single(method.Parameters);
            Assert.Equal("value", param.Name);
            Assert.Equal("int", param.Type);
        }

        [Fact]
        public void RemoveParameter_Removes_Existing_Parameter()
        {
            var method = _builder
                .AddParameter("id", "int")
                .Build();

            var param = method.Parameters.First();

            var updated = _builder
                .RemoveParameter(param)
                .Build();

            Assert.Empty(updated.Parameters);
        }

        [Fact]
        public void SetReturnType_Sets_ReturnType()
        {
            var method = _builder
                .SetReturnType("string")
                .Build();

            Assert.Equal("string", method.ReturnType);
        }

        [Fact]
        public void SetBody_Sets_MethodBody()
        {
            var method = _builder
                .SetBody("return 42;")
                .Build();

            Assert.Equal("return 42;", method.Body);
        }

        [Fact]
        public void HasImplementation_Sets_HasImplementation_True()
        {
            var method = _builder
                .HasImplementation()
                .Build();

            Assert.True(method.HasImplementation);
        }

        [Fact]
        public void HasNoImplementation_Sets_HasImplementation_False()
        {
            var method = _builder
                .HasNoImplementation()
                .Build();

            Assert.False(method.HasImplementation);
        }

        [Fact]
        public void SetAbstarct_Sets_IsAbstract_True_And_Clears_Body()
        {
            var method = _builder
                .SetBody("return x;")
                .SetAbstarct()
                .Build();

            Assert.True(method.IsAbstract);
            Assert.False(method.HasImplementation);
            Assert.True(string.IsNullOrWhiteSpace(method.Body));
        }

        [Fact]
        public void SetNonAbstarct_Sets_IsAbstract_False_And_EnablesImplementation()
        {
            var method = _builder
                .SetAbstarct()
                .SetNonAbstarct()
                .Build();

            Assert.False(method.IsAbstract);
            Assert.True(method.HasImplementation);
        }
    }
}
