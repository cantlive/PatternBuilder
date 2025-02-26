using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using System.Text;

namespace PatternBuilder.Core.Converters
{
    public class PatternConverter : IPatternConverter
    {
        private StringBuilder _classStringBuilder = new StringBuilder();
        private StringBuilder _methodsStringBuilder = new StringBuilder();

        public string ConvertToString(IPatternMethod patternMethod)
        {
            _methodsStringBuilder.Clear();

            AddTabTorClassMethods();
            _methodsStringBuilder.Append($"public {patternMethod.ReturnType} {patternMethod.Name}(");

            AddParametersToMethod(patternMethod);

            _methodsStringBuilder.Append(")");
            _methodsStringBuilder.AppendLine();
            AddTabTorClassMethods();
            _methodsStringBuilder.AppendLine("{");
            AddTabTorClassMethods();
            _methodsStringBuilder.AppendLine("}");

            return _methodsStringBuilder.ToString();
        }

        public string ConvertToString(IPatternClass patternClass)
        {
            _classStringBuilder.Clear();

            _classStringBuilder.Append($"public class {patternClass.Name}");
            if (!string.IsNullOrWhiteSpace(patternClass.ParentClass))
                _classStringBuilder.Append($" : {patternClass.ParentClass}");
            _classStringBuilder.AppendLine();
            _classStringBuilder.AppendLine("{");

            AddFieldsToClass(patternClass);
            _classStringBuilder.AppendLine();
            AddMethodsToClass(patternClass);

            _classStringBuilder.AppendLine("}");

            return _classStringBuilder.ToString();
        }

        public string ConvertToString(IPatternInterface patternInterface)
        {
            _classStringBuilder.Clear();

            _classStringBuilder.Append($"public interface {patternInterface.Name}");
            _classStringBuilder.AppendLine();
            _classStringBuilder.AppendLine("{");

            AddMethodsToInterface(patternInterface);

            _classStringBuilder.AppendLine("}");

            return _classStringBuilder.ToString();
        }

        private void AddFieldsToClass(IPatternClass patternClass)
        {
            foreach (PatternParameter field in patternClass.Fields)
            {
                if (field.Name.StartsWith("_"))
                    _classStringBuilder.Append("\tprivate ");
                else
                    _classStringBuilder.Append("\tpublic ");

                _classStringBuilder.Append($"{field.Type} {field.Name};");
                _classStringBuilder.AppendLine();
            }
        }

        private void AddMethodsToClass(IPatternClass patternClass)
        {
            foreach (IPatternMethod method in patternClass.Methods)
            {
                _classStringBuilder.AppendLine(ConvertToString(method));
            }
        }

        private void AddMethodsToInterface(IPatternInterface patternInterface)
        {
            foreach (IPatternMethod method in patternInterface.Methods)
            {
                _classStringBuilder.Append("\t");
                _classStringBuilder.Append($"{method.ReturnType} {method.Name}(");
                AddParametersToMethod(method);
                _classStringBuilder.Append(");");
                _classStringBuilder.AppendLine();
            }
        }

        private void AddParametersToMethod(IPatternMethod patternMethod)
        {
            int iterator = 0;
            int parametersCount = patternMethod.Parameters.Count();
            foreach (PatternParameter patternParam in patternMethod.Parameters)
            {
                _methodsStringBuilder.Append($"{patternParam.Type} {patternParam.Name}");
                iterator++;
                if (parametersCount > iterator)
                    _methodsStringBuilder.Append(", ");
            }
        }

        private void AddTabTorClassMethods()
        {
            if (_classStringBuilder.Length > 0)
                _methodsStringBuilder.Append("\t");
        }
    }
}
