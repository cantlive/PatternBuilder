using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternInterface : IPatternInterface
    {
        public string Name { get; internal set; }        

        public IEnumerable<IPatternMethod> Methods => MethodsBySignature.Values;

        public IEnumerable<PatternParameter> Properties => PropertiesByName.Values;

        internal Dictionary<string, PatternParameter> PropertiesByName = new Dictionary<string, PatternParameter>();

        internal Dictionary<string, IPatternMethod> MethodsBySignature = new Dictionary<string, IPatternMethod>();

        internal PatternInterface()
        {
            
        }

        internal void RemoveProperty(string name) => PropertiesByName.Remove(name);

        internal void RemoveMethod(string signature) => MethodsBySignature.Remove(signature);
    }
}
