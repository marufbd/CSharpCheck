#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;
using System.Collections.Generic;

namespace CSharpCheck.Generators
{
    internal class OneOfGenerator<T> : Generator<T>
    {
        private readonly T[] _vals;

        public OneOfGenerator(T[] vals, int? size = null)
        {
            if (vals == null || vals.Length == 0)
                throw new ArgumentException("vals cannot be empty or null");

            _vals = vals;

            _size = size.HasValue ? size.Value : _size;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _vals[_rnd.Next(_vals.Length)];
            }
        }
    }
}