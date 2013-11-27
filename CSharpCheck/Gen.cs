using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCheck.Generators;

namespace CSharpCheck
{
    /// <summary>
    /// Utility function for generating generators (am i being recursive!)
    /// </summary>
    public class Gen
    {
        public static Generator<int> Choose(int min, int max)
        {
            return new IntGenerator(min, max+1);
        }

        public static Generator<T> OneOf<T>(params T[] values)
        {
            return new OneOfGenerator<T>(values);
        }

        public static Generator<T> OneOf<T>(Func<T, int> freqProvider, params T[] values)
        {
            var valList = values.ToList();
            foreach (var val in values.Where(x=>freqProvider(x)>1))
            {
                var freq = freqProvider(val);
                for(int i=0;i<freq-1;i++)
                    valList.Add(val);
            }

            return new OneOfGenerator<T>(valList.ToArray());
        }
        
    }
}
