﻿using PatternBuilder.Core.Interfaces.Builders;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using System.Xml.Linq;

namespace PatternBuilder.Core.Builders
{
    public sealed class PatternClassBuilder : IPatternClassBuilder
    {
        private string _name;
        private string _parentClass;
        private bool _isAbstract;
        private Dictionary<string, IPatternMethod> _methodsBySignature = new Dictionary<string, IPatternMethod>();
        private Dictionary<string, PatternParameter> _fieldsByName = new Dictionary<string, PatternParameter>();

        public IPatternClassBuilder AddField(string parameterType, string parameterName)
        {
            return AddField(new PatternParameter(parameterType, parameterName));
        }

        public IPatternClassBuilder AddMethod(IPatternMethod method)
        {
            ArgumentNullException.ThrowIfNull(method);

            if (_methodsBySignature.ContainsKey(method.GetSignature()))
                throw new InvalidOperationException($"Method '{method.Name}' already exists in the class.");

            if (_isAbstract && !method.IsAbstract)
                throw new InvalidOperationException($"Method '{method.Name}' must be abstract.");

            _methodsBySignature.Add(method.GetSignature(), method);

            return this;
        }

        public IPatternClass Build()
        {
            var patternClass = new PatternClass();

            patternClass.SetName(_name);
            patternClass.SetParentClass(_parentClass);
            if (_isAbstract)
                patternClass.SetAbstract();
            else
                patternClass.SetNonAbstract();
            patternClass.FieldsByName = new Dictionary<string, PatternParameter>(_fieldsByName);
            patternClass.MethodsBySignature = new Dictionary<string, IPatternMethod>(_methodsBySignature);

            return patternClass;
        }

        public void Clear()
        {
            _name = string.Empty;
            _parentClass = string.Empty;
            _isAbstract = false;
            _methodsBySignature.Clear();
            _fieldsByName.Clear();
        }

        public IPatternClassBuilder RemoveField(string name)
        {
            _fieldsByName.Remove(name);
            return this;
        }

        public IPatternClassBuilder RemoveMethod(string signature)
        {
            _methodsBySignature.Remove(signature);
            return this;
        }

        public IPatternClassBuilder RemoveParentClass()
        {
            _parentClass = string.Empty;
            return this;
        }

        public IPatternClassBuilder SetAbstract()
        {
            _isAbstract = true;
            foreach (IPatternMethod method in _methodsBySignature.Values)
                method.SetAbstract();

            return this;
        }

        public IPatternClassBuilder SetNonAbstract()
        {
            _isAbstract = false;
            foreach (IPatternMethod method in _methodsBySignature.Values)
                method.SetNonAbstract();

            return this;
        }

        public IPatternClassBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IPatternClassBuilder SetParentClass(string parentClass)
        {
            _parentClass = parentClass;
            return this;
        }

        private PatternClassBuilder AddField(PatternParameter field)
        {
            ArgumentNullException.ThrowIfNull(field);

            if (_fieldsByName.ContainsKey(field.Name))
                throw new InvalidOperationException($"Field '{field.Name}' already exists in the class.");

            _fieldsByName.Add(field.Name, field);

            return this;
        }
    }
}
