using PatternBuilder.Core.Builders;
using PatternBuilder.Core.CodeGenerators;
using PatternBuilder.Core.CodeGenerators.Factories;
using PatternBuilder.Core.Interfaces.Converters;
using PatternBuilder.Core.Interfaces.Primitives;
using PatternBuilder.Core.Primitives;
using PatternBuilder.Core.Interfaces.Factories;

string body = @"_returnType = returnType;
_name = name;

return this;";

var methodBuilder = new PatternMethodBuilder();
IPatternMethod method1 = methodBuilder
    .SetMethod("IPatternMethodBuilder", "SetMethod")
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

var classBuilder = new PatternClassBuilder();
IPatternClass patternClass = classBuilder
    .SetName("PatternMethodBuilder")
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

var interfaceBuilder = new PatternInterfaceBuilder();
IPatternInterface patternInterface = interfaceBuilder
    .SetName("IPatternMethodBuilder")
    .AddMethod(interfaceMethod1)
    .AddMethod(interfaceMethod2)
    .AddMethod(interfaceMethod3)
    .AddMethod(interfaceMethod4)
    .Build();

var patternBuilder = new PatternBuilder.Core.Builders.PatternBuilder();
IPattern pattern = patternBuilder
    .AddClass(patternClass)
    .AddInterface(patternInterface)
    .Build();

ILanguageCodeGeneratorFactoryProvider languageCodeGeneratorFactoryProvider = new LanguageCodeGeneratorFactoryProvider();
IPatternCodeGenerator generator = new PatternCodeGenerator(languageCodeGeneratorFactoryProvider);

Console.WriteLine(generator.Generate(pattern, CodeGeneratorLanguages.CSharp));
Console.ReadLine();