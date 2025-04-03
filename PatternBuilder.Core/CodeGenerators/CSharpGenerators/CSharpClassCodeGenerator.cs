using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators.CSharpGenerators
{
    internal sealed class CSharpClassCodeGenerator : BaseClassCodeGenerator
    {
        private readonly BaseMethodCodeGenerator _methodConverter;

        public CSharpClassCodeGenerator(BaseMethodCodeGenerator methodConverter)
        {
            _methodConverter = methodConverter;
        }

        protected override void AddSignature(IPatternClass patternClass)
        {
            string abstractClassDefinition = patternClass.IsAbstract ? " abstract" : string.Empty;
            AddString($"public{abstractClassDefinition} class {patternClass.Name}");
            AddParentClass(patternClass);
            AddLine();
            AddLine("{");
        }

        protected override void AddFields(IPatternClass patternClass)
        {
            foreach (PatternParameter field in patternClass.Fields)
            {
                string visibility = field.Name.StartsWith("_") ? "private" : "public";
                AddLine($"\t{visibility} {field.Type} {field.Name};");
            }

            AddLine();
        }

        protected override void AddMethods(IPatternClass patternClass)
        {
            foreach (IPatternMethod method in patternClass.Methods)
            {
                AddLine(_methodConverter.Generate(method));
            }

            AddLine("}");
        }

        private void AddParentClass(IPatternClass patternClass)
        {
            if (!string.IsNullOrWhiteSpace(patternClass.ParentClass))
                AddString($" : {patternClass.ParentClass}");
        }
    }
}
