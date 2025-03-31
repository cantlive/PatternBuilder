using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Converters
{
    internal class InterfaceConverter : BaseConverter
    {
        private readonly MethodConverter _methodConverter;

        public InterfaceConverter(MethodConverter methodConverter)
        {
            _methodConverter = methodConverter;
        }

        public string ConvertToString(IPatternInterface patternInterface)
        {
            Clear();

            AddSignature(patternInterface);
            AddLine("{");
            AddProperties(patternInterface);
            AddMethods(patternInterface);
            AddLine("}");

            return GetResult();
        }

        private void AddSignature(IPatternInterface patternInterface)
        {
            AddString($"public interface {patternInterface.Name}");
            AddLine();
        }

        private void AddProperties(IPatternInterface patternInterface)
        {
            foreach (PatternParameter property in patternInterface.Properties)
            {
                AddLine($"\t{property.Type} {property.Name} {{ get; set; }}");
            }
        }

        private void AddMethods(IPatternInterface patternInterface)
        {
            foreach (IPatternMethod method in patternInterface.Methods)
            {
                AddLine(_methodConverter.ConvertToString(method));
                AddLine();
            }
        }
    }
}
