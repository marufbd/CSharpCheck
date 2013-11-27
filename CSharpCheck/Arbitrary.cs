using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCheck.Generators;

namespace CSharpCheck
{
    public class Arbitrary<T>:Generator<T>
    {        
        public override IEnumerator<T> GetEnumerator()
        {
            //we do not have implicit as Scala has, so we determine implementation based on reflection
            var type = typeof (T);
            if (type == typeof(int))
            {
                return Enumerable.Cast<T>(new IntGenerator()).GetEnumerator();
            }
            if (type == typeof(char))
            {
                return Enumerable.Cast<T>(new CharGenerator()).GetEnumerator();
            }
            else if (type == typeof(string))
            {
                return Enumerable.Cast<T>(new StringGenerator()).GetEnumerator();
            }            
            else if (type.GetGenericTypeDefinition()==typeof(List<>) && type.GetGenericArguments()[0]==typeof(int))
            { 
                var gen = new ListGenerator<int>();
                return Enumerable.Cast<T>(gen).GetEnumerator();
            }
            else
            {
                //maybe try finding a user defined Arbitrary Implementation
                throw new NotImplementedException("No arbitrary generator for type: " + typeof(T));
            }            
        }
    }
}
