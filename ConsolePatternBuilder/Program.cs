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
    .AddParameter("returnType", "string")
    .AddParameter("name", "string")
    .SetBody(body)
    .Build();

methodBuilder.Clear();

PatternMethod method2 = methodBuilder
    .SetName("AddParameter")
    .SetReturnType("IPatternMethodBuilder")
    .AddParameter("parameterType", "string")
    .AddParameter("parameterName", "string")
    .Build();

var classBuilder = new PatternClassBuilder();
PatternClass patternClass = classBuilder
    .SetName("PatternMethodBuilder")
    .SetParentClass("IPatternMethodBuilder")
    .AddField("_returnType", "string")
    .AddField("_name", "string")
    .AddField("_parameters", "List<PatternParameter>")
    .AddMethod(method1)
    .AddMethod(method2)
    .Build();

methodBuilder.Clear();

PatternMethod interfaceMethod1 = methodBuilder
    .SetName("AddParameter")
    .SetReturnType("IPatternMethodBuilder")
    .HasNoImplementation()
    .AddParameter("returnType", "string")
    .AddParameter("name", "string")
    .Build();

methodBuilder.Clear();

PatternMethod interfaceMethod2 = methodBuilder
    .SetName("AddParameter")
    .SetReturnType("IPatternMethodBuilder")
    .HasNoImplementation()
    .AddParameter("parameterType", "string")
    .AddParameter("parameterName", "string")
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