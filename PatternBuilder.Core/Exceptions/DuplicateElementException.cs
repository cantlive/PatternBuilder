using PatternBuilder.Core.Extensions;

namespace PatternBuilder.Core.Exceptions
{
    public class DuplicateElementException : InvalidOperationException
    {
        public DuplicateElementException(string elementType, string elementName, string containerName)
            : base($"{elementType.ToUpperFirst()} '{elementName}' already exists in the {containerName}.")
        {
            ElementType = elementType;
            ElementName = elementName;
            ContainerName = containerName;
        }

        public string ElementType { get; }
        public string ElementName { get; }
        public string ContainerName { get; }
    }
}
