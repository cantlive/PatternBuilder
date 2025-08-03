using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Tests.BuildersTests
{
    public class PatternClassBuilderTests
    {
        private readonly PatternClassBuilder _builder;
        private readonly PatternParameter _field;
        private readonly PatternMethod _method;

        public PatternClassBuilderTests()
        {
            _builder = new PatternClassBuilder();
            _field = new PatternParameter("Name");
            _method = PatternMethodBuilder.Empty;
        }

        [Fact]
        public void AddField_WhenCalled_AddsFieldToClass()
        {
            var patternClass = _builder
                .AddField(_field)
                .Build();

            Assert.Contains(_field, patternClass.Fields);
        }

        [Fact]
        public void RemoveField_WhenCalled_RemovesFieldFromClass()
        {
            var patternClass = _builder
                .AddField(_field)
                .RemoveField(_field)
                .Build();

            Assert.DoesNotContain(_field, patternClass.Fields);
        }

        [Fact]
        public void AddMethod_WhenCalled_AddsMethodToClass()
        {
            var patternClass = _builder
                .AddMethod(_method)
                .Build();

            Assert.Contains(_method, patternClass.Methods);
        }

        [Fact]
        public void RemoveMethod_WhenCalled_RemovesMethodFromClass()
        {
            var patternClass = _builder
                .AddMethod(_method)
                .RemoveMethod(_method)
                .Build();

            Assert.DoesNotContain(_method, patternClass.Methods);
        }

        [Fact]
        public void SetParentClass_WhenCalled_SetsParentClass()
        {
            var patternClass = _builder
                .SetParentClass("BaseClass")
                .Build();

            Assert.Equal("BaseClass", patternClass.ParentClass);
        }

        [Fact]
        public void RemoveParentClass_WhenCalled_ClearsParentClass()
        {
            var patternClass = _builder
                .SetParentClass("BaseClass")
                .RemoveParentClass()
                .Build();

            Assert.True(string.IsNullOrEmpty(patternClass.ParentClass));
        }

        [Fact]
        public void SetAbstract_WhenCalled_MarksClassAsAbstract()
        {
            var patternClass = _builder
                .SetAbstract()
                .Build();

            Assert.True(patternClass.IsAbstract);
        }

        [Fact]
        public void SetNonAbstract_WhenCalled_MarksClassAsNonAbstract()
        {
            var patternClass = _builder
                .SetAbstract()
                .SetNonAbstract()
                .Build();

            Assert.False(patternClass.IsAbstract);
        }
    }
}
