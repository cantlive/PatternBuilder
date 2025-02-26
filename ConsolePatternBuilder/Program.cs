using PatternBuilder.Core.Builders;
using PatternBuilder.Core.Converters;
using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;

var methodBuilder = new PatternMethodBuilder();
IPatternMethod method1 = methodBuilder
    .SetMethod("IPatternMethodBuilder", "SetMethod")
    .AddParameter("string", "returnType")
    .AddParameter("string", "name")
    .Build();

methodBuilder.Clear();

IPatternMethod method2 = methodBuilder
    .SetMethod("IPatternMethodBuilder", "AddParameter")
    .AddParameter("string", "parameterType")
    .AddParameter("string", "parameterName")
    .Build();

var classBuilder = new PatternClassBuilder();
IPatternClass patternClass = classBuilder
    .SetClass("PatternMethodBuilder")
    .SetParentClass("IPatternMethodBuilder")
    .AddField("string", "_returnType")
    .AddField("string", "_name")
    .AddField("List<PatternParameter>", "_parameters")
    .AddMethod(method1)
    .AddMethod(method2)
    .Build();

IPatternConverter converter = new PatternConverter();

Console.WriteLine(converter.ConvertToString(patternClass));
Console.ReadLine();