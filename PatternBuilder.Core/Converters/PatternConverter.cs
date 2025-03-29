using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using System.Text;

namespace PatternBuilder.Core.Converters
{
    public class PatternConverter : IPatternConverter
    {
        private StringBuilder _classStringBuilder = new StringBuilder();
        private StringBuilder _interfaceStringBuilder = new StringBuilder();
        private StringBuilder _methodsStringBuilder = new StringBuilder();

        public string ConvertToString(IPatternMethod patternMethod)
        {
            _methodsStringBuilder.Clear();

            AddTabToMethod();
            _methodsStringBuilder.Append($"public {patternMethod.ReturnType} {patternMethod.Name}(");
            AddParametersToMethod(patternMethod);
            _methodsStringBuilder.Append(")");

            AddClassMethodBody(patternMethod);
            AddSemicolonToMethod(patternMethod);

            return _methodsStringBuilder.ToString();
        }

        public string ConvertToString(IPatternClass patternClass)
        {
            _classStringBuilder.Append($"public class {patternClass.Name}");
            if (!string.IsNullOrWhiteSpace(patternClass.ParentClass))
                _classStringBuilder.Append($" : {patternClass.ParentClass}");
            _classStringBuilder.AppendLine();
            _classStringBuilder.AppendLine("{");

            AddFieldsToClass(patternClass);
            _classStringBuilder.AppendLine();
            AddMethodsToClass(patternClass);

            _classStringBuilder.AppendLine("}");

            string result = _classStringBuilder.ToString();
            _classStringBuilder.Clear();

            return result;
        }

        public string ConvertToString(IPatternInterface patternInterface)
        {
            _interfaceStringBuilder.Append($"public interface {patternInterface.Name}");
            _interfaceStringBuilder.AppendLine();
            _interfaceStringBuilder.AppendLine("{");

            AddMethodsToInterface(patternInterface);

            _interfaceStringBuilder.AppendLine("}");

            string result = _interfaceStringBuilder.ToString();
            _interfaceStringBuilder.Clear();

            return result;
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
                _interfaceStringBuilder.AppendLine(ConvertToString(method));
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

        private void AddClassMethodBody(IPatternMethod patternMethod)
        {
            if (_classStringBuilder.Length == 0 || patternMethod.IsAbstract)
                return;

            _methodsStringBuilder.AppendLine();
            AddTabToMethod();
            _methodsStringBuilder.AppendLine("{");
            AddMethodBody(patternMethod);
            AddTabToMethod();
            _methodsStringBuilder.AppendLine("}");
            _methodsStringBuilder.AppendLine();
        }

        private void AddMethodBody(IPatternMethod patternMethod)
        {
            if (string.IsNullOrWhiteSpace(patternMethod.Body))
                return;

            foreach (string row in patternMethod.Body.Split(Environment.NewLine))
            {
                AddTabToMethod();
                AddTabToMethod();
                _methodsStringBuilder.AppendLine(row);
            }
        }

        private void AddSemicolonToMethod(IPatternMethod patternMethod)
        {
            if (_interfaceStringBuilder.Length == 0 && !patternMethod.IsAbstract)
                return;

            _methodsStringBuilder.Append(";");
            _methodsStringBuilder.AppendLine();
        }

        private void AddTabToMethod()
        {
            if (_classStringBuilder.Length > 0 || _interfaceStringBuilder.Length > 0)
                _methodsStringBuilder.Append("\t");
        }
    }
}
