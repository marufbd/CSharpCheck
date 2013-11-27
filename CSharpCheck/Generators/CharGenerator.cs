using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCheck.Generators
{
    class CharGenerator:Generator<char>
    {
        public override IEnumerator<char> GetEnumerator()
        {
            foreach (var s in Gen.OneOf('a', 'A', '0', ' ', '\'', '"', _size))
            {
                switch (s)
                {
                    case 'a':
                        yield return (char)_rnd.Next((int) 'a', (int) 'z');
                        break;
                    case 'A':
                        yield return (char)_rnd.Next((int)'A', (int)'Z');
                        break;
                    case '0':
                        yield return (char)_rnd.Next((int)'0', (int)'9');
                        break;
                    default:
                        yield return (char) s;
                        break;
                }
            }
        }
    }
}
