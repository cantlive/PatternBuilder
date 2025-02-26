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

methodBuilder.Clear();

IPatternMethod interfaceMethod1 = methodBuilder
    .SetMethod("IPatternMethodBuilder", "AddParameter")
    .AddParameter("string", "returnType")
    .AddParameter("string", "name")
    .Build();

methodBuilder.Clear();

IPatternMethod interfaceMethod2 = methodBuilder
    .SetMethod("IPatternMethodBuilder", "AddParameter")
    .AddParameter("string", "parameterType")
    .AddParameter("string", "parameterName")
    .Build();

methodBuilder.Clear();

IPatternMethod interfaceMethod3 = methodBuilder
    .SetVoidMethod("Build")
    .Build();

methodBuilder.Clear();

IPatternMethod interfaceMethod4 = methodBuilder
    .SetVoidMethod("Clear")
    .Build();

var interfaceBuilder = new PatternInterfaceBuilder();
IPatternInterface patternInterface = interfaceBuilder
    .SetInterface("IPatternMethodBuilder")
    .AddMethod(interfaceMethod1)
    .AddMethod(interfaceMethod2)
    .AddMethod(interfaceMethod3)
    .AddMethod(interfaceMethod4)
    .Build();

IPatternConverter converter = new PatternConverter();

Console.WriteLine(converter.ConvertToString(patternClass));
Console.WriteLine(converter.ConvertToString(patternInterface));
Console.ReadLine();