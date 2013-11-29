#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;
using System.Collections.Generic;
using CSharpCheck.Specification;

namespace CSharpCheck
{
    public class Prop
    {
        public static PropertyBuilder<T> ForAll<T>(IEnumerable<T> generator)
        {
            return new PropertyBuilder<T>(new PropArg<T> {Gen1 = generator, Quntifier = Quantifier.ForAll});
        }

        public static PropertyBuilder<T> ThereExists<T>(IEnumerable<T> generator)
        {
            return new PropertyBuilder<T>(new PropArg<T> {Gen1 = generator, Quntifier = Quantifier.ThereExists});
        }


        public static IPropertySpec ForAll<T>(Func<T, bool> predicate)
        {
            return new Property(
                new PropArg<T>
                {
                    Gen1 = new Arbitrary<T>(),
                    Predicate = predicate,
                    Quntifier = Quantifier.ForAll
                });
        }

        public static IPropertySpec ForAll<T1, T2>(Func<T1, T2, bool> predicate)
        {
            return new Property(
                new PropArg<T1, T2>
                {
                    Gen1 = new Arbitrary<T1>(),
                    Gen2 = new Arbitrary<T2>(),
                    Predicate = predicate,
                    Quntifier = Quantifier.ForAll
                });
        }

        public static IPropertySpec ThereExists<T>(Func<T, bool> predicate)
        {
            return new Property(
                new PropArg<T>
                {
                    Gen1 = new Arbitrary<T>(),
                    Predicate = predicate,
                    Quntifier = Quantifier.ThereExists
                });
        }

        public static IPropertySpec ThereExists<T1, T2>(Func<T1, T2, bool> predicate)
        {
            return new Property(
                new PropArg<T1, T2>
                {
                    Gen1 = new Arbitrary<T1>(),
                    Gen2 = new Arbitrary<T2>(),
                    Predicate = predicate,
                    Quntifier = Quantifier.ThereExists
                });
        }
    }
}