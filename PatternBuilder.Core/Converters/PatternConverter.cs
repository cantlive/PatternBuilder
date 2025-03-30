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
        private StringBuilder _methodStringBuilder = new StringBuilder();

        public string ConvertToString(IPatternMethod patternMethod)
        {
            AddTabToMethod();
            AddMethodSignature(patternMethod);
            AddParametersToMethod(patternMethod);
            AddClassMethodBody(patternMethod);
            AddSemicolonToMethod(patternMethod);

            return ClearAndGetResult(_methodStringBuilder);
        }

        public string ConvertToString(IPatternClass patternClass)
        {
            string abstractClassDefinition = patternClass.IsAbstract ? " abstract" : string.Empty;
            _classStringBuilder.Append($"public{abstractClassDefinition} class {patternClass.Name}");
            AddParentClassToClass(patternClass);

            _classStringBuilder.AppendLine();
            _classStringBuilder.AppendLine("{");

            AddFieldsToClass(patternClass);
            _classStringBuilder.AppendLine();
            AddMethodsToClass(patternClass);

            _classStringBuilder.AppendLine("}");

            return ClearAndGetResult(_classStringBuilder);
        }

        public string ConvertToString(IPatternInterface patternInterface)
        {
            _interfaceStringBuilder.Append($"public interface {patternInterface.Name}");
            _interfaceStringBuilder.AppendLine();
            _interfaceStringBuilder.AppendLine("{");

            AddMethodsToInterface(patternInterface);

            _interfaceStringBuilder.AppendLine("}");

            return ClearAndGetResult(_interfaceStringBuilder);
        }

        private void AddMethodSignature(IPatternMethod patternMethod)
        {
            string abstractMethodDefinition = patternMethod.IsAbstract ? " abstract" : string.Empty;
            _methodStringBuilder.Append($"public{abstractMethodDefinition} {patternMethod.ReturnType} {patternMethod.Name}");
        }

        private void AddParametersToMethod(IPatternMethod patternMethod)
        {
            int iterator = 0;
            int parametersCount = patternMethod.Parameters.Count();

            _methodStringBuilder.Append("(");
            foreach (PatternParameter patternParam in patternMethod.Parameters)
            {
                _methodStringBuilder.Append($"{patternParam.Type} {patternParam.Name}");
                iterator++;
                if (parametersCount > iterator)
                    _methodStringBuilder.Append(", ");
            }
            _methodStringBuilder.Append(")");
        }

        private void AddClassMethodBody(IPatternMethod patternMethod)
        {
            if (_classStringBuilder.Length == 0 || patternMethod.IsAbstract)
                return;

            _methodStringBuilder.AppendLine();
            AddTabToMethod();
            _methodStringBuilder.AppendLine("{");
            AddMethodBody(patternMethod);
            AddTabToMethod();
            _methodStringBuilder.AppendLine("}");
            _methodStringBuilder.AppendLine();
        }

        private void AddMethodBody(IPatternMethod patternMethod)
        {
            if (string.IsNullOrWhiteSpace(patternMethod.Body))
                return;

            foreach (string row in patternMethod.Body.Split(Environment.NewLine))
            {
                AddTabToMethod();
                AddTabToMethod();
                _methodStringBuilder.AppendLine(row);
            }
        }

        private void AddSemicolonToMethod(IPatternMethod patternMethod)
        {
            if (_interfaceStringBuilder.Length == 0 && !patternMethod.IsAbstract)
                return;

            _methodStringBuilder.Append(";");
            _methodStringBuilder.AppendLine();
        }

        private void AddTabToMethod()
        {
            if (_classStringBuilder.Length > 0 || _interfaceStringBuilder.Length > 0)
                _methodStringBuilder.Append("\t");
        }

        private void AddParentClassToClass(IPatternClass patternClass)
        {
            if (!string.IsNullOrWhiteSpace(patternClass.ParentClass))
                _classStringBuilder.Append($" : {patternClass.ParentClass}");
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

        private string ClearAndGetResult(StringBuilder stringBuilder)
        {
            string result = stringBuilder.ToString();
            stringBuilder.Clear();

            return result;
        }
    }
}
