using PatternBuilder.Core.Exceptions;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilderTests.ValidationTests
{
    public class ValidatingPatternPrimitiveContainerTests
    {
        private sealed class DummyPatternPrimitive : IPatternPrimitive
        {
            public string Name { get; set; } = "";
            public static string SystemName => "dummy";
            public string UniqueKey { get; set; } = "";
            public static string DefaultName => "dummy";
        }

        private readonly ValidatingPatternPrimitiveContainer<DummyPatternPrimitive> _container;

        public ValidatingPatternPrimitiveContainerTests()
        {
            _container = new ValidatingPatternPrimitiveContainer<DummyPatternPrimitive>("dummyContainer");
        }

        [Fact]
        public void Constructor_WhenParameterNameNotProvided_UsesSystemName()
        {
            var container = new ValidatingPatternPrimitiveContainer<DummyPatternPrimitive>("testContainer");

            var ex = Assert.Throws<ArgumentNullException>(() => container.Add(null));

            Assert.Equal("dummy cannot be null. (Parameter 'dummy')", ex.Message);
        }

        [Fact]
        public void Constructor_WhenParameterNameProvided_UsesProvidedName()
        {
            var container = new ValidatingPatternPrimitiveContainer<DummyPatternPrimitive>("testContainer", "CustomParam");

            var ex = Assert.Throws<ArgumentNullException>(() => container.Add(null));

            Assert.Equal("CustomParam cannot be null. (Parameter 'CustomParam')", ex.Message);
        }

        [Fact]
        public void Add_WhenPrimitiveKeyIsInvalid_ThrowsArgumentExceptionWithCustomParameterName()
        {
            var container = new ValidatingPatternPrimitiveContainer<DummyPatternPrimitive>("testContainer", "CustomParam");
            var primitive = new DummyPatternPrimitive();

            var ex = Assert.Throws<ArgumentException>(() => container.Add(primitive));

            Assert.Equal("CustomParam key cannot be null or whitespace. (Parameter 'CustomParam key')", ex.Message);
        }

        [Fact]
        public void Add_WhenPrimitiveIsNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _container.Add(null));
            Assert.Equal("dummy cannot be null. (Parameter 'dummy')", ex.Message);
        }

        [Fact]
        public void Add_WhenPrimitiveKeyIsEmpty_ThrowsArgumentException()
        {
            var primitive = new DummyPatternPrimitive();
            var ex = Assert.Throws<ArgumentException>(() => _container.Add(primitive));
            Assert.Equal("dummy key cannot be null or whitespace. (Parameter 'dummy key')", ex.Message);
        }

        [Fact]
        public void Remove_WhenPrimitiveIsNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _container.Remove(null));
            Assert.Equal("dummy cannot be null. (Parameter 'dummy')", ex.Message);
        }

        [Fact]
        public void Remove_WhenPrimitiveKeyIsEmpty_ThrowsArgumentException()
        {
            var primitive = new DummyPatternPrimitive();
            var ex = Assert.Throws<ArgumentException>(() => _container.Remove(primitive));
            Assert.Equal("dummy key cannot be null or whitespace. (Parameter 'dummy key')", ex.Message);
        }

        [Fact]
        public void Add_WhenPrimitiveIsValid_AddsSuccessfully()
        {
            var primitive = new DummyPatternPrimitive { UniqueKey = "key1", Name = "Name1" };
            _container.Add(primitive);

            Assert.Single(_container.Items);
            Assert.Equal(1, _container.Count);
            Assert.True(_container.ContainsKey("key1"));
        }

        [Fact]
        public void Add_WhenPrimitiveIsDuplicate_ThrowsDuplicateElementException()
        {
            var primitive = new DummyPatternPrimitive { UniqueKey = "key1", Name = "Name1" };
            _container.Add(primitive);

            var ex = Assert.Throws<DuplicateElementException>(() => _container.Add(primitive));
            Assert.Equal("dummy 'Name1' already exists in the dummyContainer.", ex.Message);
        }

        [Fact]
        public void Remove_WhenPrimitiveIsValid_RemovesSuccessfully()
        {
            var primitive = new DummyPatternPrimitive { UniqueKey = "key1", Name = "Name1" };
            _container.Add(primitive);
            var removed = _container.Remove(primitive);

            Assert.True(removed);
            Assert.Empty(_container.Items);
        }

        [Fact]
        public void Clear_WhenCalled_RemovesAllItems()
        {
            _container.Add(new DummyPatternPrimitive { UniqueKey = "key1", Name = "Name1" });
            _container.Add(new DummyPatternPrimitive { UniqueKey = "key2", Name = "Name2" });

            _container.Clear();

            Assert.Empty(_container.Items);
            Assert.Equal(0, _container.Count);
        }
    }
}