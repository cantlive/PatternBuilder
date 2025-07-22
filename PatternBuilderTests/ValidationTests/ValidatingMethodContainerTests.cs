using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Exceptions;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilderTests.ValidationTests
{
    public class ValidatingMethodContainerTests
    {
        private readonly ValidatingPatternPrimitiveContainer<PatternMethod> _validatingMethodContainer;

        public ValidatingMethodContainerTests()
        {
            _validatingMethodContainer = new ValidatingPatternPrimitiveContainer<PatternMethod>("container");
        }

        [Fact]
        public void ValidatingMethodContainerAddNullThrow()
        {
            Assert.Throws<ArgumentNullException>(() => { _validatingMethodContainer.Add(null); });

            try
            {
                _validatingMethodContainer.Add(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Equal("method cannot be null. (Parameter 'method')", ex.Message);
            }
        }

        [Fact]
        public void ValidatingMethodContainerAddEmptyKeyThrow()
        {
            var method = new PatternMethod();
            Assert.Throws<ArgumentException>(() => { _validatingMethodContainer.Add(method); });

            try
            {
                _validatingMethodContainer.Add(method);
            }
            catch (ArgumentException ex)
            {
                Assert.Equal("method key cannot be null or whitespace. (Parameter 'method key')", ex.Message);
            }
        }

        [Fact]
        public void ValidatingMethodContainerRemoveNullThrow()
        {
            Assert.Throws<ArgumentNullException>(() => { _validatingMethodContainer.Remove(null); });

            try
            {
                _validatingMethodContainer.Remove(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Equal("method cannot be null. (Parameter 'method')", ex.Message);
            }
        }

        [Fact]
        public void ValidatingMethodContainerRemoveEmptyKeyThrow()
        {
            var method = new PatternMethod();
            Assert.Throws<ArgumentException>(() => { _validatingMethodContainer.Remove(method); });

            try
            {
                _validatingMethodContainer.Add(method);
            }
            catch (ArgumentException ex)
            {
                Assert.Equal("method key cannot be null or whitespace. (Parameter 'method key')", ex.Message);
            }
        }

        [Fact]
        public void ValidatingMethodContainerAdd()
        {
            var methodBuilder = new PatternMethodBuilder();
            var method = methodBuilder.SetMethod("string", "ToString").Build();
            _validatingMethodContainer.Add(method);

            Assert.Equal(1, _validatingMethodContainer.Count);
            Assert.Single(_validatingMethodContainer.Items);
        }

        [Fact]
        public void ValidatingMethodContainerAddDuplicatesThrow()
        {
            var methodBuilder = new PatternMethodBuilder();
            var method = methodBuilder.SetMethod("string", "ToString").Build();
            _validatingMethodContainer.Add(method);

            Assert.Throws<DuplicateElementException>(() => { _validatingMethodContainer.Add(method); });

            try
            {
                _validatingMethodContainer.Add(method);
            }
            catch (DuplicateElementException ex)
            {
                Assert.Equal("Method 'ToString' already exists in the container.", ex.Message);
            }
        }
    }
}
