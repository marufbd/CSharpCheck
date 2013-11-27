using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCheck.Generators
{
    class StringGenerator:Generator<string>
    {
        public override IEnumerator<string> GetEnumerator()
        {
            return new ListGenerator<char>().Select(chars => new string(chars.ToArray())).GetEnumerator();
        }
    }
}
