#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCheck.Generators;

namespace CSharpCheck
{
    public class Arbitrary<T> : Generator<T>
    {
        public override IEnumerator<T> GetEnumerator()
        {
            //we do not have implicit as Scala has, so we determine implementation based on reflection
            var type = typeof (T);
            if (type == typeof (int))
            {
                return new IntGenerator().Cast<T>().GetEnumerator();
            }
            if (type == typeof (char))
            {
                return new CharGenerator().Cast<T>().GetEnumerator();
            }
            if (type == typeof (string))
            {
                return new StringGenerator().Cast<T>().GetEnumerator();
            }
            if (type.GetGenericTypeDefinition() == typeof (List<>) && type.GetGenericArguments()[0] == typeof (int))
            {
                var gen = new ListGenerator<int>();
                return gen.Cast<T>().GetEnumerator();
            }
            //maybe try finding a user defined Arbitrary Implementation
            throw new NotImplementedException("No arbitrary generator for type: " + typeof (T));
        }
    }
}