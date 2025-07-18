using PatternBuilder.Core.Primitives;

namespace PatternBuilderTests.PrimitivesTests
{
    public class PatternParameterTests
    {
        [Fact]
        public void PatternParameterNameValidation()
        {
            new PatternParameter(string.Empty, "Name");
            new PatternParameter("Type", "Name");

            Assert.Throws<ArgumentException>(() =>
            {
                new PatternParameter("Type", string.Empty);
            });
        }
    }
}