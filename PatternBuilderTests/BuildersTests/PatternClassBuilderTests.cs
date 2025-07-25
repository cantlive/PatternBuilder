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
        public void AddField_Adds_Field_To_Class()
        {
            var patternClass = _builder
                .AddField(_field)
                .Build();

            Assert.Contains(_field, patternClass.Fields);
        }

        [Fact]
        public void RemoveField_Removes_Field_From_Class()
        {
            var patternClass = _builder
                .AddField(_field)
                .RemoveField(_field)
                .Build();

            Assert.DoesNotContain(_field, patternClass.Fields);
        }

        [Fact]
        public void AddMethod_Adds_Method_To_Class()
        {
            var patternClass = _builder
                .AddMethod(_method)
                .Build();

            Assert.Contains(_method, patternClass.Methods);
        }

        [Fact]
        public void RemoveMethod_Removes_Method_From_Class()
        {
            var patternClass = _builder
                .AddMethod(_method)
                .RemoveMethod(_method)
                .Build();

            Assert.DoesNotContain(_method, patternClass.Methods);
        }

        [Fact]
        public void SetParentClass_Sets_ParentClass()
        {
            var patternClass = _builder
                .SetParentClass("BaseClass")
                .Build();

            Assert.Equal("BaseClass", patternClass.ParentClass);
        }

        [Fact]
        public void RemoveParentClass_Clears_ParentClass()
        {
            var patternClass = _builder
                .SetParentClass("BaseClass")
                .RemoveParentClass()
                .Build();

            Assert.True(string.IsNullOrEmpty(patternClass.ParentClass));
        }

        [Fact]
        public void SetAbstract_Marks_Class_As_Abstract()
        {
            var patternClass = _builder
                .SetAbstract()
                .Build();

            Assert.True(patternClass.IsAbstract);
        }

        [Fact]
        public void SetNonAbstract_Marks_Class_As_NonAbstract()
        {
            var patternClass = _builder
                .SetAbstract()
                .SetNonAbstract()
                .Build();

            Assert.False(patternClass.IsAbstract);
        }
    }
}
