using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validators;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternClass : IPatternClass
    {
        internal Dictionary<string, PatternParameter> FieldsByName = new Dictionary<string, PatternParameter>();

        internal Dictionary<string, IPatternMethod> MethodsBySignature = new Dictionary<string, IPatternMethod>();

        internal PatternClass()
        {
            
        }

        public string Name { get; private set; }

        public IEnumerable<PatternParameter> Fields => FieldsByName.Values;

        public IEnumerable<IPatternMethod> Methods => MethodsBySignature.Values;

        public bool IsAbstract { get; private set; }

        public string ParentClass { get; private set; }

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public void SetParentClass(string parentClass)
        {
            ParentClass = parentClass;
        }

        public void SetAbstract()
        {
            foreach (IPatternMethod method in Methods)
                method.SetAbstract();
        }

        public void SetNonAbstract()
        {
            foreach (IPatternMethod method in Methods)
                method.SetNonAbstract();
        }

        public void AddField(PatternParameter field)
        {
            PatternValidator.ThrowIfNullArgument(field, nameof(field));
            PatternValidator.ValidateUniqueField(FieldsByName, field);

            FieldsByName.Add(field.Name, field);
        }

        public void RemoveField(string name) => FieldsByName.Remove(name);

        public void AddMethod(IPatternMethod method)
        {
            PatternValidator.ThrowIfNullArgument(method, nameof(method));
            PatternValidator.ValidateUniqueMethod(MethodsBySignature, method, "class");

            MethodsBySignature.Add(method.GetSignature(), method);
        }

        public void RemoveMethod(string signature) => MethodsBySignature.Remove(signature);
    }
}
