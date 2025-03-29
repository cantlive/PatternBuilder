using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Primitives
{
    public class PatternMethod : IPatternMethod
    {
        public string Name { get; internal set; }

        public string ReturnType { get; internal set; }

        public IEnumerable<PatternParameter> Parameters { get; internal set; }

        public bool IsAbstract { get; set; }

        public string Body { get; set; }
    }
}
