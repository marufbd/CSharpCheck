using System;
using System.Collections.Generic;

namespace CSharpCheck.Generators
{
    class IntGenerator : Generator<int>
    {
        private readonly int? _min, _max;
        public IntGenerator(int min, int max)
        {
            if(min>max)
                throw new ArgumentOutOfRangeException("min cannot be greater than max");
            _max = max;
            _min = min;
        }
        public IntGenerator(){}


        public override IEnumerator<int> GetEnumerator()
        {
            var cnt = _size;
            bool givenZero = false, givenOne = false;
            int checkZero = _rnd.Next(1, 5), checkOne = _rnd.Next(1, 7);
            for (int i = 0; i <cnt ; i++)
            {
                if (_min.HasValue && _max.HasValue)
                {
                    yield return _rnd.Next(_min.Value, _max.Value);
                }
                else
                {
                    var negative = _rnd.Next(0, 2) == 0;
                    var returnZero = i == _rnd.Next(cnt-checkOne);
                    var returnOne = i == _rnd.Next(cnt-checkZero);
                    if (returnZero)
                    {
                        givenZero = true;
                        yield return 0;
                    }
                    if (returnOne)
                    {
                        givenOne = true;
                        yield return negative ? -1 : 1;
                    }
                    //ensure 0 and 1 if exhausting
                    if (i == (cnt - checkZero) && !givenZero)
                        yield return 0;
                    if (i == (cnt - checkOne) && !givenOne)
                        yield return negative ? -1 : 1;
                        
                    yield return negative ? -_rnd.Next() : _rnd.Next();
                }                    
            }
        }
    }
}
