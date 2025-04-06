using PatternBuilder.Core.Exceptions;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;

namespace PatternBuilder.Core.Validators
{
    internal static class PatternValidator
    {
        public static void ValidateUniqueClass(IDictionary<string, IPatternClass> classes, IPatternClass patternClass)
        {
            if (classes.ContainsKey(patternClass.Name))
                throw new DuplicateElementException("class", patternClass.Name, "pattern");
        }

        public static void ValidateUniqueInterface(IDictionary<string, IPatternInterface> interfaces, IPatternInterface patternInterface)
        {
            if (interfaces.ContainsKey(patternInterface.Name))
                throw new DuplicateElementException("class", patternInterface.Name, "pattern");
        }

        public static void ValidateUniqueField(IDictionary<string, PatternParameter> fields, PatternParameter field)
        {
            if (fields.ContainsKey(field.Name))
                throw new DuplicateElementException(nameof(field), field.Name, "class");
        }

        public static void ValidateUniqueProperty(IDictionary<string, PatternParameter> properties, PatternParameter property, string containerName = "")
        {
            if (properties.ContainsKey(property.Name))
                throw new DuplicateElementException(nameof(property), property.Name, string.IsNullOrWhiteSpace(containerName) ? "class": containerName);
        }

        public static void ValidateUniqueMethod(IDictionary<string, IPatternMethod> methods, IPatternMethod method, string containerName = "")
        {
            if (methods.ContainsKey(method.GetSignature()))
                throw new DuplicateElementException(nameof(method), method.Name, string.IsNullOrWhiteSpace(containerName) ? "class" : containerName);
        }

        public static void ValidateUniqueParameter(IDictionary<string, PatternParameter> parameters, string parameterName)
        {
            if (parameters.ContainsKey(parameterName))
                throw new DuplicateElementException("parameter", parameterName, "method");
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
