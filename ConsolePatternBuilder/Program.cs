using PatternBuilder.Core.Builders;
using PatternBuilder.Core.CodeGeneration;
using PatternBuilder.Core.Primitives;

string body = @"_returnType = returnType;
_name = name;

return this;";

var methodBuilder = new PatternMethodBuilder();
PatternMethod method1 = methodBuilder
    .SetName("SetMethod")
    .SetReturnType("IPatternMethodBuilder")
    .AddParameter("string", "returnType")
    .AddParameter("string", "name")
    .SetBody(body)
    .Build();

methodBuilder.Clear();

PatternMethod method2 = methodBuilder
    .SetName("AddParameter")
    .SetReturnType("IPatternMethodBuilder")
    .AddParameter("string", "parameterType")
    .AddParameter("string", "parameterName")
    .Build();

var classBuilder = new PatternClassBuilder();
PatternClass patternClass = classBuilder
    .SetName("PatternMethodBuilder")
    .SetParentClass("IPatternMethodBuilder")
    .AddField("string", "_returnType")
    .AddField("string", "_name")
    .AddField("List<PatternParameter>", "_parameters")
    .AddMethod(method1)
    .AddMethod(method2)
    .Build();

methodBuilder.Clear();

PatternMethod interfaceMethod1 = methodBuilder
    .SetName("AddParameter")
    .SetReturnType("IPatternMethodBuilder")
    .HasNoImplementation()
    .AddParameter("string", "returnType")
    .AddParameter("string", "name")
    .Build();

methodBuilder.Clear();

PatternMethod interfaceMethod2 = methodBuilder
    .SetName("AddParameter")
    .SetReturnType("IPatternMethodBuilder")
    .HasNoImplementation()
    .AddParameter("string", "parameterType")
    .AddParameter("string", "parameterName")
    .Build();

methodBuilder.Clear();

PatternMethod interfaceMethod3 = methodBuilder
    .SetName("Build")
    .HasNoImplementation()
    .Build();

methodBuilder.Clear();

PatternMethod interfaceMethod4 = methodBuilder
    .SetName("Clear")
    .HasNoImplementation()
    .Build();

var interfaceBuilder = new PatternInterfaceBuilder();
PatternInterface patternInterface = interfaceBuilder
    .SetName("IPatternMethodBuilder")
    .AddMethod(interfaceMethod1)
    .AddMethod(interfaceMethod2)
    .AddMethod(interfaceMethod3)
    .AddMethod(interfaceMethod4)
    .Build();

var patternBuilder = new PatternPrimitiveBuilder();
Pattern pattern = patternBuilder
    .AddClass(patternClass)
    .AddInterface(patternInterface)
    .Build();

Console.WriteLine(PatternCodeGenerator.Generate(pattern, PatternLanguages.CSharp));
Console.ReadLine();