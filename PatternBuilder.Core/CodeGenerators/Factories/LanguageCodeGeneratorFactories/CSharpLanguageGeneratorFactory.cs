﻿using PatternBuilder.Core.CodeGenerators.CSharpGenerators;
using PatternBuilder.Core.CodeGenerators.Interfaces.Factories;

namespace PatternBuilder.Core.CodeGenerators.Factories.LanguageCodeGeneratorFactories
{
    public class CSharpLanguageGeneratorFactory : ILanguageCodeGeneratorFactory
    {
        public BaseClassCodeGenerator CreateClassCodeGenerator() => new CSharpClassCodeGenerator();

        public BaseInterfaceCodeGenerator CreateInterfaceCodeGenerator() => new CSharpInterfaceCodeGenerator();
    }
}
