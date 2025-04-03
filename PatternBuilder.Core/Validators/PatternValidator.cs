using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatternBuilder.Core.Validators
{
    internal static class PatternValidator
    {
        public static void ThrowIfNullOrWhiteSpace(string value, string valueName = "")
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"'{valueName}' cannot be null or whitespace.", valueName);
        }
    }
}
