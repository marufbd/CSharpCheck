using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCheck.Generators
{
    class OneOfGenerator<T>:Generator<T>
    {
        private T[] _vals;

        public OneOfGenerator(T[] vals, int? size=null)
        {
            if(vals==null || vals.Length==0)
                throw new ArgumentException("vals cannot be empty or null");

            _vals = vals;

            _size = size.HasValue ? size.Value : _size;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i=0;i<_size;i++)
            {
                yield return _vals[_rnd.Next(_vals.Length)];
            }
        }
    }
}
