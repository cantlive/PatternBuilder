using PatternBuilder.Core.Primitives;

namespace PatternBuilderTests.PrimitivesTests
{
    public class PatternParameterTests
    {
        [Fact]
        public void Constructor_WithoutType_InitializesCorrectly()
        {
            var param1 = new PatternParameter("Name");
            Assert.Equal("Name", param1.Name);
            Assert.Equal("Name", param1.UniqueKey);
            Assert.True(string.IsNullOrWhiteSpace(param1.Type));

            var param2 = new PatternParameter("Name", string.Empty);
            Assert.Equal("Name", param2.Name);
            Assert.Equal("Name", param1.UniqueKey);
            Assert.True(string.IsNullOrWhiteSpace(param2.Type));

            Assert.Throws<ArgumentException>(() =>
            {
                new PatternParameter(string.Empty);
            });
        }

        [Fact]
        public void Constructor_WithType_InitializesCorrectly()
        {
            var param = new PatternParameter("Name", "Type");
            Assert.Equal("Name", param.Name);
            Assert.Equal("Name", param.UniqueKey);
            Assert.Equal("Type", param.Type);

            Assert.Throws<ArgumentException>(() =>
            {
                new PatternParameter(string.Empty, "Type");
            });
        }
    }
}