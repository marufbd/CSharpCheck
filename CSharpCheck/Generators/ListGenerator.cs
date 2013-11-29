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
    internal class ListGenerator<T> : Generator<IEnumerable<T>>
    {
        public override IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                var generator = new Arbitrary<T>();
                var list = generator.Take(_rnd.Next(Parameters.MaxListSize));

                yield return list.ToList();
            }
        }
    }
}