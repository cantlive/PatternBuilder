using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Converters
{
    public class PatternConverter : IPatternConverter
    {
        private readonly MethodConverter _methodConverter;
        private readonly ClassConverter _classConverter;
        private readonly InterfaceConverter _interfaceConverter;

        public PatternConverter()
        {
            _methodConverter = new MethodConverter();
            _classConverter = new ClassConverter(_methodConverter);
            _interfaceConverter = new InterfaceConverter(_methodConverter);
        }

        public string ConvertToString(IPatternMethod patternMethod)
        {
            return _methodConverter.ConvertToString(patternMethod);
        }

        public string ConvertToString(IPatternClass patternClass)
        {
            return _classConverter.ConvertToString(patternClass);
        }

        public string ConvertToString(IPatternInterface patternInterface)
        {
            return _interfaceConverter.ConvertToString(patternInterface);
        }
    }
}
