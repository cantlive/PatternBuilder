using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using System.Reflection;

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
            new object[] { new PrimitiveTestData<PatternMethod>(PatternMethodBuilder.Empty, "Method1", "void;Method1;", "method", "Method1") },
            new object[] { new PrimitiveTestData<PatternClass>(PatternClassBuilder.Empty, "Class1", "Class1", "class", "Class1") },
            new object[] { new PrimitiveTestData<PatternInterface>(PatternInterfaceBuilder.Empty, "IInterface1", "IInterface1", "interface", "IInterface1") },
            new object[] { new PrimitiveTestData<Pattern>(Core.Builders.PatternBuilder.Empty, "Pattern1", "Pattern1", "pattern", "Pattern1") }
        };

        [Theory]
        [MemberData(nameof(PrimitiveTestList))]
        public void TestPrimitiveConstructor<T>(PrimitiveTestData<T> data) where T : PatternPrimitiveBase, IPatternPrimitive
        {
            Assert.NotNull(data.Instance);
            Assert.Equal(data.Name, data.Instance.Name);
            Assert.Equal(data.UniqueKey, data.Instance.UniqueKey);
            Assert.Equal(data.SystemName, T.SystemName);
            Assert.Equal(data.DefaultName, T.DefaultName);
        }

        [Theory]
        [MemberData(nameof(PrimitiveTestList))]
        public void SetName_ValidName_SetsProperty<T>(PrimitiveTestData<T> data) where T : PatternPrimitiveBase, IPatternPrimitive
        {
            data.Instance.SetName("TestName");
            Assert.Equal("TestName", data.Instance.Name);
        }

        [Theory]
        [MemberData(nameof(PrimitiveTestList))]
        public void SetName_NullOrWhiteSpace_ThrowsException<T>(PrimitiveTestData<T> data) where T : PatternPrimitiveBase, IPatternPrimitive
        {
            Assert.Throws<ArgumentException>(() => data.Instance.SetName(null));
            Assert.Throws<ArgumentException>(() => data.Instance.SetName(""));
            Assert.Throws<ArgumentException>(() => data.Instance.SetName("   "));
        }

        public static IEnumerable<object[]> GetPrimitiveTypes()
        {
            return Assembly
                .GetAssembly(typeof(IPatternPrimitive))!
                .GetTypes()
                .Where(t => typeof(IPatternPrimitive).IsAssignableFrom(t) &&
                            typeof(PatternPrimitiveBase).IsAssignableFrom(t) &&
                            t.IsClass &&
                            !t.IsAbstract &&
                            t.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string) }, null) != null)
                .Select(t => new object[] { t });
        }

        [Theory]
        [MemberData(nameof(GetPrimitiveTypes))]
        public void Constructor_Throws_WhenNameIsEmpty(Type type)
        {
            var constructor = type.GetConstructor(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(string) },
                null);

            var ex = Assert.Throws<TargetInvocationException>(() => constructor!.Invoke([null]));
            var ex1 = Assert.Throws<TargetInvocationException>(() => constructor!.Invoke([""]));
            var ex2 = Assert.Throws<TargetInvocationException>(() => constructor!.Invoke(["   "]));

            Assert.IsType<ArgumentException>(ex.InnerException);
            Assert.IsType<ArgumentException>(ex1.InnerException);
            Assert.IsType<ArgumentException>(ex2.InnerException);
        }

        [Fact]
        public void CreateWithName_ValidPrimitive_ReturnsInstanceWithCorrectName()
        {
            string expectedName = "MyClass";

            var instance = PatternPrimitiveBase.CreateWithName<PatternClass>(expectedName);

            Assert.NotNull(instance);
            Assert.Equal(expectedName, instance.Name);
        }

        private sealed class InvalidPrimitive : IPatternPrimitive
        {
            // No constructor with string
            public string Name => "Invalid";
            public string UniqueKey => "InvalidKey";
            public static string SystemName => "invalid";
            public static string DefaultName => "Invalid";
        }

        [Fact]
        public void CreateWithName_NoMatchingConstructor_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
                PatternPrimitiveBase.CreateWithName<InvalidPrimitive>("Test"));

            Assert.Equal("InvalidPrimitive must have a constructor with a single string parameter.", ex.Message);
        }
    }
}
