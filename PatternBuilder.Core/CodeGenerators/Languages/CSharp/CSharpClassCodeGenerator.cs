using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators.Languages.CSharp
{
    internal sealed class CSharpClassCodeGenerator : BaseClassCodeGenerator
    {
        public CSharpClassCodeGenerator() : base(new CSharpMethodCodeGenerator()) { }

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
                AddLine(_methodGenerator.Generate(method));
            }

            RemoveLastLine();
            AddLine("}");
        }

        private void AddParentClass(IPatternClass patternClass)
        {
            if (!string.IsNullOrWhiteSpace(patternClass.ParentClass))
                AddString($" : {patternClass.ParentClass}");
        }
    }
}
