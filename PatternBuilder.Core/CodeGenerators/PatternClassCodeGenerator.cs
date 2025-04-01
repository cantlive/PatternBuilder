using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators
{
    internal class PatternClassCodeGenerator : BasePatternCodeGenerator
    {
        private readonly PatternMethodCodeGenerator _methodConverter;

        public PatternClassCodeGenerator(PatternMethodCodeGenerator methodConverter)
        {
            _methodConverter = methodConverter;
        }

        public string ConvertToString(IPatternClass patternClass)
        {
            Clear();

            AddSignature(patternClass);
            AddLine("{");
            AddFields(patternClass);
            AddLine();
            AddMethods(patternClass);
            AddLine("}");

            return GetResult();
        }

        private void AddSignature(IPatternClass patternClass)
        {
            string abstractClassDefinition = patternClass.IsAbstract ? " abstract" : string.Empty;
            AddString($"public{abstractClassDefinition} class {patternClass.Name}");
            AddParentClass(patternClass);
            AddLine();
        }

        private void AddParentClass(IPatternClass patternClass)
        {
            if (!string.IsNullOrWhiteSpace(patternClass.ParentClass))
                AddString($" : {patternClass.ParentClass}");
        }

        private void AddFields(IPatternClass patternClass)
        {
            foreach (PatternParameter field in patternClass.Fields)
            {
                string visibility = field.Name.StartsWith("_") ? "private" : "public";
                AddLine($"\t{visibility} {field.Type} {field.Name};");
            }
        }

        private void AddMethods(IPatternClass patternClass)
        {
            foreach (IPatternMethod method in patternClass.Methods)
            {
                AddLine(_methodConverter.Generate(method));
            }
        }
    }
}
