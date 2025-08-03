using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.PrimitivesTests
{
    public class PatternPrimitiveBaseTests
    {
        public class PrimitiveTestData<T> where T : PatternPrimitiveBase, IPatternPrimitive
        {
            public PrimitiveTestData(T instance, string name, string uniqueKey, string systemName, string defaultName)
            {
                Instance = instance;
                Name = name;
                UniqueKey = uniqueKey;
                SystemName = systemName;
                DefaultName = defaultName;
            }

            public T Instance { get; }
            public string Name { get; }
            public string UniqueKey { get; }
            public string SystemName { get; }
            public string DefaultName { get; }
        }

        public static IEnumerable<object[]> PrimitiveTestList => new List<object[]>
        {
            new object[] { new PrimitiveTestData<PatternParameter>(new PatternParameter("param1"), "param1", "param1", "parameter", "param1") },
            new object[] { new PrimitiveTestData<PatternMethod>(new PatternMethod("Method1"), "Method1", "void;Method1;", "method", "Method1") },
            new object[] { new PrimitiveTestData<PatternClass>(new PatternClass("Class1"), "Class1", "Class1", "class", "Class1") },
            new object[] { new PrimitiveTestData<PatternInterface>(new PatternInterface("IInterface1"), "IInterface1", "IInterface1", "interface", "IInterface1") },
            new object[] { new PrimitiveTestData<Pattern>(new Pattern("Pattern1"), "Pattern1", "Pattern1", "pattern", "Pattern1") }
        };

        [Theory]
        [MemberData(nameof(PrimitiveTestList))]
        public void Constructor_WhenCalled_InitializesCorrectly<T>(PrimitiveTestData<T> data) 
            where T : PatternPrimitiveBase, IPatternPrimitive
        {
            Assert.NotNull(data.Instance);
            Assert.Equal(data.Name, data.Instance.Name);
            Assert.Equal(data.UniqueKey, data.Instance.UniqueKey);
            Assert.Equal(data.SystemName, T.SystemName);
            Assert.Equal(data.DefaultName, T.DefaultName);
        }

        private sealed class DummyPatternPrimitive : PatternPrimitiveBase
        {
            public DummyPatternPrimitive(string name) : base(name) { }
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WhenCalledWithEmptyName_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new DummyPatternPrimitive(name));
        }

        [Fact]
        public void SetName_WhenCalledWithValidName_SetsProperty()
        {
            var primitive = new DummyPatternPrimitive("Name");

            primitive.SetName("NewName");

            Assert.Equal("NewName", primitive.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void SetName_WhenCalledWithNullOrWhiteSpace_ThrowsArgumentException(string name)
        {
            var primitive = new DummyPatternPrimitive("Name");
            Assert.Throws<ArgumentException>(() => primitive.SetName(null));
        }

        [Fact]
        public void SetName_WhenCalledWithValidName_ChangesNameAndUniqueKey()
        {
            var patternPrimitive = new DummyPatternPrimitive("Name");

            patternPrimitive.SetName("NewName");

            Assert.Equal("NewName", patternPrimitive.Name);
            Assert.Equal("NewName", patternPrimitive.UniqueKey);
        }

        [Fact]
        public void CreateWithName_WhenCalled_ReturnsInstanceWithCorrectName()
        {
            string expectedName = "MyClass";

            var instance = PatternPrimitiveBase.CreateWithName<PatternClass>(expectedName);

            Assert.NotNull(instance);
            Assert.Equal(expectedName, instance.Name);
        }
    }
}
