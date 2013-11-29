#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System.Collections.Generic;
using System.Linq;

namespace CSharpCheck.Generators
{
    internal class StringGenerator : Generator<string>
    {
        public override IEnumerator<string> GetEnumerator()
        {
            return new ListGenerator<char>().Select(chars => new string(chars.ToArray())).GetEnumerator();
        }
    }
}