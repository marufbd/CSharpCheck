using System.Collections.Generic;
using System.Linq;

namespace CSharpCheck.Generators
{
    class ListGenerator<T>:Generator<IEnumerable<T>>
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
