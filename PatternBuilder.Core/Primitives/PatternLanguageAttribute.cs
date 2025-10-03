namespace PatternBuilder.Core.Primitives
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PatternLanguageAttribute : Attribute
    {
        public PatternLanguages Language { get; }

        public PatternLanguageAttribute(PatternLanguages language)
        {
            Language = language;
        }
    }
}
