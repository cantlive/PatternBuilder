using PatternBuilder.CodeGeneration.CodeGeneratorsBase;

namespace PatternBuilder.Tests.CodeGenerationTests
{
    public class CodeGeneratorBaseTests
    {
        private readonly CodeGeneratorBase _generator;

        public CodeGeneratorBaseTests()
        {
            _generator = new CodeGeneratorBase();
        }

        [Fact]
        public void AddLine_Appends_Line_With_NewLine()
        {
            _generator.AddLine("Hello");
            string result = _generator.GetResult();

            Assert.Equal("Hello" + Environment.NewLine, result);
        }

        [Fact]
        public void AddLine_Without_Argument_Appends_EmptyLine()
        {
            _generator.AddLine();
            string result = _generator.GetResult();

            Assert.Equal(Environment.NewLine, result);
        }

        [Fact]
        public void AddString_Appends_Without_NewLine()
        {
            _generator.AddString("Hello");
            string result = _generator.GetResult();

            Assert.Equal("Hello", result);
        }

        [Fact]
        public void AddLine_NullInput_AddsEmptyLine()
        {
            _generator.AddLine(null);
            string result = _generator.GetResult();

            Assert.Equal(Environment.NewLine, result);
        }

        [Fact]
        public void AddString_NullInput_AddsNothing()
        {
            _generator.AddString(null);
            string result = _generator.GetResult();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Clear_Removes_All_Content()
        {
            _generator.AddLine("Test");
            _generator.Clear();
            string result = _generator.GetResult();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetResult_Returns_Current_String()
        {
            _generator.AddLine("Code");
            string result = _generator.GetResult();

            Assert.Contains("Code", result);
        }

        [Fact]
        public void RemoveLastEmptyLine_Removes_Trailing_Newline()
        {
            _generator.AddLine("Line1");
            _generator.AddLine("Line2");
            _generator.AddLine();
            _generator.RemoveLastEmptyLine();

            string result = _generator.GetResult();

            Assert.False(result.EndsWith(Environment.NewLine + Environment.NewLine), "Result should not end with two newlines");
            Assert.EndsWith("Line2" + Environment.NewLine, result);
        }

        [Fact]
        public void AddTab_Appends_Tab_Character()
        {
            _generator.AddTab();
            _generator.AddString("IndentedLine");

            string result = _generator.GetResult();

            Assert.Equal("\tIndentedLine", result);
        }
    }
}
