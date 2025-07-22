using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.CodeGenerators.Languages.CSharp
{
    internal sealed class CSharpClassCodeGenerator : BaseClassCodeGenerator
    {
        public CSharpClassCodeGenerator() : base(new CSharpMethodCodeGenerator()) { }

        protected override void AddSignature(PatternClass patternClass)
        {
            string abstractClassDefinition = patternClass.IsAbstract ? " abstract" : string.Empty;
            AddString($"public{abstractClassDefinition} class {patternClass.Name}");
            AddParentClass(patternClass);
            AddLine();
            AddLine("{");
        }

        protected override void AddFields(PatternClass patternClass)
        {
            foreach (PatternParameter field in patternClass.Fields)
            {
                string visibility = field.Name.StartsWith("_") ? "private" : "public";
                AddLine($"\t{visibility} {field.Type} {field.Name};");
            }

            AddLine();
        }

        protected override void AddMethods(PatternClass patternClass)
        {
            foreach (PatternMethod method in patternClass.Methods)
            {
                AddLine(_methodGenerator.Generate(method));
            }

            RemoveLastEmptyLine();
            AddLine("}");
        }

        private void AddParentClass(PatternClass patternClass)
        {
            if (!string.IsNullOrWhiteSpace(patternClass.ParentClass))
                AddString($" : {patternClass.ParentClass}");
        }
    }
}
