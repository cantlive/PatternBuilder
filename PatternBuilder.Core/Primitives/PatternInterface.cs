﻿using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Validators;

namespace PatternBuilder.Core.Primitives
{
    public sealed class PatternInterface : IPatternInterface
    {
        internal Dictionary<string, PatternParameter> PropertiesByName = new Dictionary<string, PatternParameter>();

        internal Dictionary<string, IPatternMethod> MethodsBySignature = new Dictionary<string, IPatternMethod>();

        internal PatternInterface()
        {
            
        }

        public string Name { get; private set; }

        public IEnumerable<IPatternMethod> Methods => MethodsBySignature.Values;

        public IEnumerable<PatternParameter> Properties => PropertiesByName.Values;

        public void AddProperty(PatternParameter property)
        {
            ArgumentNullException.ThrowIfNull(property);

            if (PropertiesByName.ContainsKey(property.Name))
                throw new InvalidOperationException($"Field '{property.Name}' already exists in the interface '{Name}'.");

            PropertiesByName.Add(property.Name, property);
        }

        public void RemoveProperty(string name) => PropertiesByName.Remove(name);

        public void AddMethod(IPatternMethod method)
        {
            ArgumentNullException.ThrowIfNull(method);

            if (MethodsBySignature.ContainsKey(method.GetSignature()))
                throw new InvalidOperationException($"Method '{method.Name}' already exists in the interface '{Name}'.");

            MethodsBySignature.Add(method.GetSignature(), method);
        }

        public void RemoveMethod(string signature) => MethodsBySignature.Remove(signature);

        public void SetName(string name)
        {
            PatternValidator.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }
    }
}
