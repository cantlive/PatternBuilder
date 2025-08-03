using PatternBuilder.Core.Primitives;

namespace PatternBuilderTests.PrimitivesTests
{
    public class PatternParameterTests
    {
        private PatternParameter _parameterWithType;
        private PatternParameter _parameterWithoutType;
        private PatternParameter _parameterWithEmptyType;

        public PatternParameterTests()
        {
            _parameterWithType = new PatternParameter("Name", "Type");
            _parameterWithoutType = new PatternParameter("Name");
            _parameterWithEmptyType = new PatternParameter("Name", string.Empty);
        }

        [Fact]
        public void Constructor_WhenCalledWithoutType_InitializesCorrectly()
        {
            Assert.Equal("Name", _parameterWithoutType.Name);
            Assert.Equal("Name", _parameterWithoutType.UniqueKey);
            Assert.True(string.IsNullOrWhiteSpace(_parameterWithoutType.Type));

            Assert.Equal("Name", _parameterWithEmptyType.Name);
            Assert.Equal("Name", _parameterWithEmptyType.UniqueKey);
            Assert.True(string.IsNullOrWhiteSpace(_parameterWithEmptyType.Type));
        }

        [Fact]
        public void Constructor_WhenCalledWithType_InitializesCorrectly()
        {
            Assert.Equal("Name", _parameterWithType.Name);
            Assert.Equal("Name", _parameterWithType.UniqueKey);
            Assert.Equal("Type", _parameterWithType.Type);
        }

        [Fact]
        public void SetType_WhenCalledWithValidValue_ChangesProperty()
        {
            _parameterWithType.SetType("int");
            _parameterWithoutType.SetType("int");

            Assert.Equal("int", _parameterWithType.Type);
            Assert.Equal("int", _parameterWithoutType.Type);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void SetType_WhenCalledWithNullOrWhiteSpace_ChangesPropertyToEmpty(string type)
        {
            _parameterWithType.SetType(type);
            _parameterWithoutType.SetType(type);

            Assert.True(string.IsNullOrWhiteSpace(_parameterWithType.Type));
            Assert.True(string.IsNullOrWhiteSpace(_parameterWithoutType.Type));
        }
    }
}