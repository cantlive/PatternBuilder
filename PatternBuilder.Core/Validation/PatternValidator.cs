using PatternBuilder.Core.Exceptions;
using PatternBuilder.Core.Interfaces.Primitives;

namespace PatternBuilder.Core.Validation
{
    public static class PatternValidator
    {
        public static void ValidateUniquePatternPrimitive<T>(IDictionary<string, T> primitives, T primitive, string containerName, string parameterName = "") where T : IPatternPrimitive
        {
            string parameter = string.IsNullOrWhiteSpace(parameterName) ? T.SystemName : parameterName;
            if (primitives.ContainsKey(primitive.UniqueKey))
                throw new DuplicateElementException(parameter, primitive.Name, containerName);
        }

        public static void ThrowIfNullArgument(object argument, string argumentName)
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName, $"{argumentName} cannot be null.");
        }

        public static void ThrowIfNullOrWhiteSpace(string value, string valueName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{valueName} cannot be null or whitespace.", valueName);
        }
    }
}
