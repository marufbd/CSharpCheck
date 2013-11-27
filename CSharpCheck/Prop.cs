using System;
using System.Collections.Generic;

namespace CSharpCheck
{
    public class Prop
    {
        public static PropertyBuilder<T> ForAll<T>(IEnumerable<T> generator)
        {
            return new PropertyBuilder<T>(new PropArg<T>(){Gen1 = generator, Quntifier = Quantifier.ForAll});
        }

        public static PropertyBuilder<T> ThereExists<T>(IEnumerable<T> generator)
        {
            return new PropertyBuilder<T>(new PropArg<T>() { Gen1 = generator, Quntifier = Quantifier.ThereExists});
        }
        

        public static PropertySpec ForAll<T>(Func<T, bool> predicate)
        {
            return new PropertySpec(
                new PropArg<T>
                {
                    Gen1 = new Arbitrary<T>(),
                    Predicate = predicate,
                    Quntifier = Quantifier.ForAll
                });
        }

        public static PropertySpec ForAll<T1, T2>(Func<T1, T2, bool> predicate)
        {
            return new PropertySpec(
                new PropArg<T1, T2>
                {
                    Gen1 = new Arbitrary<T1>(),
                    Gen2 = new Arbitrary<T2>(),
                    Predicate = predicate,
                    Quntifier = Quantifier.ForAll
                });
        }

        public static PropertySpec ThereExists<T>(Func<T, bool> predicate)
        {
            return new PropertySpec(
                new PropArg<T>
                {
                    Gen1 = new Arbitrary<T>(),
                    Predicate = predicate,
                    Quntifier = Quantifier.ThereExists
                });
        }

        public static PropertySpec ThereExists<T1, T2>(Func<T1, T2, bool> predicate)
        {
            return new PropertySpec(
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
