using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.PrimitivesTests
{
    public class PatternClassTests
    {
        private PatternClass _emptyClass;

        public PatternClassTests()
        {
            _emptyClass = PatternClassBuilder.Empty;
        }

        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            Assert.Equal("Class1", _emptyClass.Name);
            Assert.Equal("Class1", _emptyClass.UniqueKey);
            Assert.Empty(_emptyClass.Fields);
            Assert.Empty(_emptyClass.Methods);
            Assert.False(_emptyClass.IsAbstract);
            Assert.Null(_emptyClass.ParentClass);
        }

        [Fact]
        public void AddField_AddsSuccessfully()
        {
            var field = new PatternParameter("age", "int");

            _emptyClass.AddField(field);

            var result = Assert.Single(_emptyClass.Fields);
            Assert.Equal("age", result.Name);
            Assert.Equal("int", result.Type);
        }

        [Fact]
        public void RemoveField_RemovesSuccessfully()
        {
            var field = new PatternParameter("name", "string");

            _emptyClass.AddField(field);
            _emptyClass.RemoveField(field);

            Assert.Empty(_emptyClass.Fields);
        }

        [Fact]
        public void AddMethod_AddsSuccessfully()
        {
            var method = new PatternMethod("Execute");

            _emptyClass.AddMethod(method);

            var result = Assert.Single(_emptyClass.Methods);
            Assert.Equal("Execute", result.Name);
        }

        [Fact]
        public void RemoveMethod_RemovesSuccessfully()
        {
            var method = new PatternMethod("Reset");

            _emptyClass.AddMethod(method);
            _emptyClass.RemoveMethod(method);

            Assert.Empty(_emptyClass.Methods);
        }

        [Fact]
        public void SetParentClass_SetsCorrectly()
        {
            _emptyClass.SetParentClass("BaseClass");
            Assert.Equal("BaseClass", _emptyClass.ParentClass);
        }

        [Fact]
        public void SetAbstract_SetsFlagTrue()
        {
            _emptyClass.SetAbstract();
            Assert.True(_emptyClass.IsAbstract);
        }

        [Fact]
        public void SetNonAbstract_SetsFlagFalse()
        {
            _emptyClass.SetAbstract();
            _emptyClass.SetNonAbstract();

            Assert.False(_emptyClass.IsAbstract);
        }
    }
}
