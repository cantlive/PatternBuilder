using PatternBuilder.Core.Exceptions;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Validation;

namespace PatternBuilderTests.ValidationTests
{
    public class ValidatingPatternPrimitiveContainerTests
    {
        private class DummyPatternPrimitive : PatternPrimitiveBase, IPatternPrimitive
        {
            public DummyPatternPrimitive(string name) : base(name) { }

            public static string SystemName => "dummy";

            public static string DefaultName => "dummy";
        }

        private sealed class EmptyUniqueKeyDummyPatternPrimitive : DummyPatternPrimitive
        {
            public EmptyUniqueKeyDummyPatternPrimitive(string name) : base(name)
            {
            }

            public override string UniqueKey => string.Empty;
        }

        private readonly ValidatingPatternPrimitiveContainer<DummyPatternPrimitive> _container;

        private readonly DummyPatternPrimitive _emptyPrimitive;

        public ValidatingPatternPrimitiveContainerTests()
        {
            _container = new ValidatingPatternPrimitiveContainer<DummyPatternPrimitive>("dummyContainer");
            _emptyPrimitive = new EmptyUniqueKeyDummyPatternPrimitive("dummyPrimitive");
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

            var ex = Assert.Throws<ArgumentException>(() => container.Add(_emptyPrimitive));

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
            var ex = Assert.Throws<ArgumentException>(() => _container.Add(_emptyPrimitive));
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
            var ex = Assert.Throws<ArgumentException>(() => _container.Remove(_emptyPrimitive));
            Assert.Equal("dummy key cannot be null or whitespace. (Parameter 'dummy key')", ex.Message);
        }

        [Fact]
        public void Add_WhenPrimitiveIsValid_AddsSuccessfully()
        {
            var primitive = new DummyPatternPrimitive("key1");
            _container.Add(primitive);

            Assert.Single(_container.Items);
            Assert.Equal(1, _container.Count);
            Assert.True(_container.ContainsKey("key1"));
        }

        [Fact]
        public void Add_WhenPrimitiveIsDuplicate_ThrowsDuplicateElementException()
        {
            var primitive = new DummyPatternPrimitive("Name1");
            _container.Add(primitive);

            var ex = Assert.Throws<DuplicateElementException>(() => _container.Add(primitive));
            Assert.Equal("dummy 'Name1' already exists in the dummyContainer.", ex.Message);
        }

        [Fact]
        public void Remove_WhenPrimitiveIsValid_RemovesSuccessfully()
        {
            var primitive = new DummyPatternPrimitive("key1");
            _container.Add(primitive);
            var removed = _container.Remove(primitive);

            Assert.True(removed);
            Assert.Empty(_container.Items);
        }

        [Fact]
        public void Remove_WhenPrimitiveIsNotInContainer_DoNotRemoves()
        {
            var primitive = new DummyPatternPrimitive("key1");

            var removed = _container.Remove(primitive);

            Assert.False(removed);
        }

        [Fact]
        public void Clear_WhenCalled_RemovesAllItems()
        {
            _container.Add(new DummyPatternPrimitive("key1"));
            _container.Add(new DummyPatternPrimitive("key2"));

            _container.Clear();

            Assert.Empty(_container.Items);
            Assert.Equal(0, _container.Count);
        }
    }
}