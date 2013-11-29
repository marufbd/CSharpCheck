#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System.Collections.Generic;

namespace CSharpCheck.Generators
{
    internal class CharGenerator : Generator<char>
    {
        public override IEnumerator<char> GetEnumerator()
        {
            foreach (var s in Gen.OneOf('a', 'A', '0', ' ', '\'', '"', _size))
            {
                switch (s)
                {
                    case 'a':
                        yield return (char) _rnd.Next('a', 'z');
                        break;
                    case 'A':
                        yield return (char) _rnd.Next('A', 'Z');
                        break;
                    case '0':
                        yield return (char) _rnd.Next('0', '9');
                        break;
                    default:
                        yield return (char) s;
                        break;
                }
            }
        }
    }
}