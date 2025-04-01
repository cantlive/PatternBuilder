using PatternBuilder.Core.Builders;
using PatternBuilder.Core.CodeGenerators;
using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;

string body = @"_returnType = returnType;
_name = name;

return this;";

var methodBuilder = new PatternMethodBuilder("IPatternMethodBuilder", "SetMethod");
IPatternMethod method1 = methodBuilder
    .AddParameter("string", "returnType")
    .AddParameter("string", "name")
    .SetBody(body)
    .Build();

methodBuilder.Clear();

IPatternMethod method2 = methodBuilder
    .SetMethod("IPatternMethodBuilder", "AddParameter")
    .AddParameter("string", "parameterType")
    .AddParameter("string", "parameterName")
    .Build();

var classBuilder = new PatternClassBuilder("PatternMethodBuilder");
IPatternClass patternClass = classBuilder
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
    .HasNoImplementation()
    .AddParameter("string", "returnType")
    .AddParameter("string", "name")
    .Build();

methodBuilder.Clear();

IPatternMethod interfaceMethod2 = methodBuilder
    .SetMethod("IPatternMethodBuilder", "AddParameter")
    .HasNoImplementation()
    .AddParameter("string", "parameterType")
    .AddParameter("string", "parameterName")
    .Build();

methodBuilder.Clear();

IPatternMethod interfaceMethod3 = methodBuilder
    .SetVoidMethod("Build")
    .HasNoImplementation()
    .Build();

methodBuilder.Clear();

IPatternMethod interfaceMethod4 = methodBuilder
    .SetVoidMethod("Clear")
    .HasNoImplementation()
    .Build();

var interfaceBuilder = new PatternInterfaceBuilder("IPatternMethodBuilder");
IPatternInterface patternInterface = interfaceBuilder
    .AddMethod(interfaceMethod1)
    .AddMethod(interfaceMethod2)
    .AddMethod(interfaceMethod3)
    .AddMethod(interfaceMethod4)
    .Build();

IPatternCodeGenerator converter = new PatternCodeGenerator();

Console.WriteLine(converter.Generate(patternClass));
Console.WriteLine(converter.Generate(patternInterface));
Console.ReadLine();